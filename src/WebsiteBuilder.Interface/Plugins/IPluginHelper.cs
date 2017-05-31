using System;
using WebsiteBuilder.Interface.Icons;

namespace WebsiteBuilder.Interface.Plugins {
    public interface IPluginHelper {

        IEditor CreateEditor();

        IIconPack GetIconPack();

        String GetFullPath(String relativePath);

        String GetRelativePath(String fullPath);

        bool CanSuggestCopyToProjectDirectory(String fullFilePath);

        String NewGuid();

        String GetLink();

    }
}
