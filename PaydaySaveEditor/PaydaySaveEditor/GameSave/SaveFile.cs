using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*

Game save format is a series of blocks, 
where Block has following structure:

struct Block
{
	int				VERSION
	int				SIZE
	byte[size - 16] data
	byte[16]		MD5(data)
}

Each block's data seems to be a serialized map

*/

namespace PD2.GameSave
{
	public class SaveFile
	{
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
