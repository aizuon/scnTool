using System;
using System.Collections.Generic;
using System.IO;

namespace BlubLib.Buffers
{
    public class BufferStream : Stream
    {
        private bool _disposed;
        private List<Buffer> _buffers;
        private int _position;
        private int _length;

        public BufferManager BufferManager { get; }
        public override bool CanRead => !_disposed;
        public override bool CanSeek => !_disposed;
        public override bool CanWrite => !_disposed;
        public override long Length => _length;
        public override long Position
        {
            get
            {
                ThrowIfDisposed();
                return _position;
            }
            set
            {
                ThrowIfDisposed();

                if (value < 0 || value > _length)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (_position == value)
                    return;

                _position = (int)value;
            }
        }

        public BufferStream(BufferManager bufferManager)
            : this(bufferManager, 0)
        {
        }

        public BufferStream(BufferManager bufferManager, int initialCapacity)
        {
            if (bufferManager == null)
                throw new ArgumentNullException(nameof(bufferManager));

            BufferManager = bufferManager;
            _length = 0;
            _position = 0;
            _buffers = new List<Buffer>((initialCapacity / bufferManager.BufferSize) + 1);
        }

        public override void Flush()
        {
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            ThrowIfDisposed();

            if (offset > int.MaxValue || offset < int.MinValue)
                throw new ArgumentOutOfRangeException(nameof(offset));

            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = (int)offset;
                    break;

                case SeekOrigin.Current:
                    Position = _position + (int)offset;
                    break;

                case SeekOrigin.End:
                    Position = _length + (int)offset;
                    break;

                default:
                    throw new ArgumentException(nameof(origin));
            }

            return _position;
        }

        public override void SetLength(long value)
        {
            ThrowIfDisposed();

            if (value < 0 || value > int.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(value));

            int newLength = (int)value;
            EnsureCapacity(newLength);
            _length = newLength;

            // Set position to new length in case the length was decreased
            if (_position > Length)
                _position = newLength;
        }

#pragma warning disable RECS0133 // Parameter name differs in base declaration
        public override int Read(byte[] array, int offset, int count)
#pragma warning restore RECS0133 // Parameter name differs in base declaration
        {
            ThrowIfDisposed();

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (array.Length - offset < count)
                throw new ArgumentOutOfRangeException();

            count = Math.Min(_length - _position, count);
            if (count <= 0)
                return 0;

            int bytesCopied = 0;
            while (bytesCopied < count)
            {
                var buffer = GetCurrentBuffer(out int bufferOffset);
                int bytesToCopy = Math.Min(count - bytesCopied, BufferManager.BufferSize - bufferOffset);

                Array.Copy(buffer.Array, buffer.Offset + bufferOffset, array, offset + bytesCopied, bytesToCopy);
                bytesCopied += bytesToCopy;
                _position += bytesToCopy;
            }

            return count;
        }

#pragma warning disable RECS0133 // Parameter name differs in base declaration
        public override void Write(byte[] array, int offset, int count)
#pragma warning restore RECS0133 // Parameter name differs in base declaration
        {
            ThrowIfDisposed();

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (array.Length - offset < count)
                throw new ArgumentOutOfRangeException();

            int newLength = _position + count;
            if (newLength > _length)
            {
                EnsureCapacity(newLength);
                _length = newLength;
            }

            int bytesCopied = 0;
            while (bytesCopied < count)
            {
                var buffer = GetCurrentBuffer(out int bufferOffset);
                int bytesToCopy = Math.Min(count - bytesCopied, BufferManager.BufferSize - bufferOffset);

                Array.Copy(array, offset + bytesCopied, buffer.Array, buffer.Offset + bufferOffset, bytesToCopy);
                bytesCopied += bytesToCopy;
                _position += bytesToCopy;
            }
        }

        public virtual byte[] ToArray()
        {
            ThrowIfDisposed();

            byte[] result = new byte[_length];
            int bytesCopied = 0;
            int currentBufferIndex = 0;
            while (bytesCopied < result.Length)
            {
                int count = Math.Min(BufferManager.BufferSize, result.Length - bytesCopied);
                var buffer = _buffers[currentBufferIndex++];
                Array.Copy(buffer.Array, buffer.Offset, result, bytesCopied, count);
                bytesCopied += count;
            }

            return result;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _disposed = true;
                foreach (var buffer in _buffers)
                    buffer.Dispose();

                _buffers = null;
            }

            base.Dispose(disposing);
        }

        private Buffer GetCurrentBuffer(out int offset)
        {
            int index = _position / BufferManager.BufferSize;
            offset = (_position - (index * BufferManager.BufferSize)) % BufferManager.BufferSize;
            return _buffers[index];
        }

        private void EnsureCapacity(int newCapacity)
        {
            int currentCapacity = _buffers.Count * BufferManager.BufferSize;

            // Check if we already have enough buffers
            if (currentCapacity >= newCapacity)
                return;

            int neededBytes = newCapacity - currentCapacity;
            int neededBuffers = (neededBytes / BufferManager.BufferSize) + 1;

            for (int i = 0; i < neededBuffers; ++i)
                _buffers.Add(BufferManager.Rent());
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);
        }
    }
}
