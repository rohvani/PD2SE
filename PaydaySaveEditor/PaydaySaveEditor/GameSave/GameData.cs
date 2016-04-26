using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PD2.GameSave
{
	public class GameData
	{
		private enum DataType : byte
		{
			String = 0x01,
			Float = 0x02,
			Unknown = 0x03,
			Byte = 0x04,
			Short = 0x05,
			Bool = 0x06,
			Dictionary = 0x07
		}

		public static byte[] SerializeData(Dictionary<Object, Object> dictionary)
		{
			return null;
		}

		public static Object DeserializeData(BinaryReader br)
		{
			byte dataType = br.ReadByte();

			switch ((DataType) dataType)
			{
				case DataType.String:
					return ReadCString(br);

				case DataType.Float:
					return br.ReadSingle();

				case DataType.Unknown:
					return null;

				case DataType.Byte:
					return br.ReadByte();

				case DataType.Short:
					return br.ReadInt16();

				case DataType.Bool:
					return br.ReadBoolean();

				case DataType.Dictionary:
					return ReadDictionary(br);
			}

			return null;
		}

		private static Dictionary<Object, Object> ReadDictionary(BinaryReader br)
		{
			int nodes = br.ReadInt32();
			Dictionary<Object, Object> dictionary = new Dictionary<object, object>();

			for (int i = 0; i < nodes; i++)
			{
				object key = DeserializeData(br);
				object value = DeserializeData(br);
				dictionary.Add(key, value);
			}

			return dictionary;
		}

		private static String ReadCString(BinaryReader br)
		{
			StringBuilder sb = new StringBuilder();

			byte c;
			while((c = br.ReadByte()) != 0x00) sb.Append((char) c);

			return sb.ToString();
		}
	}
}
