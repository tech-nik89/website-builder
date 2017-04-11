using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Tools {
    static class Utilities {

        public static readonly ICompiler JavaScriptMinifier = new MicrosoftMinifier(MicrosoftMinifier.Mode.JavaScript);

		public static readonly ICompiler CssMinifier = new MicrosoftMinifier(MicrosoftMinifier.Mode.CSS);

		public static readonly ICompiler LessCompiler = new DotLessCompiler();

    }
}
