using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PD2.GameSave
{
	public static class Encryption
	{
		#region Data Encryption/Hashing
		private static byte[] XOR_KEY = 
		{
			0x74, 0x3E, 0x3F, 0xA4, 0x32, 0x43, 0x26, 0x2E, 0x23, 0x36, 
			0x37, 0x6A, 0x6D, 0x3A, 0x48, 0x47, 0x3D, 0x53, 0x2D, 0x63, 
			0x41, 0x6B, 0x29, 0x38, 0x6A, 0x68, 0x5F, 0x4D, 0x4A, 0x68, 
			0x3C, 0x6E, 0x66, 0xF6
		};

		private static byte[] HASH_KEY = { 0x1A, 0x1F, 0x32, 0x2C };

		public static byte[] TransformData(byte[] data)
		{
			byte[] ret = (byte[]) data.Clone();

			for (int i = 0; i < data.Length; i++)
			{
				int keyIdx = ((data.Length + i) * 7) % XOR_KEY.Length;
				ret[i] ^= (byte)(XOR_KEY[keyIdx] * (data.Length - i));
			}

			return ret;
		}

		public static byte[] GenerateSaveHash(byte[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				bool condition = (byte)((data[i] + HASH_KEY[i % 4]) % 2) != 0;
				if (condition) data[i] = (byte)(i % 7);
			}

			return MD5.Create().ComputeHash(data);
		}
		#endregion

		#region String Encoding
		private static byte[] PADDING_PATTERN =
		{
			0xDF, 0xC1, 0xA3, 0x85, 0x67, 0x49, 0x2B, 0x0D, 0xED, 0xCF, 
			0xB1, 0x93 
		};

		public static UnencodedString UnencodeString(byte[] data)
		{
			// Check if string is encoded
			for (int i = 1; i < data.Length; i +=2)
			{
				if (data[i] != PADDING_PATTERN[(i - 1) / 2])
					return null;
			}

			// Since string is encoded, we return unencoded string
			byte[] unencoded = new byte[data.Length / 2];

			for (int i = 0; i < unencoded.Length; i++)
			{
				unencoded[i] = (byte) (0xFE - data[i * 2]);
			}

			return new UnencodedString(ASCIIEncoding.ASCII.GetString(unencoded));
		}

		public static byte[] EncodeString(String s)
		{
			byte[] sData = ASCIIEncoding.ASCII.GetBytes(s);
			byte[] data = new byte[sData.Length * 2];

			for (int i = 0; i < data.Length; i++)
			{
				data[i] = (i % 2 == 0) ? (byte) (0xFE - sData[i / 2]) : PADDING_PATTERN[(i - 1) / 2];
			}

			return data;
		}
		#endregion
	}
}
