using System;

namespace WebsiteStudio.Interface.Compiling {
	public interface ICompileHelper {

		IHtmlElement CreateHtmlElement(String name);

		String Compile(IHtmlElement element);

		void CreateCssFile(String css);

		void CreateLessFile(String less);

		void CreateJavaScriptFile(String javaScript);

		void CreateJavaScriptFile(String javaScript, bool runAfterLoad);

		String GetFilePath(String targetFileName);

		String CreateSubPage(String pathName, String content);

		void AddPageStyleClass(String className);

		void SetPageFlag(int flag, bool value);

		bool HasPageFlag(int flag);

		void RequireLibrary(Library library);

	}
}
