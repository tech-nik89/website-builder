using System;
using System.Threading.Tasks;

namespace WebsiteBuilder.Interface.Plugins {
	public interface IPublish : IPlugin {

		void Run(String outputhPath, String data);

		void Run(String outputhPath, String data, IProgress<String> progress);

		Task RunAsync(String outputPath, String data);

		Task RunAsync(String outputPath, String data, IProgress<String> progress);

	}
}
