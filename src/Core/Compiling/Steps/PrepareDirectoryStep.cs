using System;
using System.IO;

namespace WebsiteStudio.Core.Compiling.Steps {
	class PrepareDirectoryStep : ICompilerStep {

		private readonly DirectoryInfo _Directory;

		public String Output { get; private set; }

		public PrepareDirectoryStep(DirectoryInfo directory) {
			_Directory = directory;
			Output = String.Format("Preparing directory: {0}", _Directory.FullName);
		}

		public void Run() {
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
