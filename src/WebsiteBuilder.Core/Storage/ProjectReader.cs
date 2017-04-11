using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;

namespace WebsiteBuilder.Core.Storage {
    class ProjectReader : IDisposable {

        private readonly FileInfo _File;

        private readonly Project _Project;

        public ProjectReader(String path) {
            _File = new FileInfo(path);
            _Project = new Project();
        }

        public Project Read() {
            String xml = File.ReadAllText(_File.FullName);
            XDocument document = XDocument.Parse(xml);
            XElement root = document.Element("project");

            GetSettings(root.Element("settings"));
            GetLanguages(root.Element("languages"));
            GetMedia(root.Element("media"));

            _Project.Pages.AddRange(GetPages(root.Element("pages")));

            _Project.ProjectFilePath = _File.FullName;

            return _Project;
        }

        private IEnumerable<Page> GetPages(XElement element) {
            return element.Elements("page").Select(x => GetPage(x));
        }

        private Page GetPage(XElement element) {
            Page page = new Page(_Project) {
                Id = element.Attribute("id").Value,
                PathName = element.Attribute("path").Value,
                LayoutClassName = element.Attribute("layout").Value
            };

            page.Pages.AddRange(GetPages(element.Element("pages")));
            GetLocalizedString(element.Element("title"), page.Title);
            GetContent(element.Element("content"), page);

            return page;
        }

        private void GetContent(XElement element, Page page) {
            foreach (XElement item in element.Elements("section")) {
                int index = Convert.ToInt32(item.Attribute("index").Value);
                PageContent content = page[index];
                content.Index = index;
                content.EditorType = PluginManager.GetEditor(item.Attribute("editor").Value);
                content.ModuleType = PluginManager.GetModule(item.Attribute("module").Value);
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
                case "file":
                    return new MediaFile() {
                        Id = element.Attribute("id").Value,
                        FileName = element.Attribute("name").Value,
                        AutoSave = Convert.ToBoolean(element.Attribute("autoSave").Value)
                    };
                case "reference":
                    return new MediaReference() {
                        Id = element.Attribute("id").Value,
                        FilePath = element.Attribute("filePath").Value,
                        AutoSave = Convert.ToBoolean(element.Attribute("autoSave").Value)
                    };
            }

            return null;
        }

        private void GetSettings(XElement element) {
            _Project.AutoCloseCompileDialog = Convert.ToBoolean(element.Element("autoCloseCompileDialog").Value);
            _Project.OutputPath = element.Element("outputPath").Value;
            _Project.ThemePath = element.Element("themePath").Value;
        }

        private void GetLanguages(XElement element) {
            _Project.Languages = element.Elements("language")
                .Select(x => new Language() {
                    Id = x.Attribute("id").Value,
                    Description = x.Value
                })
            .ToArray();
        }

        private void UpdatePageReferences(Project project) {
            foreach(Page page in project.AllPages) {
                page.Project = project;
            }
        }

        public void Dispose() {

        }
    }
}
