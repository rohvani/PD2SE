using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


/*

GameSave Format is as follows:

	Block: Save
	{
		Block: GameData
		Block: Checksum
	}

where Block =

	struct Block
	{
		int MAGIC
		int SIZE
		byte[size - 16] data
		byte[16] md5(data)
	}

*/

namespace PD2.GameSave
{
	public class SaveFile
	{
		private const int HEADER_MAGIC = 0x0A;

		public SaveFile(String filePath)
		{
			byte[] file = File.ReadAllBytes(filePath);
			byte[] data = GameSave.Encryption.TransformData(file);
			
			// Dump save to binary for debug purposes
			File.WriteAllBytes("dec.bin", data);
			
			// Process save
			BinaryReader br = new BinaryReader(new MemoryStream(data));

			// @TODO: process blocks
			
			// We're done with our reader
			br.Close();
		}
	}
}
