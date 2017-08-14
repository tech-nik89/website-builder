using System;

namespace WebsiteStudio.Interface.Compiling {
	public interface IModuleCompiler {

		String Compile(String source, ICompileHelper compileHelper);

	}
}
