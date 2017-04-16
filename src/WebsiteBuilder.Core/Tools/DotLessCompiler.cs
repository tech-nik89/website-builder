using dotless.Core;
using dotless.Core.configuration;
using System;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Tools {
    class DotLessCompiler : ICompiler {

		private static readonly DotlessConfiguration _Config = new DotlessConfiguration() {
			MinifyOutput = false,
			Web = false,
			CacheEnabled = false,
			SessionMode = DotlessSessionStateMode.Disabled,
			LogLevel = dotless.Core.Loggers.LogLevel.Debug
		};

		public String Compile(String source) {
			String css = LessWeb.Parse(source, _Config);
			return css;
		}

	}
}
