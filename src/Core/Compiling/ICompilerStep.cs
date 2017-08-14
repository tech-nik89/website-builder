using System;

namespace WebsiteStudio.Core.Compiling {
	interface ICompilerStep {

		void Run();

		String Output { get; }

	}
}
