﻿using System;
using System.Collections.Generic;
using WebsiteBuilder.Core.Localization;

namespace WebsiteBuilder.Core.Pages {

    [Serializable]
    public class Page : IPage {
        
        public String Id { get; internal set; }

        public PageCollection Pages { get; private set; }
        
        public Project Project { get; internal set; }
        
        public IPage Parent { get; internal set; }

        private String _PathName;

        public String PathName {
            get => _PathName;
            set { _PathName = value; Project.Dirty = true; }
        }

        public LocalizedString Title { get; private set; }
        
        private List<PageContent> _Content;

        public IReadOnlyList<PageContent> Content => _Content.AsReadOnly();

        public int ContentCount => _Content.Count;

        private bool _IncludeInMenu;

        public bool IncludeInMenu {
            get => _IncludeInMenu;
            set { _IncludeInMenu = value; Project.Dirty = true; }
        }

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
        
        public String DisplayPath {
            get {
                List<String> name = new List<String>();
                IPage parent = this;

                while (parent != null) {
                    name.Insert(0, parent.PathName);
                    parent = parent.Parent;
                }

                return String.Join("/", name);
            }
        }
        
        internal Page(Project project) {
            Project = project;
            Pages = new PageCollection(this);
            Title = new LocalizedString(project);
            _Content = new List<PageContent>();
            IncludeInMenu = true;
        }
        
        public PageContent this[int index] {
            get {
                PageContent content = null;

                if (index < _Content.Count) {
                    content = _Content[index];
                }

                return content;
            }
        }

        public PageContent AddContent() {
            PageContent content = new PageContent(this);
            _Content.Add(content);
            return content;
        }

        internal PageContent AddContent(int index, String id) {
            PageContent content = new PageContent(id, this);
            _Content.Insert(index, content);
            return content;
        }

        public void RemoveContent(int index) {
            _Content.RemoveAt(index);
        }
        
        public void MoveContent(int index, PageMoveDirection direction) {
            if (index < 0 || index > _Content.Count - 1) {
                return;
            }

            PageContent content = _Content[index];

            if (direction == PageMoveDirection.Up && index > 0) {
                _Content.Remove(content);
                _Content.Insert(index - 1, content);
            }
            else if (direction == PageMoveDirection.Down && index < _Content.Count - 1) {
                _Content.Remove(content);
                _Content.Insert(index + 1, content);
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
