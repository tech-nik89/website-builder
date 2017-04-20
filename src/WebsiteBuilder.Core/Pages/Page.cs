using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Theming;

namespace WebsiteBuilder.Core.Pages {

    [Serializable]
    public class Page : IPage {
        
        public String Id { get; internal set; }

        public PageCollection Pages { get; private set; }
        
        public Project Project { get; internal set; }
        
        public IPage Parent { get; internal set; }
        
        public String PathName { get; set; }

        public LocalizedString Title { get; private set; }
        
        public String LayoutClassName { get; set; }
        
        public Layout Layout => Project.Theme?.Layouts.FirstOrDefault(x => x.ClassName == LayoutClassName);

        private Dictionary<int, PageContent> _Content;

        public IReadOnlyDictionary<int, PageContent> Content => new ReadOnlyDictionary<int, PageContent>(_Content);

        public Boolean IncludeInMenu { get; set; }

        public int Level {
            get {
                int level = 0;

                Page parent = Parent as Page;
                while (parent != null) {
                    level++;
                    parent = parent.Parent as Page;
                }

                if (!Project.UglyURLs) {
                    level++;
                }

                return level;
            }
        }
        
        internal Page() : this(null) {
        }

        internal Page(Project project) {
            Pages = new PageCollection(this);
            Title = new LocalizedString();
            _Content = new Dictionary<int, PageContent>();
            IncludeInMenu = true;
            Project = project;
        }
        
        public PageContent this[int index] {
            get {
                PageContent content = null;

                if (!_Content.TryGetValue(index, out content)) {
                    content = new PageContent() {
                        Page = this,
                        Index = index
                    };

                    _Content.Add(index, content);
                }

                return content;
            }
        }

        public bool IsChildOf(Page otherPage) {
            IPage page = Parent;

            while (page != null) {
                if (page.Id == otherPage.Id) {
                    return true;
                }

                page = page.Parent;
            }

            return false;
        }

        public void Remove() {
            Parent.Pages.Remove(this);
        }
    }
}
