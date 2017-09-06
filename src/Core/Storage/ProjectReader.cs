using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WebsiteStudio.Core.Footer;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Core.Publishing;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core.Storage {
	class ProjectReader : IDisposable {

		private readonly FileInfo _File;

		private readonly Project _Project;

		public Exception Exception { get; private set; }

		private readonly Encoding _Encoding = Encoding.UTF8;

		public ProjectReader(String path) {
			_File = new FileInfo(path);
			_Project = new Project();
		}

		public Project Read() {
			try {
				_Project.ProjectFilePath = _File.FullName;

				String xml = File.ReadAllText(_File.FullName);
				XDocument document = XDocument.Parse(xml);
				XElement root = document.Element(ProjectStorageConstants.Root);
				
				GetLanguages(root.Element(ProjectStorageConstants.Languages));
				GetMedia(root.Element(ProjectStorageConstants.Media));
				GetPublishing(root.Element(ProjectStorageConstants.Publishing));

				_Project.Pages.AddRange(GetPages(root.Element(ProjectStorageConstants.Pages)));
				_Project.Footer.AddRange(GetFooter(root.Element(ProjectStorageConstants.Footer)));

				GetSettings(root.Element(ProjectStorageConstants.Settings));

				_Project.Dirty = false;
				return _Project;
			}
			catch (Exception e) {
				Exception = e;
				return null;
			}
		}

		private void GetPublishing(XElement element) {
			if (element == null) {
				return;
			}

			var items = element.Elements(ProjectStorageConstants.Item).Select(x => new PublishItem() {
				Name = x.Attribute(ProjectStorageConstants.Name)?.Value ?? String.Empty,
				Type = PluginManager.GetPublisher(x.Attribute(ProjectStorageConstants.Type).Value),
				Data = x.Value
			});

			_Project.Publishing.AddRange(items);
		}

		private IEnumerable<FooterSection> GetFooter(XElement element) {
			List<FooterSection> sections = new List<FooterSection>();
			if (element == null) {
				return sections;
			}

			sections.AddRange(element.Elements(ProjectStorageConstants.Section).Select(x => GetFooterSection(x)));
			return sections;
		}

		private FooterSection GetFooterSection(XElement element) {
			FooterSection section = _Project.CreateFooterSection();

			GetLocalizedString(element.Element(ProjectStorageConstants.Title), section.Title);
			section.Items = new CustomCollection<FooterLink>(_Project);
			section.Items.AddRange(element.Elements(ProjectStorageConstants.Link).Select(x => GetFooterLink(x)));

			return section;
		}

		private FooterLink GetFooterLink(XElement element) {
			FooterLink link = _Project.CreateFooterLink();

			GetLocalizedString(element, link.Text);

			link.Data = element.Attribute(ProjectStorageConstants.Data)?.Value;
			link.Target = element.Attribute(ProjectStorageConstants.Target)?.Value;

			FooterLinkType type = FooterLinkType.External;
			Enum.TryParse(element.Attribute(ProjectStorageConstants.Type)?.Value ?? String.Empty, out type);
			link.Type = type;

			return link;
		}

		private IEnumerable<Page> GetPages(XElement element) {
			return element.Elements(ProjectStorageConstants.Page).Select(x => GetPage(x));
		}

		private Page GetPage(XElement element) {
			Page page = new Page(_Project);

			page.Id = element.Attribute(ProjectStorageConstants.Id).Value;
			page.PathName = element.Attribute(ProjectStorageConstants.Path).Value;
			page.IncludeInMenu = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.IncludeInMenu)?.Value);
			page.Disable = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.Disable)?.Value);
			page.RobotsNoFollow = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.RobotsNoFollow)?.Value);
			page.RobotsNoIndex = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.RobotsNoIndex)?.Value);

			PageChangeFrequency changeFrequency;
			if (Enum.TryParse(element.Attribute(ProjectStorageConstants.ChangeFrequency)?.Value, out changeFrequency)) {
				page.ChangeFrequency = changeFrequency;
			}

			DateTime lastModified;
			if (DateTime.TryParse(element.Attribute(ProjectStorageConstants.LastModified)?.Value, out lastModified)) {
				page.LastModified = lastModified;
			}

			page.Pages.AddRange(GetPages(element.Element(ProjectStorageConstants.Pages)));
			GetLocalizedString(element.Element(ProjectStorageConstants.Title), page.Title);
			GetLocalizedString(element.Element(ProjectStorageConstants.MetaDescription), page.MetaDescription);
			GetLocalizedStringArray(element.Element(ProjectStorageConstants.MetaKeywords), page.MetaKeywords);
			GetPageLink(element.Element(ProjectStorageConstants.Link), page);
			GetContent(element.Element(ProjectStorageConstants.Content), page);

			return page;
		}

		private void GetPageLink(XElement element, Page page) {
			if (element == null) {
				return;
			}

			PageLinkType type = PageLinkType.None;
			Enum.TryParse(element.Attribute(ProjectStorageConstants.Type)?.Value, out type);

			page.LinkType = type;
			page.LinkTarget = element.Attribute(ProjectStorageConstants.Target)?.Value;
		}

		private void GetContent(XElement element, Page page) {
			int index = 0;

			foreach (XElement item in element.Elements(ProjectStorageConstants.Section)) {
				String id = item.Attribute(ProjectStorageConstants.Id)?.Value ?? index.ToString();
				PageContent content = page.AddContent(index, id);
				content.EditorType = PluginManager.GetEditor(item.Attribute(ProjectStorageConstants.Editor).Value);
				content.ModuleType = PluginManager.GetModule(item.Attribute(ProjectStorageConstants.Module).Value);
				GetContentData(item, content);

				index++;
			}
		}

		private void GetContentData(XElement item, PageContent data) {
			foreach (XElement element in item.Elements(ProjectStorageConstants.Data)) {
				Language language = _Project.Languages.FirstOrDefault(x => x.Id == element.Attribute(ProjectStorageConstants.Language)?.Value);
				if(language == null) {
					continue;
				}

				Byte[] buffer = Convert.FromBase64String(element.Value);
				data.WriteData(language, _Encoding.GetString(buffer));
			}
		}

		private void GetLocalizedString(XElement element, LocalizedString str) {
			if (element == null) {
				return;
			}

			foreach (XElement item in element.Elements()) {
				str.Set(item.Name.ToString(), item.Value);
			}
		}

		private void GetLocalizedStringArray(XElement element, LocalizedStringArray str) {
			if (element == null) {
				return;
			}

			foreach (XElement item in element.Elements()) {
				str.Set(item.Name.ToString(), item.Elements(ProjectStorageConstants.Item).Select(x => x.Value).ToArray());
			}
		}

		private void GetMedia(XElement element) {
			_Project.Media.AddRange(element.Elements().Select(x => GetMediaItem(x)));
		}

		private MediaItem GetMediaItem(XElement element) {
			switch (element.Name.ToString()) {
				case ProjectStorageConstants.File:
					MediaFile mediaFile = _Project.CreateMediaFile();
					mediaFile.Id = element.Attribute(ProjectStorageConstants.Id).Value;
					mediaFile.FileName = element.Attribute(ProjectStorageConstants.Name).Value;
					mediaFile.AutoSave = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.AutoSave).Value);
					mediaFile.Data = Convert.FromBase64String(element.Value);
					return mediaFile;

				case ProjectStorageConstants.Reference:
					MediaReference mediaReference = _Project.CreateMediaReference();
					mediaReference.Id = element.Attribute(ProjectStorageConstants.Id).Value;
					mediaReference.FilePath = GetFullPath(element.Attribute(ProjectStorageConstants.Path).Value);
					mediaReference.AutoSave = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.AutoSave).Value);
					return mediaReference;
			}

			return null;
		}

		private void GetSettings(XElement element) {
			_Project.OutputPath = GetFullPath(element.Element(ProjectStorageConstants.OutputPath).Value);
			_Project.ThemePath = GetFullPath(element.Element(ProjectStorageConstants.ThemePath).Value);
			_Project.UglyURLs = Convert.ToBoolean(element.Element(ProjectStorageConstants.UglyURLs)?.Value);
			_Project.Webserver = PluginManager.GetWebserver(element.Element(ProjectStorageConstants.Webserver)?.Value);
			_Project.BaseURL = element.Element(ProjectStorageConstants.BaseURL)?.Value ?? String.Empty;
			_Project.GenerateSitemap = Convert.ToBoolean(element.Element(ProjectStorageConstants.Sitemap)?.Value);
			_Project.SSLRedirect = Convert.ToBoolean(element.Element(ProjectStorageConstants.SSLRedirect)?.Value);

			GetLocalizedString(element.Element(ProjectStorageConstants.MetaDescription), _Project.MetaDescription);
			GetLocalizedStringArray(element.Element(ProjectStorageConstants.MetaKeywords), _Project.MetaKeywords);

			String startPageId = element.Element(ProjectStorageConstants.StartPage)?.Value ?? String.Empty;
			if (!String.IsNullOrWhiteSpace(startPageId)) {
				_Project.StartPage = _Project.AllPages.SingleOrDefault(x => x.Id == startPageId);
			}
		}

		private void GetLanguages(XElement element) {
			_Project.Languages = element.Elements(ProjectStorageConstants.Language)
				.Select(x => new Language() {
					Id = x.Attribute(ProjectStorageConstants.Id).Value,
					Description = x.Value
				})
			.ToArray();
		}

		private void UpdatePageReferences(Project project) {
			foreach(Page page in project.AllPages) {
				page.Project = project;
			}
		}

		private String GetFullPath(String relativePath) {
			return Utilities.RelativeToFullPath(relativePath, _Project);
		}

		public void Dispose() {

		}
	}
}
