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
		int				VERSION
		int				SIZE
		byte[size - 16] data
		byte[16]		MD5(data)
	}
	*/

	public class DataBlock
	{
		private const int BLOCK_VERSION = 10; // BETA = 9, RETAIL = 10
		private const int BLOCK_CHECKSUM_LENGTH = 16;

		private byte[] data;

		public DataBlock(BinaryReader br)
		{
			// Read header
			int header = br.ReadInt32();

			// Validate header
			if (header != BLOCK_VERSION)
				throw new Exception("Invalid block header detected, invalid block header.");

			// Read data
			int blockSize = br.ReadInt32();
			data = br.ReadBytes(blockSize - BLOCK_CHECKSUM_LENGTH);

			// Rest is checksum so we discard
			br.ReadBytes(BLOCK_CHECKSUM_LENGTH);
		}
	}
}
