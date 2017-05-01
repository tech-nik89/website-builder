using System;

namespace WebsiteBuilder.Interface.Compiling {
    public interface ICompileHelper {

        IHtmlElement CreateHtmlElement(String name);

        String Compile(IHtmlElement element);

        void CreateCssFile(String css);

        void CreateLessFile(String less);

        void CreateJavaScriptFile(String javaScript);

        void CreateJavaScriptFile(String javaScript, bool runAfterLoad);

        String GetFilePath(String targetFileName);

        String CreateSubPage(String pathName, String content);

    }
}
