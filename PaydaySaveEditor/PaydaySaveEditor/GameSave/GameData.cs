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
			Empty = 0x03,
			Byte = 0x04,
			Short = 0x05,
			Bool = 0x06,
			Dictionary = 0x07
		}

		public static byte[] SerializeData(Object obj)
		{
			MemoryStream ms = new MemoryStream();
			BinaryWriter bw = new BinaryWriter(ms);

			if (obj is String)
			{
				bw.Write((byte)DataType.String);
				bw.Write(ASCIIEncoding.ASCII.GetBytes((String)obj));
				bw.Write((byte)0x00);
			}
			else if (obj is UnencodedString)
			{
				bw.Write((byte)DataType.String);
				bw.Write(Encryption.EncodeString(((UnencodedString)obj).Value));
				bw.Write((byte)0x00);
			}
			else if (obj is Single)
			{
				bw.Write((byte)DataType.Float);
				bw.Write((Single)obj);
			}
			else if (obj is Byte)
			{
				bw.Write((byte)DataType.Byte);
				bw.Write((Byte)obj);
			}
			else if (obj is Int16)
			{
				bw.Write((byte)DataType.Short);
				bw.Write((Int16)obj);
			}
			else if (obj is Boolean)
			{
				bw.Write((byte)DataType.Bool);
				bw.Write((Boolean)obj);
			}
			else if (obj is Dictionary<Object, Object>)
			{
				Dictionary<Object, Object> dictionary = (Dictionary<Object, Object>)obj;

				bw.Write((byte)DataType.Dictionary);
				bw.Write(dictionary.Count);

				foreach (var p in dictionary)
				{
					bw.Write(SerializeData(p.Key));
					bw.Write(SerializeData(p.Value));
				}
			}
			else
			{
				bw.Write((byte) DataType.Empty);
			}

			return ms.ToArray();
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

				case DataType.Empty:
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

		private static Object ReadCString(BinaryReader br)
		{
			List<byte> bytes = new List<byte>();

			// Read our string bytes into list
			byte c;
			while ((c = br.ReadByte()) != 0x00) bytes.Add(c);

			// String might be encoded so we must check for this
			byte[] data = bytes.ToArray();
			UnencodedString es = Encryption.UnencodeString(data);

			// Return result
			return (es != null) ? es : (Object) ASCIIEncoding.ASCII.GetString(data);
		}
	}
}
