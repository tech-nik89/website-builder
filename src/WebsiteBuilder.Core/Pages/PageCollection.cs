using System;
using System.Collections;
using System.Collections.Generic;

namespace WebsiteBuilder.Core.Pages {

    [Serializable]
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
        }

        public void Insert(int index, Page page) {
            _Pages.Insert(index, page);
            page.Parent = _Parent;
        }

        public void RemoveAt(int index) {
            _Pages.RemoveAt(index);
        }

        public void Remove(Page page) {
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
