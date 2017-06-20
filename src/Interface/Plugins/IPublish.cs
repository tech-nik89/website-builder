using System;
using System.Threading.Tasks;

namespace WebsiteBuilder.Interface.Plugins {
	public interface IPublish : IPlugin {

		void Run(String outputhPath, String data);

		Task RunAsync(String outputPath, String data);

	}
}
