using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PD2.GameSave
{
	public static class Encryption
	{
		private static byte[] XOR_KEY = 
		{
			0x74, 0x3E, 0x3F, 0xA4, 0x32, 0x43, 0x26, 0x2E, 0x23, 0x36, 
			0x37, 0x6A, 0x6D, 0x3A, 0x48, 0x47, 0x3D, 0x53, 0x2D, 0x63, 
			0x41, 0x6B, 0x29, 0x38, 0x6A, 0x68, 0x5F, 0x4D, 0x4A, 0x68, 
			0x3C, 0x6E, 0x66, 0xF6
		};

		public static byte[] TransformData(byte[] data)
		{
			byte[] ret = (byte[]) data.Clone();

			for (int i = 0; i < data.Length; ++i)
			{
				int keyIdx = ((data.Length + i) * 7) % XOR_KEY.Length;
				ret[i] ^= (byte)(XOR_KEY[keyIdx] * (data.Length - i));
			}

			return ret;
		}
	}
}
