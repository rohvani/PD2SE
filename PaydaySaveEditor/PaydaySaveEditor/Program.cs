using PD2.GameSave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PD2
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(String[] args)
		{
			SaveFile save = new SaveFile(args[0]);

			// for debugging, we don't want to encrypt save
			//save.Save("dec.bin", false);

			var data = save.GameData;
			Print(data);

			Console.Read();
		}

		private static void Print(Dictionary<object, object> data)
		{
			foreach (KeyValuePair<Object, Object> kvp in data)
			{
				if (kvp.Value is Dictionary<Object, Object>) 
					Print((Dictionary<Object, Object>) kvp.Value);
				try
				{
					Console.WriteLine("{0}: {1}", kvp.Key.ToString(), kvp.Value.ToString());
				}
				catch(Exception e) { }
			}
		}
	}
}