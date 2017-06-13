using System;

namespace WebsiteBuilder.Core.Compiling {
	interface ICompilerStep {

		void Run();

		String Output { get; }

	}
}
