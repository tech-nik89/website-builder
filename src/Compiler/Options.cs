using CommandLine;
using System;
using System.Text;

namespace WebsiteBuilder.CompilerConsole {
    class Options {

        [ValueOption(0)]
        public String ProjectFile { get; set; }

        [Option('w', "wait")]
        public bool Wait { get; set; }

        [HelpOption]
        public String GetUsage() {
            StringBuilder usage = new StringBuilder();

            usage.AppendLine("Website Builder Compiler Console");
            usage.AppendLine("--------------------------------");
            usage.AppendLine("Syntax: WebsiteBuilder.Compiler.exe ProjectFile");
            usage.AppendLine();
            usage.AppendLine("     ProjectFile   The full path to the project file to compile.");
            usage.AppendLine("  -w Wait          Wait for user input after the compile has completed.");

            return usage.ToString();
        }

    }
}
