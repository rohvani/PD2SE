using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/*
GameSave struct is as follows:

struct GameSave
{
	int	VERSION
	Block header
	Block gamedata
	Block footer
	byte[16] Padding
	byte[16] Special MD5
}

where Block has the following structure:

struct Block
{
	int	SIZE
	int	VERSION
	byte[size - 16] data
	byte[16] MD5(data)
}

The gamedata block appears to contain a serialized dictionary
*/

namespace PD2.GameSave
{
	public class SaveFile
	{
		private const int SAVE_VERSION = 10; // BETA = 9, RETAIL = 10

		private String filePath;

		private DataBlock header;
		private GameDataBlock gamedata;
		private DataBlock footer;

		public Dictionary<Object, Object> GameData
		{
			get { return gamedata.Dictionary; }
			set { gamedata.Dictionary = value; }
		}

		public SaveFile(String filePath, bool encrypted = true)
		{
			this.filePath = filePath;

			byte[] file = File.ReadAllBytes(filePath);
			byte[] data = encrypted ? Encryption.TransformData(file) : file;
			
			// Open save to process
			BinaryReader br = new BinaryReader(new MemoryStream(data));
			
			// Validate that file is a supported save format
			int version = br.ReadInt32();
			if (version != SAVE_VERSION)
				throw new Exception(String.Format("Unsupported save version: {0}", version.ToString("X4")));

			// Process blocks
			this.header = new DataBlock(br);
			this.gamedata = new GameDataBlock(br);
			this.footer = new DataBlock(br);

			// We're done with our reader
			br.Close();
		}

		public void Save()
		{
			this.Save(filePath);
		}

		public void Save(String filePath, bool encrypt = true)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			// Rebuild save
			bw.Write(SAVE_VERSION);
			bw.Write(header.ToArray());
			bw.Write(gamedata.ToArray());
			bw.Write(footer.ToArray());
			bw.Write(new byte[16]);
			bw.Write(Encryption.GenerateSaveHash(ms.ToArray()));

			// Store save and close streams
			byte[] data = ms.ToArray();
			bw.Close();
			ms.Close();

			// Encrypt if requested
			if (encrypt) data = Encryption.TransformData(data);
			File.WriteAllBytes(filePath, data);
		}
	}
}