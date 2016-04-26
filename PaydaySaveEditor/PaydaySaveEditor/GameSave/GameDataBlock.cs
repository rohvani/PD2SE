using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PD2.GameSave
{
	public class GameDataBlock : DataBlock
	{
		private enum StructureType : byte
        {
            String = 0x01,
            Float = 0x02,
            Unknown = 0x03,
            Byte = 0x04,
            Short = 0x05,
            Bool = 0x06,
            Dictionary = 0x07
        }

		public Dictionary<Object, Object> Dictionary { get; set; }

		public GameDataBlock(BinaryReader br) : base(br)
		{
			BinaryReader dataBr = new BinaryReader(new MemoryStream(data));
			this.Dictionary = DeserializeDictionary(dataBr);
		}

		public override byte[] ToArray()
		{
			this.data = SerializeDictionary();
			return base.ToArray();
		}

		private byte[] SerializeDictionary()
		{
			return null;
		}

		private static Dictionary<Object, Object> DeserializeDictionary(BinaryReader br)
		{
			return null;
		}
	}
}