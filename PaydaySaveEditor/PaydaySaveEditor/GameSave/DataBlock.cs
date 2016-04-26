using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PD2.GameSave
{
	/*

	struct Block
	{
		int MAGIC
		int SIZE
		byte[size - 16] data
		byte[16] md5(data)
	}

	*/

	public class DataBlock
	{
		private const int BLOCK_HEADER_MAGIC = 0x0A;
		private const int BLOCK_CHECKSUM_LENGTH = 16;

		private byte[] data;

		public DataBlock(BinaryReader br)
		{
			// Read header
			int header = br.ReadInt32();

			// Validate header
			if (header != BLOCK_HEADER_MAGIC)
				throw new Exception("Invalid block header detected, invalid block header.");

			// Read data
			int blockSize = br.ReadInt32();
			data = br.ReadBytes(blockSize - BLOCK_CHECKSUM_LENGTH);

			// Rest is checksum so we discard
			br.ReadBytes(BLOCK_CHECKSUM_LENGTH);
		}
	}
}
