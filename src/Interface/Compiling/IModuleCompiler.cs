using System;

namespace WebsiteBuilder.Interface.Compiling {
	public interface IModuleCompiler {

		String Compile(String source, ICompileHelper compileHelper);

	}
}
