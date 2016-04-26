using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PD2.GameSave
{
	/*
	struct Block
	{
		int	SIZE
		int	VERSION
		byte[size - 16] data
		byte[16] MD5(data)
	}
	*/

	public class DataBlock
	{
		protected const int BLOCK_VERSION = 10; // BETA = 9, RETAIL = 10

		protected const int BLOCK_SIZE_LENGTH = 4;
		protected const int BLOCK_VERSION_LENGTH = 4;
		protected const int BLOCK_CHECKSUM_LENGTH = 16;

		protected byte[] data;

		public int Size
		{
			get { return BLOCK_VERSION_LENGTH + data.Length + BLOCK_CHECKSUM_LENGTH; }
		}

		public DataBlock(BinaryReader br)
		{
			// Read header
			int blockSize = br.ReadInt32();
			int version = br.ReadInt32();

			// Validate header
			if (version != BLOCK_VERSION)
				throw new Exception(String.Format("Unsupported block version: {0}", version.ToString("X4")));

			// Read data
			data = br.ReadBytes(blockSize - BLOCK_CHECKSUM_LENGTH - BLOCK_SIZE_LENGTH);

			// Rest is checksum so we discard
			br.ReadBytes(BLOCK_CHECKSUM_LENGTH);
		}

		public byte[] ToArray()
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			bw.Write(Size);
			bw.Write(BLOCK_VERSION);
			bw.Write(data);
			bw.Write(MD5.Create().ComputeHash(data));

			return ms.ToArray();
		}
	}
}
