using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;

namespace WebsiteBuilder.Core.Storage {
    class ProjectWriter : IDisposable {

        private readonly Project _Project;

        private readonly FileInfo _File;

        public ProjectWriter(Project project, String path) {
            _Project = project;
            _File = new FileInfo(path);
        }

        public void Write() {
            XDocument document = new XDocument(
                new XElement("project",
                    GetSettings(),
                    GetLanguages(),
                    GetMedia(),
                    GetPages(_Project.Pages)
                )
            );

            String xml = document.ToString();
            File.WriteAllText(_File.FullName, xml);
        }

        private XElement GetLanguages() {
            return new XElement("languages", 
                _Project.Languages.Select(x => new XElement("language",
                    new XAttribute("id", x.Id),
                    x.Description
            )));
        }

        private XElement GetPages(PageCollection pages) {
            return new XElement("pages",
                pages.Select(x => GetPage(x))
            );
        }

        private XElement GetPage(Page page) {
            return new XElement("page",
                new XAttribute("id", page.Id),
                new XAttribute("path", page.PathName),
                new XAttribute("layout", page.LayoutClassName),
                new XElement("title", GetLocalizedString(page.Title)),
                new XElement("content", GetContent(page.Content)),
                GetPages(page.Pages)
            );
        }

        private IEnumerable<XElement> GetContent(IReadOnlyDictionary<int, PageContent> content) {
            return content.Select(x => new XElement("section",
                new XAttribute("index", x.Key),
                new XAttribute("editor", x.Value.EditorType.FullName),
                new XAttribute("module", x.Value.ModuleType.FullName)
            ));
        }

        private IEnumerable<XElement> GetLocalizedString(LocalizedString str) {
            return str.Data.Select(x => new XElement(x.Key, x.Value));
        }

        private XElement GetSettings() {
            return new XElement("settings",
                new XElement("autoCloseCompileDialog", _Project.AutoCloseCompileDialog),
                new XElement("outputPath", _Project.OutputPath),
                new XElement("themePath", _Project.ThemePath)
            );
        }

        private XElement GetMedia() {
            return new XElement("media",
                _Project.Media.Select(x => GetMedia(x))
            );
        }

        private XElement GetMedia(MediaItem item) {
            MediaFile mediaFile = item as MediaFile;
            MediaReference referenceFile = item as MediaReference;
            
            if (mediaFile != null) {
                return new XElement("file",
                    new XAttribute("id", mediaFile.Id),
                    new XAttribute("name", mediaFile.Name),
                    new XAttribute("autoSave", mediaFile.AutoSave),
                    Convert.ToBase64String(mediaFile.Data)
                );
            }
            else if (referenceFile != null) {
                return new XElement("reference",
                    new XAttribute("id", referenceFile.Id),
                    new XAttribute("filePath", referenceFile.FilePath),
                    new XAttribute("autoSave", referenceFile.AutoSave)
                );
            }

            return null;
        }

        public void Dispose() {
            
        }
    }
}
