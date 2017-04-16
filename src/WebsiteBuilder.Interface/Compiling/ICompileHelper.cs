﻿using System;

namespace WebsiteBuilder.Interface.Compiling {
    public interface ICompileHelper {

        IHtmlElement CreateHtmlElement(String name);

        String Compile(IHtmlElement element);

        void CreateCssFile(String css);

        void CreateLessFile(String less);

        String GetFilePath(String targetFileName);

    }
}
