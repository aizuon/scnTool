using BlubLib.Buffers;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlubLib.IO
{
    public static class BinaryReaderExtensions
    {
        public static byte[] ReadToEnd(this BinaryReader @this)
        {
            return @this.BaseStream.ReadToEnd();
        }

        public static Task<byte[]> ReadToEndAsync(this BinaryReader @this)
        {
            return @this.BaseStream.ReadToEndAsync();
        }

        public static string[] ReadStrings(this BinaryReader @this, int count)
        {
            string[] array = new string[count];
            for (int i = 0; i < count; i++)
                array[i] = @this.ReadString();
            return array;
        }

        public static T[] ReadArray<T>(this BinaryReader @this, int count)
            where T : struct, IComparable, IConvertible
        {
            var type = typeof(T);
            var array = FastActivator<T>.CreateArray(count);
            byte[] data;

            switch (type.GetTypeCode())
            {
                case TypeCode.Boolean:
                    data = @this.ReadBytes(sizeof(bool) * count);
                    break;

                case TypeCode.Char:
                    data = @this.ReadBytes(sizeof(char) * count);
                    break;

                case TypeCode.Byte:
                    data = @this.ReadBytes(sizeof(byte) * count);
                    break;

                case TypeCode.SByte:
                    data = @this.ReadBytes(sizeof(sbyte) * count);
                    break;

                case TypeCode.Int16:
                    data = @this.ReadBytes(sizeof(short) * count);
                    break;

                case TypeCode.Int32:
                    data = @this.ReadBytes(sizeof(int) * count);
                    break;

                case TypeCode.Int64:
                    data = @this.ReadBytes(sizeof(long) * count);
                    break;

                case TypeCode.UInt16:
                    data = @this.ReadBytes(sizeof(ushort) * count);
                    break;

                case TypeCode.UInt32:
                    data = @this.ReadBytes(sizeof(uint) * count);
                    break;

                case TypeCode.UInt64:
                    data = @this.ReadBytes(sizeof(ulong) * count);
                    break;

                case TypeCode.Single:
                    data = @this.ReadBytes(sizeof(float) * count);
                    break;

                case TypeCode.Double:
                    data = @this.ReadBytes(sizeof(double) * count);
                    break;

                case TypeCode.Decimal:
                    data = @this.ReadBytes(sizeof(decimal) * count);
                    break;

                default:
                    throw new NotSupportedException("Type is not supported");
            }

            System.Buffer.BlockCopy(data, 0, array, 0, data.Length);
            return array;
        }

        public static T ReadEnum<T>(this BinaryReader @this)
            where T : struct, IComparable, IConvertible
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T is not an enum");

            var derivedType = Enum.GetUnderlyingType(type);
            switch (derivedType.GetTypeCode())
            {
                case TypeCode.Byte:
                    return DynamicCast<T>.From(@this.ReadByte());

                case TypeCode.SByte:
                    return DynamicCast<T>.From(@this.ReadSByte());

                case TypeCode.Int16:
                    return DynamicCast<T>.From(@this.ReadInt16());

                case TypeCode.Int32:
                    return DynamicCast<T>.From(@this.ReadInt32());

                case TypeCode.Int64:
                    return DynamicCast<T>.From(@this.ReadInt64());

                case TypeCode.UInt16:
                    return DynamicCast<T>.From(@this.ReadUInt16());

                case TypeCode.UInt32:
                    return DynamicCast<T>.From(@this.ReadUInt32());

                case TypeCode.UInt64:
                    return DynamicCast<T>.From(@this.ReadUInt64());

                default:
                    throw new NotSupportedException("Type is not supported");
            }
        }

        public static T[] ReadEnums<T>(this BinaryReader @this, int count)
            where T : struct, IComparable, IConvertible
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T is not an enum");

            var array = FastActivator<T>.CreateArray(count);
            for (int i = 0; i < count; i++)
                array[i] = @this.ReadEnum<T>();
            return array;
        }

        public static T Deserialize<T>(this BinaryReader @this)
            where T : IManualSerializer, new()
        {
            var instance = FastActivator<T>.Create();
            instance.Deserialize(@this.BaseStream);
            return instance;
        }

        public static T[] DeserializeArray<T>(this BinaryReader @this, int count)
            where T : IManualSerializer, new()
        {
            var array = FastActivator<T>.CreateArray(count);
            for (int i = 0; i < count; i++)
                array[i] = @this.Deserialize<T>();
            return array;
        }

        public static IPEndPoint ReadIPEndPoint(this BinaryReader @this)
        {
            var ip = new IPAddress(@this.ReadBytes(4));
            return new IPEndPoint(ip, @this.ReadUInt16());
        }

        public static string ReadCString(this BinaryReader @this)
        {
            var sb = new StringBuilder();
            char c;
            while ((c = @this.ReadChar()) != 0)
                sb.Append(c);

            return sb.ToString();
        }

        public static string ReadCString(this BinaryReader @this, int length)
        {
            if (length < 1)
                throw new ArgumentOutOfRangeException(nameof(length));

            return Encoding.UTF8.GetString(@this.ReadBytes(length)).TrimEnd('\0');
        }

        public static bool IsEOF(this BinaryReader @this)
        {
            return @this.BaseStream.IsEOF();
        }
    }

    public static class BinaryWriterExtensions
    {
        #region Write Arrays
        public static void Write(this BinaryWriter @this, IEnumerable<byte> values)
        {
            foreach (byte value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<bool> values)
        {
            foreach (bool value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<char> values)
        {
            foreach (char value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<sbyte> values)
        {
            foreach (sbyte value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<short> values)
        {
            foreach (short value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<ushort> values)
        {
            foreach (ushort value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<int> values)
        {
            foreach (int value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<uint> values)
        {
            foreach (uint value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<long> values)
        {
            foreach (long value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<ulong> values)
        {
            foreach (ulong value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<float> values)
        {
            foreach (float value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<double> values)
        {
            foreach (double value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<decimal> values)
        {
            foreach (decimal value in values)
                @this.Write(value);
        }

        public static void Write(this BinaryWriter @this, IEnumerable<string> values)
        {
            foreach (string value in values)
                @this.Write(value);
        }
        #endregion

        public static void WriteEnum<T>(this BinaryWriter @this, T value)
            where T : struct, IComparable, IConvertible
        {
            var type = value.GetType();
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T is not an enum");

            var derivedType = Enum.GetUnderlyingType(type);
            switch (derivedType.GetTypeCode())
            {
                case TypeCode.Byte:
                    @this.Write(DynamicCast<byte>.From(value));
                    break;

                case TypeCode.SByte:
                    @this.Write(DynamicCast<sbyte>.From(value));
                    break;

                case TypeCode.Int16:
                    @this.Write(DynamicCast<short>.From(value));
                    break;

                case TypeCode.UInt16:
                    @this.Write(DynamicCast<ushort>.From(value));
                    break;

                case TypeCode.Int32:
                    @this.Write(DynamicCast<int>.From(value));
                    break;

                case TypeCode.UInt32:
                    @this.Write(DynamicCast<uint>.From(value));
                    break;

                case TypeCode.Int64:
                    @this.Write(DynamicCast<long>.From(value));
                    break;

                case TypeCode.UInt64:
                    @this.Write(DynamicCast<ulong>.From(value));
                    break;

                case TypeCode.Single:
                    @this.Write(DynamicCast<float>.From(value));
                    break;

                case TypeCode.Double:
                    @this.Write(DynamicCast<double>.From(value));
                    break;

                case TypeCode.Decimal:
                    @this.Write(DynamicCast<decimal>.From(value));
                    break;

                default:
                    throw new NotSupportedException("Type is not supported");
            }
        }

        public static void Serialize(this BinaryWriter @this, IManualSerializer value)
        {
            value.Serialize(@this.BaseStream);
        }

        public static void Serialize<T>(this BinaryWriter @this, IEnumerable<T> values)
            where T : IManualSerializer
        {
            foreach (var value in values)
                @this.Serialize(value);
        }

        public static void Write(this BinaryWriter @this, IPEndPoint value)
        {
            @this.Write(value.Address.GetAddressBytes());
            @this.Write((ushort)value.Port);
        }

        public static void Write(this BinaryWriter @this, ArraySegment<byte> segment)
        {
            @this.Write(segment.Array, segment.Offset, segment.Count);
        }

        public static void WriteCString(this BinaryWriter @this, string value)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(value + "\0");
            @this.Write(buffer);
        }

        public static void WriteCString(this BinaryWriter @this, string value, int maxLength)
        {
            value = value ?? "";
            byte[] buffer = Encoding.UTF8.GetBytes(value + "\0");
            if (buffer.Length > maxLength)
                throw new ArgumentOutOfRangeException($"{nameof(value)} is longer than {nameof(maxLength)}", nameof(value));

            @this.Write(buffer);
            @this.Fill(maxLength - buffer.Length);
        }

        public static void Fill(this BinaryWriter @this, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (count == 0)
                return;

            if (count < 256)
            {
                for (int i = 0; i < count; ++i)
                    @this.Write((byte)0);
            }
            else
            {
                @this.Write(new byte[count]);
            }
        }

        public static bool IsEOF(this BinaryWriter @this)
        {
            return @this.BaseStream.IsEOF();
        }

        public static byte[] ToArray(this BinaryWriter @this)
        {
            switch (@this.BaseStream)
            {
                case MemoryStream memoryStream:
                    return memoryStream.ToArray();

                case BufferStream bufferStream:
                    return bufferStream.ToArray();
            }

            throw new InvalidOperationException("BaseStream must be a MemoryStream or BufferStream");
        }
    }

    public static class StreamExtensions
    {
        public static BinaryReader ToBinaryReader(this Stream @this, Encoding encoding, bool leaveOpen)
        {
            return new BinaryReader(@this, encoding, leaveOpen);
        }

        public static BinaryReader ToBinaryReader(this Stream @this, bool leaveOpen)
        {
            return new BinaryReader(@this, Encoding.UTF8, leaveOpen);
        }

        public static BinaryWriter ToBinaryWriter(this Stream @this, Encoding encoding, bool leaveOpen)
        {
            return new BinaryWriter(@this, encoding, leaveOpen);
        }

        public static BinaryWriter ToBinaryWriter(this Stream @this, bool leaveOpen)
        {
            return new BinaryWriter(@this, Encoding.UTF8, leaveOpen);
        }

        public static byte[] ReadToEnd(this Stream @this)
        {
            using (var ms = new MemoryStream())
            {
                @this.CopyTo(ms);
                return ms.ToArray();
            }
        }

        public static async Task<byte[]> ReadToEndAsync(this Stream @this)
        {
            using (var ms = new MemoryStream())
            {
                await @this.CopyToAsync(ms).ConfigureAwait(false);
                return ms.ToArray();
            }
        }

        public static void Serialize(this Stream @this, IManualSerializer value)
        {
            value.Serialize(@this);
        }

        public static void Serialize<T>(this Stream @this, IEnumerable<T> values)
            where T : IManualSerializer
        {
            foreach (var value in values)
                @this.Serialize(value);
        }

        public static T Deserialize<T>(this Stream @this)
            where T : IManualSerializer, new()
        {
            var instance = new T();
            instance.Deserialize(@this);
            return instance;
        }

        public static T[] DeserializeArray<T>(this Stream @this, int count)
            where T : IManualSerializer, new()
        {
            return @this.DeserializeArray<T>((uint)count);
        }

        public static T[] DeserializeArray<T>(this Stream @this, uint count)
            where T : IManualSerializer, new()
        {
            var buffer = new T[count];
            for (int i = 0; i < count; i++)
                buffer[i] = @this.Deserialize<T>();
            return buffer;
        }

        public static bool IsEOF(this Stream @this)
        {
            return @this.Position == @this.Length;
        }

        public static byte[] CompressGZip(this Stream @this)
        {
            using (var ms = new MemoryStream())
            using (var stream = new GZipStream(@this, CompressionMode.Compress, true))
            {
                stream.CopyTo(ms);
                stream.Flush();
                return ms.ToArray();
            }
        }

        public static void CompressGZip(this Stream @this, Stream output)
        {
            using (var stream = new GZipStream(@this, CompressionMode.Compress, true))
            {
                stream.CopyTo(output);
                stream.Flush();
            }
        }

        public static byte[] CompressDeflate(this Stream @this)
        {
            using (var ms = new MemoryStream())
            using (var stream = new DeflateStream(@this, CompressionMode.Compress, true))
            {
                stream.CopyTo(ms);
                stream.Flush();
                return ms.ToArray();
            }
        }

        public static void CompressDeflate(this Stream @this, Stream output)
        {
            using (var stream = new DeflateStream(@this, CompressionMode.Compress, true))
            {
                stream.CopyTo(output);
                stream.Flush();
            }
        }

        public static byte[] DecompressGZip(this Stream @this)
        {
            using (var stream = new GZipStream(@this, CompressionMode.Decompress, true))
                return stream.ReadToEnd();
        }

        public static void DecompressGZip(this Stream @this, Stream output)
        {
            using (var stream = new GZipStream(@this, CompressionMode.Decompress, true))
                stream.CopyTo(output);
        }

        public static byte[] DecompressDeflate(this Stream @this)
        {
            using (var stream = new DeflateStream(@this, CompressionMode.Decompress, true))
                return stream.ReadToEnd();
        }

        public static void DecompressDeflate(this Stream @this, Stream output)
        {
            using (var stream = new DeflateStream(@this, CompressionMode.Decompress, true))
                stream.CopyTo(output);
        }
    }
}
