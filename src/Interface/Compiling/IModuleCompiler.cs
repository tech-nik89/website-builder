using System;

namespace WebsiteStudio.Interface.Compiling {
	public interface IModuleCompiler {

		String Compile(String source, ICompileHelper compileHelper);

		String Compile(String source, ICompileHelper compileHelper, bool preview);

	}
}
