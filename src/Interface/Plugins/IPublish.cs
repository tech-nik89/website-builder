using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebsiteStudio.Interface.Compiling;

namespace WebsiteStudio.Interface.Plugins {
	public interface IPublish : IPlugin {

		void Run(String outputhPath, String data);

		void Run(String outputhPath, String data, IProgress<String> progress);

		Task RunAsync(String outputPath, String data);

		Task RunAsync(String outputPath, String data, IProgress<String> progress);

		IEnumerable<CompilerMessage> Messages { get; }

		bool Error { get; }

	}
}
