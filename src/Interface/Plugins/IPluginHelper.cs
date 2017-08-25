﻿using System;
using System.IO;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;

namespace WebsiteStudio.Interface.Plugins {
	public interface IPluginHelper {

		IEditor CreateEditor();

		IIconPack GetIconPack();

		String GetFullPath(String relativePath);

		String GetRelativePath(String fullPath);

		bool CanSuggestCopyToProjectDirectory(String fullFilePath);

		String NewGuid();

		ILink GetLink();

		DirectoryInfo OutputDirectory { get; }

	}
}
