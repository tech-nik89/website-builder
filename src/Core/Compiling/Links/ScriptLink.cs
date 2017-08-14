using System;

namespace WebsiteStudio.Core.Compiling.Links {
	class ScriptLink {

		public String FileName { get; set; }

		public bool RunAfterLoad { get; set; }

		public ScriptLink(String fileName, bool runAfterLoad) {
			FileName = fileName;
			RunAfterLoad = runAfterLoad;
		}

	}
}
