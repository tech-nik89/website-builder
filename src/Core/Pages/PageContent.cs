using System;
using System.IO;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Pages {

	public class PageContent {

		public String Id { get; internal set; }
		
		public Page Page { get; internal set; }
		
		public Type EditorType { get; set; }
		
		public Type ModuleType { get; set; }

		internal PageContent(Page page)
			: this(Utilities.NewGuid(), page) {
		}

		internal PageContent(String id, Page page) {
			Id = id;
			Page = page;
		}
		
		private String GetFileName(Language language) {
			return String.Format("{0}_{1}_{2}.wbd", Page.Id, Id, language.Id);
		}

		public FileInfo GetFile(Language language) {
			String fileName = GetFileName(language);
			String path = Path.Combine(Page.Project.ProjectContentDirectory.FullName, fileName);

			FileInfo fileInfo = new FileInfo(path);
			fileInfo.Directory.Create();
			return fileInfo;
		}

		public String LoadData(Language language) {
			FileInfo file = GetFile(language);

			if (!file.Exists) {
				return String.Empty;
			}

			return File.ReadAllText(file.FullName);
		}

		public void WriteData(Language language, String data) {
			FileInfo file = GetFile(language);
			File.WriteAllText(file.FullName, data);
		}
	}
}
