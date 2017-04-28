using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WebsiteBuilder.Core.Localization {

    [Serializable]
    public class LocalizedString {
        
        private readonly Dictionary<String, String> _Data;

        public IReadOnlyDictionary<String, String> Data => new ReadOnlyDictionary<String, String>(_Data);

        private readonly Project _Project;

        public LocalizedString(Project project) {
            _Project = project;
            _Data = new Dictionary<String, String>();
        }

        public String Get(Language language) {
            if (language == null) {
                return String.Empty;
            }

            return Get(language.Id);
        }

        public String Get(String id) {
            String value = String.Empty;

            if (String.IsNullOrEmpty(id)) {
                return value;
            }

            _Data.TryGetValue(id, out value);
            return value;
        }

        public void Set(Language language, String value) {
            if (language == null) {
                return;
            }

            Set(language.Id, value);
            _Project.Dirty = true;
        }

        public void Set(String id, String value) {
            _Data[id] = value;
        }
    }
}
