// --------------------------------------------------------------------------------------------
#region // Copyright (c) 2002, SIL International. All Rights Reserved.   
// <copyright from='2002' to='2002' company='SIL International'>
//		Copyright (c) 2002, SIL International. All Rights Reserved.   
//    
//		Distributable under the terms of either the Common Public License or the
//		GNU Lesser General Public License, as specified in the LICENSING.txt file.
// </copyright> 
#endregion
// 
// File: IDLImp.cs
// Responsibility: Eberhard Beilharz
// Last reviewed: 
// 
// <remarks>
// Imports the interfaces of an IDL file.
// </remarks>
// --------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SIL.FieldWorks.Tools
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	/// Imports the interfaces of an IDL file.
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class IDLImpConsole
	{
		private static string[] _args;

		private static void ShowHelp()
		{
			System.Console.WriteLine("\nIDLImporter. Creates .NET interfaces from an IDL file.");
			System.Console.WriteLine("Copyright (c) 2002-2007, SIL International. All Rights Reserved.\n");
			System.Console.WriteLine("Syntax:\n");
			System.Console.WriteLine("{0} [options] file.idl", Path.GetFileName(Application.ExecutablePath));
			System.Console.WriteLine("{0} [options] path", Path.GetFileName(Application.ExecutablePath));
			System.Console.WriteLine();
			System.Console.WriteLine("possible options:");
			System.Console.WriteLine("\t/o outfile\tname of created file (Default: file.cs)");
			System.Console.WriteLine("\t/c configfile\tname of XML configuration file ({0}.xml)",
				Path.GetFileNameWithoutExtension(Application.ExecutablePath));
			System.Console.WriteLine("\t/i idhfile\tname of IDH file for comments (Default: none)");
			System.Console.WriteLine("\t/n namespace\tNamespace of the file to be produced");
			System.Console.WriteLine("\t/u namespace\tadditional using namespaces");
			System.Console.WriteLine("\t/r iipfile\tFile name of .iip file to use to resolve references");
			System.Console.WriteLine("\t/x (0|1)\t1= create, 0= suppress XML comments (Default: 1)");
			System.Console.WriteLine("\t/? \t\tshow this help information");
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// <returns><c>0</c> for success, <c>1</c> for internal error, <c>2</c> for error
		/// in data.</returns>
		/// ------------------------------------------------------------------------------------
		[STAThread]
		public static int Main(string[] args)
		{
			_args = args;
			bool fOk = true;
			try
			{
				if (args.Length < 1 || args.Length == 1 && (args[0] == "/?" || args[0] == "-?"))
				{
					ShowHelp();
					return 0;
				}

				string sFileName = args[args.Length - 1];
				string sDirectory = Directory.Exists(sFileName) ? sFileName : null;
				string sOutFile = null;
				string sXmlFile = null;
				string sNamespace = null;
				// Get all necessary file names
				List<string> usingNamespaces = new List<string>();				
				StringCollection idhFiles = new StringCollection();
				StringCollection refFiles = new StringCollection();
				bool fCreateComments = true;

				for (int i = 0; i < (args.Length - 1) / 2; i++)
				{
					switch (args[i * 2])
					{
						case "/o":
						case "-o":
							sOutFile = args[i * 2 + 1];
							break;
						case "/c":
						case "-c":
							sXmlFile = args[i * 2 + 1];
							break;
						case "/n":
						case "-n":
							sNamespace = args[i * 2 + 1];
							break;
						case "/u":
						case "-u":
							usingNamespaces.Add(args[i * 2 + 1]);
							break;
						case "/?":
						case "-?":
							ShowHelp();
							return 0;
						case "/x":
						case "-x":
							fCreateComments = (args[i * 2 + 1] == "0" ? false : true);
							break;
						case "/i":
						case "-i":
							idhFiles.Add(args[i * 2 + 1]);
							break;
						case "/r":
						case "-r":
							refFiles.Add(args[i * 2 + 1]);
							break;
						default:
							Console.WriteLine("\nWrong parameter: {0}\n", args[i * 2]);
							ShowHelp();
							return 0;
					}
				}

				sXmlFile = sXmlFile ?? Path.ChangeExtension(Application.ExecutablePath, "xml");

				IDLImporter imp = new IDLImporter();
				fOk = true;
				if (sDirectory == null)
				{
					sOutFile = sOutFile ?? Path.ChangeExtension(sFileName, "cs");
					sNamespace = sNamespace ?? Path.GetFileNameWithoutExtension(sFileName);

					Console.WriteLine("Generating {0}...", Path.GetFileName(sOutFile));
					fOk = imp.Import(usingNamespaces, sFileName, sXmlFile, sOutFile, sNamespace,
						idhFiles, refFiles, fCreateComments);
				}
				else
				{
					foreach (string srcFileName in Directory.GetFiles(sDirectory, "*.idl"))
					{
						fOk = OnImport(imp, usingNamespaces, srcFileName, sXmlFile,
							Path.ChangeExtension(srcFileName, "cs"),
							sNamespace ?? Path.GetFileNameWithoutExtension(srcFileName),
							idhFiles, refFiles, fCreateComments);
					}
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine("Internal program error in program {0}", e.Source);
				System.Console.WriteLine("\nDetails:\n{0}\nin method {1}.{2}\nStack trace:\n{3}",
					e.Message, e.TargetSite.DeclaringType.Name, e.TargetSite.Name, e.StackTrace);

				return 1;
			}

			return fOk ? 0 : 2;
		}

		private static bool OnImport(IDLImporter importer, List<string> usingNamespaces, string sFileName,
			string sXmlFile, string sOutFile, string sNamespace, StringCollection idhFiles, StringCollection refFiles, bool fCreateComments)
		{
			Console.WriteLine("Generating {0}...", Path.GetFileName(sOutFile));

			importer.ResolveBaseType += importer_ResolveBaseType;
			bool fOk = importer.Import(usingNamespaces, sFileName, sXmlFile, sOutFile, sNamespace,
				idhFiles, refFiles, fCreateComments);
			importer.ResolveBaseType -= importer_ResolveBaseType;
			return fOk;
		}

		private static void importer_ResolveBaseType(object sender, ResolveBaseTypeEventArgs e)
		{
			var args = new List<string>(_args);
			int last = args.Count - 1;
			args[last] = Path.Combine(args[last], e.TypeName + ".idl");
			if (File.Exists(args[last]))
			{
				var startInfo = new ProcessStartInfo();
				startInfo.FileName = typeof(IDLImpConsole).Assembly.Location;
				startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
				startInfo.Arguments = string.Join(" ", args);
				startInfo.RedirectStandardOutput = true;
				startInfo.UseShellExecute = false;
				using (var process = Process.Start(startInfo))
				{

					process.WaitForExit();
					Console.WriteLine(process.StandardOutput.ReadToEnd());
				}
			}
		}
	}
}
