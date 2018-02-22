﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Neo.RPC.Helpers
{
    public static class Helper
    {
        public static byte[] HexToBytes(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return new byte[0];
            if (value.Length % 2 == 1)
                throw new FormatException();
            var result = new byte[value.Length / 2];
            for (var i = 0; i < result.Length; i++)
                result[i] = byte.Parse(value.Substring(i * 2, 2), NumberStyles.AllowHexSpecifier);
            return result;
        }

        public static string ToHexString(this IEnumerable<byte> value)
        {
            var sb = new StringBuilder();
            foreach (var b in value)
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        public static string HextoString(string inputText)
        {
            var bb = Enumerable.Range(0, inputText.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(inputText.Substring(x, 2), 16))
                .ToArray();
            return Encoding.ASCII.GetString(bb);
            // or System.Text.Encoding.UTF7.GetString
            // or System.Text.Encoding.UTF8.GetString
            // or System.Text.Encoding.Unicode.GetString
            // or etc.
        }


        // NEO METHODS
        //	private static ThreadLocal<SHA256> _sha256 = new ThreadLocal<SHA256>(() => SHA256.Create());
        //	private static ThreadLocal<RIPEMD160Managed> _ripemd160 = new ThreadLocal<RIPEMD160Managed>(() => new RIPEMD160Managed());

        //	internal static byte[] AES256Decrypt(this byte[] block, byte[] key)
        //	{
        //		using (Aes aes = Aes.Create())
        //		{
        //			aes.Key = key;
        //			aes.Mode = CipherMode.ECB;
        //			aes.Padding = PaddingMode.None;
        //			using (ICryptoTransform decryptor = aes.CreateDecryptor())
        //			{
        //				return decryptor.TransformFinalBlock(block, 0, block.Length);
        //			}
        //		}
        //	}

        //	internal static byte[] AES256Encrypt(this byte[] block, byte[] key)
        //	{
        //		using (Aes aes = Aes.Create())
        //		{
        //			aes.Key = key;
        //			aes.Mode = CipherMode.ECB;
        //			aes.Padding = PaddingMode.None;
        //			using (ICryptoTransform encryptor = aes.CreateEncryptor())
        //			{
        //				return encryptor.TransformFinalBlock(block, 0, block.Length);
        //			}
        //		}
        //	}

        //	internal static byte[] AesDecrypt(this byte[] data, byte[] key, byte[] iv)
        //	{
        //		if (data == null || key == null || iv == null) throw new ArgumentNullException();
        //		if (data.Length % 16 != 0 || key.Length != 32 || iv.Length != 16) throw new ArgumentException();
        //		using (Aes aes = Aes.Create())
        //		{
        //			aes.Padding = PaddingMode.None;
        //			using (ICryptoTransform decryptor = aes.CreateDecryptor(key, iv))
        //			{
        //				return decryptor.TransformFinalBlock(data, 0, data.Length);
        //			}
        //		}
        //	}

        //	internal static byte[] AesEncrypt(this byte[] data, byte[] key, byte[] iv)
        //	{
        //		if (data == null || key == null || iv == null) throw new ArgumentNullException();
        //		if (data.Length % 16 != 0 || key.Length != 32 || iv.Length != 16) throw new ArgumentException();
        //		using (Aes aes = Aes.Create())
        //		{
        //			aes.Padding = PaddingMode.None;
        //			using (ICryptoTransform encryptor = aes.CreateEncryptor(key, iv))
        //			{
        //				return encryptor.TransformFinalBlock(data, 0, data.Length);
        //			}
        //		}
        //	}

        //	public static byte[] Base58CheckDecode(this string input)
        //	{
        //		byte[] buffer = Base58.Decode(input);
        //		if (buffer.Length < 4) throw new FormatException();
        //		byte[] checksum = buffer.Sha256(0, buffer.Length - 4).Sha256();
        //		if (!buffer.Skip(buffer.Length - 4).SequenceEqual(checksum.Take(4)))
        //			throw new FormatException();
        //		return buffer.Take(buffer.Length - 4).ToArray();
        //	}

        //	public static string Base58CheckEncode(this byte[] data)
        //	{
        //		byte[] checksum = data.Sha256().Sha256();
        //		byte[] buffer = new byte[data.Length + 4];
        //		Buffer.BlockCopy(data, 0, buffer, 0, data.Length);
        //		Buffer.BlockCopy(checksum, 0, buffer, data.Length, 4);
        //		return Base58.Encode(buffer);
        //	}

        //	/// <summary>
        //	/// 求字节数组的ripemd160散列值
        //	/// </summary>
        //	/// <param name="value">字节数组</param>
        //	/// <returns>返回该散列值</returns>
        //	public static byte[] RIPEMD160(this IEnumerable<byte> value)
        //	{
        //		return _ripemd160.Value.ComputeHash(value.ToArray());
        //	}

        //	public static uint Murmur32(this IEnumerable<byte> value, uint seed)
        //	{
        //		using (Murmur3 murmur = new Murmur3(seed))
        //		{
        //			return murmur.ComputeHash(value.ToArray()).ToUInt32(0);
        //		}
        //	}

        //	/// <summary>
        //	/// 求字节数组的sha256散列值
        //	/// </summary>
        //	/// <param name="value">字节数组</param>
        //	/// <returns>返回该散列值</returns>
        //	public static byte[] Sha256(this IEnumerable<byte> value)
        //	{
        //		return _sha256.Value.ComputeHash(value.ToArray());
        //	}

        //	/// <summary>
        //	/// 求字节数组的sha256散列值
        //	/// </summary>
        //	/// <param name="value">字节数组</param>
        //	/// <param name="offset">偏移量，散列计算时从该偏移量处开始</param>
        //	/// <param name="count">要计算散列值的字节数量</param>
        //	/// <returns>返回该散列值</returns>
        //	public static byte[] Sha256(this byte[] value, int offset, int count)
        //	{
        //		return _sha256.Value.ComputeHash(value, offset, count);
        //	}

        //	internal static byte[] ToAesKey(this string password)
        //	{
        //		using (SHA256 sha256 = SHA256.Create())
        //		{
        //			byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        //			byte[] passwordHash = sha256.ComputeHash(passwordBytes);
        //			byte[] passwordHash2 = sha256.ComputeHash(passwordHash);
        //			Array.Clear(passwordBytes, 0, passwordBytes.Length);
        //			Array.Clear(passwordHash, 0, passwordHash.Length);
        //			return passwordHash2;
        //		}
        //	}

        //	internal static byte[] ToAesKey(this SecureString password)
        //	{
        //		using (SHA256 sha256 = SHA256.Create())
        //		{
        //			byte[] passwordBytes = password.ToArray();
        //			byte[] passwordHash = sha256.ComputeHash(passwordBytes);
        //			byte[] passwordHash2 = sha256.ComputeHash(passwordHash);
        //			Array.Clear(passwordBytes, 0, passwordBytes.Length);
        //			Array.Clear(passwordHash, 0, passwordHash.Length);
        //			return passwordHash2;
        //		}
        //	}

        //	internal static byte[] ToArray(this SecureString s)
        //	{
        //		if (s == null)
        //			throw new NullReferenceException();
        //		if (s.Length == 0)
        //			return new byte[0];
        //		List<byte> result = new List<byte>();
        //		IntPtr ptr = SecureStringMarshal.SecureStringToGlobalAllocAnsi(s);
        //		try
        //		{
        //			int i = 0;
        //			do
        //			{
        //				byte b = Marshal.ReadByte(ptr, i++);
        //				if (b == 0)
        //					break;
        //				result.Add(b);
        //			} while (true);
        //		}
        //		finally
        //		{
        //			Marshal.ZeroFreeGlobalAllocAnsi(ptr);
        //		}
        //		return result.ToArray();
        //	}

        //	public static T[] SubArray<T>(this T[] data, int index, int length)
        //	{
        //		T[] result = new T[length];
        //		Array.Copy(data, index, result, 0, length);
        //		return result;
        //	}

        //	public static byte[] GetScriptHashFromAddress(this string address)
        //	{
        //		var temp = address.Base58CheckDecode();
        //		temp = temp.SubArray(1, 20);
        //		return temp;
        //	}
    }
}