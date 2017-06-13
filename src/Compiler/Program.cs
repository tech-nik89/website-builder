using CommandLine;
using System;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;

namespace WebsiteBuilder.CompilerConsole {
	class Program {
		static void Main(string[] args) {

			Options options = new Options();

			if (!Parser.Default.ParseArguments(args, options)) {
				Console.WriteLine(options.GetUsage());
				return;
			}

			try {
				Project project = Project.Load(options.ProjectFile);
				Compiler compiler = new Compiler(project);

				compiler.Completed += (sender, e) => {

				};

				compiler.ProgressChanged += (sender, e) => {

				};

				compiler.StartAsync();
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}
	}
}
