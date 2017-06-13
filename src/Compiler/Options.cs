using CommandLine;
using System;
using System.Text;

namespace WebsiteBuilder.CompilerConsole {
	class Options {
		
		[ValueOption(0)]
		public String ProjectFile { get; set; }

		[HelpOption]
		public String GetUsage() {
			StringBuilder usage = new StringBuilder();

			usage.AppendLine("Website Builder Compiler Console");

			return usage.ToString();
		}

	}
}
