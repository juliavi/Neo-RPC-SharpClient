using System;
using System.IO;
using System.Linq;
using Neo.Base.Interfaces;

namespace Neo.Base.DataTypes
{
    public abstract class UIntBase : IEquatable<UIntBase>, ISerializable
    {
        private readonly byte[] data_bytes;

        protected UIntBase(int bytes, byte[] value)
        {
            if (value == null)
            {
                data_bytes = new byte[bytes];
                return;
            }
            if (value.Length != bytes)
                throw new ArgumentException();
            data_bytes = value;
        }

        public bool Equals(UIntBase other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (data_bytes.Length != other.data_bytes.Length)
                return false;
            return data_bytes.SequenceEqual(other.data_bytes);
        }

        public int Size => data_bytes.Length;

        void ISerializable.Deserialize(BinaryReader reader)
        {
            reader.Read(data_bytes, 0, data_bytes.Length);
        }

        void ISerializable.Serialize(BinaryWriter writer)
        {
            writer.Write(data_bytes);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
                return false;
            if (!(obj is UIntBase))
                return false;
            return Equals((UIntBase) obj);
        }

        public override int GetHashCode()
        {
            return data_bytes.ToInt32(0);
        }

        public static UIntBase Parse(string s)
        {
            if (s.Length == 40 || s.Length == 42)
                return UInt160.Parse(s);
            if (s.Length == 64 || s.Length == 66)
                return UInt256.Parse(s);
            throw new FormatException();
        }

        public byte[] ToArray()
        {
            return data_bytes;
        }

        /// <summary>
        ///     Convert to hexadecimal string
        /// </summary>
        /// <returns>Return hexadecimal string</returns>
        public override string ToString()
        {
            return "0x" + data_bytes.Reverse().ToHexString();
        }

        public static bool TryParse<T>(string s, out T result) where T : UIntBase
        {
            int size;
            if (typeof(T) == typeof(UInt160))
                size = 20;
            else if (typeof(T) == typeof(UInt256))
                size = 32;
            else if (s.Length == 40 || s.Length == 42)
                size = 20;
            else if (s.Length == 64 || s.Length == 66)
                size = 32;
            else
                size = 0;
            if (size == 20)
            {
                if (UInt160.TryParse(s, out var r))
                {
                    result = (T) (UIntBase) r;
                    return true;
                }
            }
            else if (size == 32)
            {
                if (UInt256.TryParse(s, out var r))
                {
                    result = (T) (UIntBase) r;
                    return true;
                }
            }
            result = null;
            return false;
        }

        public static bool operator ==(UIntBase left, UIntBase right)
        {
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(UIntBase left, UIntBase right)
        {
            return !(left == right);
        }
    }
}