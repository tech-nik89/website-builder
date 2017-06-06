using CommandLine;
using System;
using System.IO;
using System.Text;
using System.Threading;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;
using WebsiteBuilder.Core.Plugins;

namespace WebsiteBuilder.CompilerConsole {
    class Program {
        static void Main(string[] args) {

            Options options = new Options();

            if (!Parser.Default.ParseArguments(args, options)) {
                Console.WriteLine(options.GetUsage());
                return;
            }

            if (String.IsNullOrWhiteSpace(options.ProjectFile)
                || !File.Exists(options.ProjectFile)) {

                Console.WriteLine(options.GetUsage());
                return;
            }

            try {
                PluginManager.Init();

                Project project = Project.Load(options.ProjectFile);
                Compiler compiler = new Compiler(project);
                AutoResetEvent wait = new AutoResetEvent(false);

                compiler.Completed += (sender, e) => {
                    wait.Set();
                };

                compiler.ProgressChanged += (sender, e) => {
                    StringBuilder message = new StringBuilder();

                    message.Append(e.Percentage.ToString().PadRight(3));
                    message.Append("% ");
                    message.Append(e.Message);

                    Console.WriteLine(message.ToString());
                };

                compiler.StartAsync();
                wait.WaitOne();
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            if (options.Wait) {
                Console.WriteLine();
                Console.WriteLine("Press any key to exit ...");
                Console.ReadLine();
            }
        }
    }
}
