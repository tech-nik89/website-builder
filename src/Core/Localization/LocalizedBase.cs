using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebsiteStudio.Core.Localization {
	public abstract class LocalizedBase<T> {

		private readonly Dictionary<String, T> _Data;

		public IReadOnlyDictionary<String, T> Data => new ReadOnlyDictionary<String, T>(_Data);

		private readonly Project _Project;

		public LocalizedBase(Project project) {
			_Project = project;
			_Data = new Dictionary<String, T>();
		}

		public T Get(Language language) {
			if (language == null) {
				return default(T);
			}

			return Get(language.Id);
		}

		public T Get(String id) {
			T value = default(T);

			if (String.IsNullOrEmpty(id)) {
				return value;
			}

			_Data.TryGetValue(id, out value);
			return value;
		}

		public void Set(Language language, T value) {
			if (language == null) {
				return;
			}

			Set(language.Id, value);
			_Project.Dirty = true;
		}

		public void Set(String id, T value) {
			_Data[id] = value;
		}

	}
}
