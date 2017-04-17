using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Storage {
    class ProjectReader : IDisposable {

        private readonly FileInfo _File;

        private readonly Project _Project;

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

                _Project.Pages.AddRange(GetPages(root.Element(ProjectStorageConstants.Pages)));

                GetSettings(root.Element(ProjectStorageConstants.Settings));

                return _Project;
            }
            catch {
                return null;
            }
        }

        private IEnumerable<Page> GetPages(XElement element) {
            return element.Elements(ProjectStorageConstants.Page).Select(x => GetPage(x));
        }

        private Page GetPage(XElement element) {
            Page page = new Page(_Project) {
                Id = element.Attribute(ProjectStorageConstants.Id).Value,
                PathName = element.Attribute(ProjectStorageConstants.Path).Value,
                LayoutClassName = element.Attribute(ProjectStorageConstants.Layout).Value
            };

            page.Pages.AddRange(GetPages(element.Element(ProjectStorageConstants.Pages)));
            GetLocalizedString(element.Element(ProjectStorageConstants.Title), page.Title);
            GetContent(element.Element(ProjectStorageConstants.Content), page);

            return page;
        }

        private void GetContent(XElement element, Page page) {
            foreach (XElement item in element.Elements(ProjectStorageConstants.Section)) {
                int index = Convert.ToInt32(item.Attribute(ProjectStorageConstants.Index).Value);
                PageContent content = page[index];
                content.Index = index;
                content.EditorType = PluginManager.GetEditor(item.Attribute(ProjectStorageConstants.Editor).Value);
                content.ModuleType = PluginManager.GetModule(item.Attribute(ProjectStorageConstants.Module).Value);
            }
        }

        private void GetLocalizedString(XElement element, LocalizedString str) {
            foreach (XElement item in element.Elements()) {
                str.Set(item.Name.ToString(), item.Value);
            }
        }

        private void GetMedia(XElement element) {
            _Project.Media.AddRange(element.Elements().Select(x => GetMediaItem(x)));
        }

        private MediaItem GetMediaItem(XElement element) {
            switch (element.Name.ToString()) {
                case ProjectStorageConstants.File:
                    return new MediaFile() {
                        Id = element.Attribute(ProjectStorageConstants.Id).Value,
                        FileName = element.Attribute(ProjectStorageConstants.Name).Value,
                        AutoSave = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.AutoSave).Value)
                    };
                case ProjectStorageConstants.Reference:
                    return new MediaReference() {
                        Id = element.Attribute(ProjectStorageConstants.Id).Value,
                        FilePath = GetFullPath(element.Attribute(ProjectStorageConstants.Path).Value),
                        AutoSave = Convert.ToBoolean(element.Attribute(ProjectStorageConstants.AutoSave).Value)
                    };
            }

            return null;
        }

        private void GetSettings(XElement element) {
            _Project.OutputPath = GetFullPath(element.Element(ProjectStorageConstants.OutputPath).Value);
            _Project.ThemePath = GetFullPath(element.Element(ProjectStorageConstants.ThemePath).Value);

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
