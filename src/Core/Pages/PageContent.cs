using System;
using System.Collections.Generic;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core.Pages {

	public class PageContent {

		public String Id { get; internal set; }
		
		public Page Page { get; internal set; }
		
		public Type EditorType { get; set; }
		
		public Type ModuleType { get; set; }

		private readonly Dictionary<String, String> _Data;

		internal PageContent(Page page)
			: this(Utilities.NewGuid(), page) {
		}

		internal PageContent(String id, Page page) {
			Id = id;
			Page = page;
			_Data = new Dictionary<String, String>();
		}
		
		public String LoadData(Language language) {
			String data;

			if (_Data.TryGetValue(language.Id, out data)) {
				return data;
			}

			return String.Empty;
		}

		public void WriteData(Language language, String data) {
			Page.Project.Dirty = !_Data.ContainsKey(language.Id) || !_Data[language.Id].Equals(data);
			_Data[language.Id] = data;
		}
	}
}
