using System;
using System.IO;

namespace WebsiteStudio.Core.Compiling.Steps {
	class PrepareDirectoryStep : CompilerStep {

		private readonly DirectoryInfo _Directory;
		
		public PrepareDirectoryStep(DirectoryInfo directory)
			: base(String.Format("Preparing directory: {0}", directory.FullName)) {

			_Directory = directory;
		}

		public override void Run() {
			if (!_Directory.Exists) {
				_Directory.Create();
				return;
			}

			foreach (FileInfo file in _Directory.GetFiles()) {
				file.Delete();
			}

			foreach (DirectoryInfo dir in _Directory.GetDirectories()) {
				dir.Delete(true);
			}
		}

	}
}
