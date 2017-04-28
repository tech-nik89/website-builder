using System.Collections;
using System.Collections.Generic;

namespace WebsiteBuilder.Core {
    public class CustomCollection<T> : IEnumerable<T> {

        private readonly List<T> _Items;

        private readonly Project _Project;

        public int Count => _Items.Count;

        public T this[int index] => _Items[index];

        internal CustomCollection(Project project) {
            _Project = project;
            _Items = new List<T>();
        }

        public void AddRange(IEnumerable<T> items) {
            foreach (T item in items) {
                Add(item);
            }
        }

        public void Add(T item) {
            _Items.Add(item);
            _Project.Dirty = true;
        }

        public void Insert(int index, T item) {
            _Items.Insert(index, item);
            _Project.Dirty = true;
        }

        public void RemoveAt(int index) {
            T item = _Items[index];
            Remove(item);
        }

        public void Remove(T item) {
            _Project.Dirty = true;
            _Items.Remove(item);
        }

        public int IndexOf(T item) {
            return _Items.IndexOf(item);
        }

        public IEnumerator<T> GetEnumerator() {
            return _Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return _Items.GetEnumerator();
        }

    }
}
