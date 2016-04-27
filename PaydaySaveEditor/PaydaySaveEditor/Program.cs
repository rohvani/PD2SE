using CommandLine;
using CommandLine.Text;
using PD2.GameSave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PD2
{
	static class Program
	{
		class Options
		{
			[Option('e', "encryptFile", DefaultValue = false, HelpText = "Encrypt save file. Enable this if you are encrypting an already unencrypted file.")]
			public bool EncryptOutput { get; set; }

			[Option('o', "outputPath", DefaultValue = "output.bin", HelpText = "Path to save the processed game save to.")]
			public String OutputPath { get; set; }

			[Option('i', "inputPath", Required = true, HelpText = "Path to the PAYDAY 2 game save that you'd like to process.")]
			public String InputPath { get; set; }

			[HelpOption]
			public string GetUsage()
			{
				return HelpText.AutoBuild(this, (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
			}
		}

		static void Main(String[] args)
		{
			var options = new Options();

			if (CommandLine.Parser.Default.ParseArguments(args, options))
			{
				if(!File.Exists(options.InputPath))
				{
					Console.WriteLine("Input file doesnt exist. Are you sure you typed the filepath right?");
					return;
				}

				try
				{
					SaveFile file = new SaveFile(options.InputPath, !options.EncryptOutput);
					file.Save(options.OutputPath, options.EncryptOutput);
				}
				catch (Exception e) { Console.WriteLine("An unknown error has occured: {0}", e.Message); }
			}
		}
	}
}