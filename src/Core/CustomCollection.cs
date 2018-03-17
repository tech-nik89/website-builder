using System.Collections;
using System.Collections.Generic;

namespace WebsiteStudio.Core {
	public class CustomCollection<T> : IEnumerable<T> {

		private readonly List<T> _Items;

		private readonly Project _Project;

		public int Count => _Items.Count;

		public T this[int index] => _Items[index];

		internal CustomCollection(Project project) {
			_Project = project;
			_Items = new List<T>();
		}

		public virtual void AddRange(IEnumerable<T> items) {
			foreach (T item in items) {
				Add(item);
			}
		}

		public virtual void Add(T item) {
			_Items.Add(item);
			_Project.Dirty = true;
		}

		public virtual void Insert(int index, T item) {
			_Items.Insert(index, item);
			_Project.Dirty = true;
		}

		public virtual void RemoveAt(int index) {
			T item = _Items[index];
			Remove(item);
		}

		public virtual void Remove(T item) {
			_Project.Dirty = true;
			_Items.Remove(item);
		}

		public virtual void RemoveRange(IEnumerable<T> items) {
			_Project.Dirty = true;
			foreach (T item in items) {
				_Items.Remove(item);
			}
		}

		public virtual int IndexOf(T item) {
			return _Items.IndexOf(item);
		}

		public virtual void Clear() {
			_Items.Clear();
			_Project.Dirty = true;
		}

		public IEnumerator<T> GetEnumerator() {
			return _Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _Items.GetEnumerator();
		}

		public virtual bool Contains(T item) {
			return _Items.Contains(item);
		}

		public List<T> ToList() {
			List<T> list = new List<T>();

			foreach (T item in _Items) {
				list.Add(item);
			}

			return list;
		}
	}
}
