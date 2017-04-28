using System;
using WebsiteBuilder.Core.Localization;

namespace WebsiteBuilder.Core.Footer {
    public class FooterLink {

        public LocalizedString Text { get; set; }

        private String _Data;

        public String Data {
            get => _Data;
            set { _Data = value; _Project.Dirty = true; }
        }

        private FooterLinkType _Type;

        public FooterLinkType Type {
            get => _Type;
            set { _Type = value; _Project.Dirty = true; }
        }

        private String _Target;

        public String Target {
            get => _Target;
            set { _Target = value; _Project.Dirty = true; }
        }

        private readonly Project _Project;

        internal FooterLink(Project project) {
            _Project = project;
            Text = new LocalizedString(project);
        }
    }
}
