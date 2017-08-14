﻿using System;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Modules.StaticPage {

	[PluginInfo("Static Page", Author = "tech-nik89")]
	public class StaticPageModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		public StaticPageModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper helper) {
			IEditor editor = _PluginHelper.CreateEditor();
			return editor.Compile(source);
		}

		public IUserInterface GetUserInterface() {
			return new StaticPageControl(_PluginHelper);
		}
	}
}
