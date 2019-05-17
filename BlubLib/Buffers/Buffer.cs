using System;
using System.Collections;
using System.Collections.Generic;

namespace BlubLib.Buffers
{
    public class Buffer : IList<byte>, IReadOnlyList<byte>, IDisposable
    {
        public byte[] Array { get; }
        public int Offset { get; }
        public int Count { get; }
        public BufferManager BufferManager { get; }
        internal bool IsUnused { get; set; }

        internal Buffer(BufferManager bufferManager, byte[] array, int offset, int count)
        {
            if (bufferManager == null)
                throw new ArgumentNullException(nameof(bufferManager));

            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (array.Length - offset < count)
                throw new ArgumentOutOfRangeException();

            BufferManager = bufferManager;
            Array = array;
            Offset = offset;
            Count = count;
        }

        public void Dispose()
        {
            if (IsUnused)
                return;

            BufferManager.Return(this);
        }

        #region IReadOnlyList<byte>

        byte IReadOnlyList<byte>.this[int index] => this[index];

        #endregion

        #region IList<byte>

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return Array[Offset + index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                Array[Offset + index] = value;
            }
        }

        int IList<byte>.IndexOf(byte item)
        {
            int index = System.Array.IndexOf(Array, item, Offset, Count);
            return index >= 0 ? index - Offset : -1;
        }

        void IList<byte>.Insert(int index, byte item)
        {
            throw new NotSupportedException();
        }

        void IList<byte>.RemoveAt(int index)
        {
            throw new NotSupportedException();
        }
        #endregion

        #region ICollection<T>

        bool ICollection<byte>.IsReadOnly => false;

        void ICollection<byte>.Add(byte item)
        {
            throw new NotSupportedException();
        }

        void ICollection<byte>.Clear()
        {
            throw new NotSupportedException();
        }

        bool ICollection<byte>.Contains(byte item)
        {
            int index = System.Array.IndexOf(Array, item, Offset, Count);
            return index >= 0;
        }

        public void CopyTo(byte[] array, int arrayIndex)
        {
            System.Array.Copy(Array, Offset, array, arrayIndex, Count);
        }

        bool ICollection<byte>.Remove(byte item)
        {
            throw new NotSupportedException();
        }

        #endregion

        #region IEnumerable<T>

        public IEnumerator<byte> GetEnumerator()
        {
            for (int i = Offset; i < Offset + Count; ++i)
                yield return Array[i];
        }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
