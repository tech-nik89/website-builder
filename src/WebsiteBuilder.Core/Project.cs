using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Storage;
using WebsiteBuilder.Core.Theming;

namespace WebsiteBuilder.Core {

    public class Project : IPage {

        public const String FileExtension = ".wbproj";

        public const String FileIndex = "index.html";

        public String Id => null;

        public IPage Parent => null;

        public bool AutoCloseCompileDialog { get; set; }
        
        public String ProjectFilePath { get; set; }
        
        public String OutputPath { get; set; }
        
        public String ProjectFileName 
            => (ProjectFilePath != null && File.Exists(ProjectFilePath))
            ? Path.GetFileNameWithoutExtension(ProjectFilePath)
            : String.Empty;

        public FileInfo ProjectFile => new FileInfo(ProjectFilePath);

        public DirectoryInfo ProjectContentDirectory => new DirectoryInfo(Path.Combine(ProjectFile.DirectoryName, ProjectFileName));

        public PageCollection Pages { get; private set; }

        public Language[] Languages { get; set; }

        private String _ThemePath;
        
        public String ThemePath {
            get {
                return _ThemePath;
            }
            set {
                _ThemePath = value;
                _Theme = null;
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
        
        public Page StartPage { get; set; }

        public List<MediaItem> Media { get; set; }

        public Project() {
            Pages = new PageCollection(this);
            Languages = new Language[0];
            Media = new List<MediaItem>();
        }

        public void ReloadTheme() {
            _Theme = null;
        }

        public Page CreatePage() {
            return new Page(this) { Id = Guid.NewGuid().ToString() };
        }

        private void FillAllPagesList(PageCollection pages, List<Page> allPages) {
            foreach (Page page in pages) {
                allPages.Add(page);
                FillAllPagesList(page.Pages, allPages);
            }
        }

        public void Save() {
            Save(this, ProjectFilePath);
        }

        public static void Save(Project project, String path) {
            using(ProjectWriter writer = new ProjectWriter(project, path)) {
                writer.Write();
            }
        }

        public static Project Load(string path) {
            using (var reader = new ProjectReader(path)) {
                Project project = reader.Read();
                return project;
            }
        }

    }
}
