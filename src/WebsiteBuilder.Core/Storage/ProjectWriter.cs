using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using WebsiteBuilder.Core.Footer;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Tools;

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
                    GetFooter(),
                    GetPages(_Project.Pages)
                )
            );

            String xml = document.ToString();
            File.WriteAllText(_File.FullName, xml);
        }

        private XElement GetFooter() {
            return new XElement(ProjectStorageConstants.Footer,
                _Project.Footer.Select(x => new XElement(ProjectStorageConstants.Section,
                    new XElement(ProjectStorageConstants.Title, GetLocalizedString(x.Title)),
                    GetFooterSectionItems(x.Items)
            )));
        }

        private IEnumerable<XElement> GetFooterSectionItems(IEnumerable<FooterLink> links) {
            return links.Select(x => new XElement(ProjectStorageConstants.Link,
                new XAttribute(ProjectStorageConstants.Type, x.Type.ToString()),
                new XAttribute(ProjectStorageConstants.Data, x.Data),
                new XAttribute(ProjectStorageConstants.Target, x.Target),
                GetLocalizedString(x.Text)
            ));
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
                new XAttribute(ProjectStorageConstants.IncludeInMenu, page.IncludeInMenu),
                new XAttribute(ProjectStorageConstants.Disable, page.Disable),
                new XAttribute(ProjectStorageConstants.RobotsNoIndex, page.RobotsNoIndex),
                new XAttribute(ProjectStorageConstants.RobotsNoFollow, page.RobotsNoFollow),
                new XElement(ProjectStorageConstants.Title, GetLocalizedString(page.Title)),
                new XElement(ProjectStorageConstants.MetaDescription, GetLocalizedString(page.MetaDescription)),
                new XElement(ProjectStorageConstants.MetaKeywords, GetLocalizedStringArray(page.MetaKeywords)),
                new XElement(ProjectStorageConstants.Content, GetContent(page.Content)),
                GetPages(page.Pages)
            );
        }

        

        private IEnumerable<XElement> GetContent(IReadOnlyList<PageContent> content) {
            return content.Select(x => new XElement(ProjectStorageConstants.Section,
                new XAttribute(ProjectStorageConstants.Id, x.Id),
                new XAttribute(ProjectStorageConstants.Editor, x.EditorType?.FullName ?? String.Empty),
                new XAttribute(ProjectStorageConstants.Module, x.ModuleType?.FullName ?? String.Empty)
            ));
        }

        private IEnumerable<XElement> GetLocalizedStringArray(LocalizedStringArray str) {
            return str.Data.Select(x => new XElement(x.Key, x.Value.Select(y => new XElement(ProjectStorageConstants.Item, y))));
        }

        private IEnumerable<XElement> GetLocalizedString(LocalizedString str) {
            return str.Data.Select(x => new XElement(x.Key, x.Value));
        }

        private XElement GetSettings() {
            return new XElement(ProjectStorageConstants.Settings,
                new XElement(ProjectStorageConstants.UglyURLs, _Project.UglyURLs),
                new XElement(ProjectStorageConstants.OutputPath, GetRelativePath(_Project.OutputPath)),
                new XElement(ProjectStorageConstants.ThemePath, GetRelativePath(_Project.ThemePath)),
                new XElement(ProjectStorageConstants.StartPage, _Project.StartPage?.Id ?? String.Empty),
                new XElement(ProjectStorageConstants.MetaDescription, GetLocalizedString(_Project.MetaDescription)),
                new XElement(ProjectStorageConstants.MetaKeywords, GetLocalizedStringArray(_Project.MetaKeywords))
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
                    new XAttribute(ProjectStorageConstants.Path, GetRelativePath(referenceFile.FilePath)),
                    new XAttribute(ProjectStorageConstants.AutoSave, referenceFile.AutoSave)
                );
            }

            return null;
        }

        private String GetRelativePath(String fullPath) {
            return Utilities.FullToRelativePath(fullPath, _Project);
        }

        public void Dispose() {
            
        }
    }
}
