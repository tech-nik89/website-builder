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
                new XElement(ProjectStorageConstants.Root,
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
            return new XElement(ProjectStorageConstants.Languages, 
                _Project.Languages.Select(x => new XElement(ProjectStorageConstants.Language,
                    new XAttribute(ProjectStorageConstants.Id, x.Id),
                    x.Description
            )));
        }

        private XElement GetPages(PageCollection pages) {
            return new XElement(ProjectStorageConstants.Pages,
                pages.Select(x => GetPage(x))
            );
        }

        private XElement GetPage(Page page) {
            return new XElement(ProjectStorageConstants.Page,
                new XAttribute(ProjectStorageConstants.Id, page.Id),
                new XAttribute(ProjectStorageConstants.Path, page.PathName),
                new XAttribute(ProjectStorageConstants.Layout, page.LayoutClassName),
                new XElement(ProjectStorageConstants.Title, GetLocalizedString(page.Title)),
                new XElement(ProjectStorageConstants.Content, GetContent(page.Content)),
                GetPages(page.Pages)
            );
        }

        private IEnumerable<XElement> GetContent(IReadOnlyDictionary<int, PageContent> content) {
            return content.Select(x => new XElement(ProjectStorageConstants.Section,
                new XAttribute(ProjectStorageConstants.Index, x.Key),
                new XAttribute(ProjectStorageConstants.Editor, x.Value.EditorType.FullName),
                new XAttribute(ProjectStorageConstants.Module, x.Value.ModuleType.FullName)
            ));
        }

        private IEnumerable<XElement> GetLocalizedString(LocalizedString str) {
            return str.Data.Select(x => new XElement(x.Key, x.Value));
        }

        private XElement GetSettings() {
            return new XElement(ProjectStorageConstants.Settings,
                new XElement(ProjectStorageConstants.AutoCloseCompleteDialog, _Project.AutoCloseCompileDialog),
                new XElement(ProjectStorageConstants.OutputPath, _Project.OutputPath),
                new XElement(ProjectStorageConstants.ThemePath, _Project.ThemePath)
            );
        }

        private XElement GetMedia() {
            return new XElement(ProjectStorageConstants.Media,
                _Project.Media.Select(x => GetMedia(x))
            );
        }

        private XElement GetMedia(MediaItem item) {
            MediaFile mediaFile = item as MediaFile;
            MediaReference referenceFile = item as MediaReference;
            
            if (mediaFile != null) {
                return new XElement(ProjectStorageConstants.File,
                    new XAttribute(ProjectStorageConstants.Id, mediaFile.Id),
                    new XAttribute(ProjectStorageConstants.Name, mediaFile.Name),
                    new XAttribute(ProjectStorageConstants.AutoSave, mediaFile.AutoSave),
                    Convert.ToBase64String(mediaFile.Data)
                );
            }
            else if (referenceFile != null) {
                return new XElement(ProjectStorageConstants.Reference,
                    new XAttribute(ProjectStorageConstants.Id, referenceFile.Id),
                    new XAttribute(ProjectStorageConstants.Path, referenceFile.FilePath),
                    new XAttribute(ProjectStorageConstants.AutoSave, referenceFile.AutoSave)
                );
            }

            return null;
        }

        public void Dispose() {
            
        }
    }
}
