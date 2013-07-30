using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace PaydaySaveEditor
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		byte[] xorKey = { 0x5E, 0x2E, 0x23, 0x56, 0x25, 0x33, 0x34, 0x39, 0x35, 0x32, 0xF3, 0x32, 0x64, 0xB4, 0x33, 0x25, 0xA4, 0x48, 0xA4, 0x64, 0x32, 0x63, 0x32, 0x63, 0x20, 0x6C, 0x4D, 0x3C };
		MemoryStream saveFileStream = new MemoryStream();

		private void encryptedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileStream != null && saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					MemoryStream ms = new MemoryStream();
					saveFileStream.Position = 0;
					saveFileStream.WriteTo(ms);

					ms.SetLength(ms.Length - 16);
					ms.Position = 0;

					byte[] md5 = MD5.Create().ComputeHash(ms);
					ms.SetLength(ms.Length + 16);

					ms.Seek(ms.Length - 16, SeekOrigin.Begin);
					ms.Write(md5, 0, 16);

					Stream file = File.Create(saveFileDialog.FileName);
					ms.Position = 0;
					transformTest(ms, file);

					file.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void decryptedToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (saveFileStream != null && saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					MemoryStream ms = new MemoryStream();
					saveFileStream.Position = 0;
					saveFileStream.WriteTo(ms);

					Stream file = File.Create(saveFileDialog.FileName);

					ms.Position = 0;
					ms.CopyTo(file);

					file.Close();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void encryptedToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (openSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((openSaveFileDialog.OpenFile()) != null)
					{
						using (FileStream fileStream = File.OpenRead(openSaveFileDialog.FileName))
						{

							MemoryStream ms = new MemoryStream();
							transformTest(fileStream, saveFileStream);

							saveFileStream.Position = 0;

							Stream file = File.Create("temp_decrypted.dat");
							saveFileStream.WriteTo(file);
							file.Close();

							saveFileStream.Position = 0;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void decryptedToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			if (openSaveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if ((openSaveFileDialog.OpenFile()) != null)
					{
						using (FileStream fileStream = File.OpenRead(openSaveFileDialog.FileName))
						{
							MemoryStream ms = new MemoryStream();

							fileStream.CopyTo(saveFileStream);

							saveFileStream.Position = 0;

							Stream file = File.Create("temp_decrypted.dat");
							saveFileStream.WriteTo(file);
							file.Close();

							saveFileStream.Position = 0;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}
		
		public void transformTest(Stream input, Stream output)
		{
			byte[] data = new byte[input.Length];
			input.Read(data, 0, data.Length);

			int xorOffset;

			for (int i = 0; i < data.Length; i++)
			{
				xorOffset = (i % xorKey.Length);
				data[i] ^= xorKey[xorOffset];
			}

			output.Write(data, 0, data.Length);
		}
	}
}
