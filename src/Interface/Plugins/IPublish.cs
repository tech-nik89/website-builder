using System;

namespace WebsiteBuilder.Interface.Plugins {
	public interface IPublish : IPlugin {

		void Run(String data);

	}
}
