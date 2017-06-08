using System;
using WebsiteBuilder.Core.Localization;
using System.Linq;

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

		public String DisplayUrl {
			get {
				switch(Type) {
					case FooterLinkType.External:
						return Data;
					case FooterLinkType.Media:
						return _Project.Media.FirstOrDefault(x => x.Id == Data)?.Name;
					case FooterLinkType.Internal:
						return _Project.AllPages.FirstOrDefault(x => x.Id == Data)?.DisplayPath;
				}

				return String.Empty;
			}
		}

		private readonly Project _Project;

		internal FooterLink(Project project) {
			_Project = project;
			Text = new LocalizedString(project);
		}
	}
}
