using System;
using System.Collections;
using System.Collections.Generic;

namespace WebsiteBuilder.Core.Pages {
    
    public class PageCollection : IEnumerable<Page> {
        
        private readonly List<Page> _Pages;

        private readonly IPage _Parent;
        
        public PageCollection(IPage parent) {
            _Pages = new List<Page>();
            _Parent = parent;
        }

        public void AddRange(IEnumerable<Page> pages) {
            foreach (Page page in pages) {
                Add(page);
            }
        }

        public void Add(Page page) {
            _Pages.Add(page);
            page.Parent = _Parent;
            page.Project.Dirty = true;
        }

        public void Insert(int index, Page page) {
            _Pages.Insert(index, page);
            page.Parent = _Parent;
            page.Project.Dirty = true;
        }

        public void RemoveAt(int index) {
            Page page = _Pages[index];
            Remove(page);
        }

        public void Remove(Page page) {
            page.Project.Dirty = true;
            _Pages.Remove(page);
        }

        public int IndexOf(Page page) {
            return _Pages.IndexOf(page);
        }

        public IEnumerator<Page> GetEnumerator() {
            return _Pages.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _Pages.GetEnumerator();
        }
    }
}
