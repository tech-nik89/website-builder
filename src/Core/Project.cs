using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using WebsiteStudio.Core.Footer;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Publishing;
using WebsiteStudio.Core.Security;
using WebsiteStudio.Core.Storage;
using WebsiteStudio.Core.Theming;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core {

	public class Project : IPage {

		public const String FileExtension = ".wsproj";

		public const String FileIndex = "index.html";

		public const String ContentDirectoryName = "content";

		private bool _UglyURLs;

		public bool UglyURLs {
			get => _UglyURLs;
			set { _UglyURLs = value; Dirty = true; }
		}

		public String Id => null;

		public IPage Parent => null;

		public String PathName => null;

		private String _ProjectFilePath;

		public String ProjectFilePath {
			get => _ProjectFilePath;
			set { _ProjectFilePath = value; Dirty = true; }
		}

		private String _OutputPath;

		public String OutputPath {
			get => _OutputPath;
			set { _OutputPath = value; Dirty = true; }
		}
		
		public String ProjectFileName 
			=> (ProjectFilePath != null && File.Exists(ProjectFilePath))
			? Path.GetFileNameWithoutExtension(ProjectFilePath)
			: String.Empty;

		public FileInfo ProjectFile => new FileInfo(ProjectFilePath);
		
		public PageCollection Pages { get; private set; }

		private Language[] _Languages;

		public Language[] Languages {
			get => _Languages;
			set { _Languages = value; Dirty = true; }
		}

		private String _ThemePath;
		
		public String ThemePath {
			get {
				return _ThemePath;
			}
			set {
				_ThemePath = value;
				_Theme = null;
				Dirty = true;
			}
		}
		
		private Theme _Theme;
		
		public Theme Theme {
			get {
				if (_Theme == null && File.Exists(ThemePath)) {
					try {
						_Theme = Theme.Load(ThemePath);
					}
					catch {
						_Theme = null;
					}
				}

				return _Theme;
			}
		}
		
		public ReadOnlyCollection<Page> AllPages {
			get {
				List<Page> allPages = new List<Page>();
				FillAllPagesList(Pages, allPages);
				return allPages.AsReadOnly();
			}
		}

		private Page _StartPage;

		public Page StartPage {
			get => _StartPage;
			set { _StartPage = value; Dirty = true; }
		}

		public CustomCollection<MediaItem> Media { get; private set; }

		public CustomCollection<FooterSection> Footer { get; private set; }

		public LocalizedString MetaDescription { get; private set; }

		public LocalizedStringArray MetaKeywords { get; private set; }

		public CustomCollection<PublishItem> Publishing { get; private set; }

		public CustomCollection<User> Users { get; private set; }

		public CustomCollection<Group> Groups { get; private set; }

		private byte[] _Favicon;

		public byte[] Favicon {
			get => _Favicon;
			set { _Favicon = value; Dirty = true; }
		}

		public const String FaviconExtension = ".ico";

		private Type _Webserver;

		public Type Webserver {
			get => _Webserver;
			set { _Webserver = value; Dirty = true; }
		}

		public int PageDepth => AllPages.Max(x => x.ParentCount);

		public String BaseURL { get; set; }

		public bool SSLRedirect { get; set; }

		public bool GenerateSitemap { get; set; }

		public bool Dirty { get; internal set; }

		public Project() {
			Pages = new PageCollection(this);
			Languages = new Language[0];
			Media = new CustomCollection<MediaItem>(this);
			Footer = new CustomCollection<FooterSection>(this);
			MetaDescription = new LocalizedString(this);
			MetaKeywords = new LocalizedStringArray(this);
			Publishing = new CustomCollection<PublishItem>(this);
			Users = new CustomCollection<User>(this);
			Groups = new CustomCollection<Group>(this);
			Dirty = false;
		}

		public void ReloadTheme() {
			_Theme = null;
		}

		public Page CreatePage() {
			return new Page(this) { Id = Utilities.NewGuid() };
		}

		public User CreateUser() {
			return new User(this);
		}

		public Group CreateGroup() {
			return new Group(this);
		}

		public FooterLink CreateFooterLink() {
			return new FooterLink(this);
		}

		public FooterSection CreateFooterSection() {
			return new FooterSection(this);
		}

		public MediaFile CreateMediaFile() {
			return new MediaFile(this) { Id = Utilities.NewGuid() };
		}

		public MediaReference CreateMediaReference() {
			return new MediaReference(this) { Id = Utilities.NewGuid() };
		}

		private void FillAllPagesList(PageCollection pages, List<Page> allPages) {
			foreach (Page page in pages) {
				allPages.Add(page);
				FillAllPagesList(page.Pages, allPages);
			}
		}

		public void ValidateAndCleanUpSecurityReferences() {
			List<Group> list = new List<Group>();

			foreach(User user in Users) {
				list.Clear();

				foreach(Group group in user.Memberships) {
					if (!Groups.Contains(group)) {
						list.Add(group);
					}
				}

				user.Memberships.RemoveRange(list);
			}

			foreach(Page page in AllPages) {
				list.Clear();

				foreach(Group group in page.AllowedGroups) {
					if (!Groups.Contains(group)) {
						list.Add(group);
					}
				}

				page.AllowedGroups.RemoveRange(list);
			}
		}

		public void Save() {
			Save(this, ProjectFilePath);
		}

		public static void Save(Project project, String path) {
			if (project == null) {
				return;
			}

			using (ProjectWriter writer = new ProjectWriter(project, path)) {
				writer.Write();
				project.Dirty = false;
			}
		}

		public static Project Load(String path) {
			using (var reader = new ProjectReader(path)) {
				Project project = reader.Read();

				if (project == null) {
					throw reader.Exception ?? new Exception();
				}

				return project;
			}
		}
	}
}
