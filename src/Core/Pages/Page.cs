using System;
using System.Collections.Generic;
using System.Diagnostics;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Security;

namespace WebsiteStudio.Core.Pages {

	[Serializable]
	[DebuggerDisplay("{DisplayPath}")]
	public class Page : IPage {
		
		public String Id { get; internal set; }

		public PageCollection Pages { get; private set; }
		
		public Project Project { get; internal set; }

		public PageChangeFrequency ChangeFrequency { get; set; }

		public DateTime LastModified { get; set; }
		
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

		private bool _Disable;

		public bool Disable {
			get => _Disable;
			set { _Disable = value; Project.Dirty = true; }
		}

		public LocalizedStringArray MetaKeywords { get; private set; }

		public LocalizedString MetaDescription { get; private set; }

		private bool _RobotsNoIndex;

		public bool RobotsNoIndex {
			get => _RobotsNoIndex;
			set { _RobotsNoIndex = value; Project.Dirty = true; }
		}

		private bool _RobotsNoFollow;

		public bool RobotsNoFollow {
			get => _RobotsNoFollow;
			set { _RobotsNoFollow = value; Project.Dirty = true; }
		}

		private String _LinkTarget;

		public String LinkTarget {
			get => _LinkTarget;
			set { _LinkTarget = value; Project.Dirty = true; }
		}

		private PageLinkType _LinkType;

		public PageLinkType LinkType {
			get => _LinkType;
			set { _LinkType = value; Project.Dirty = true; }
		}

		public int ParentCount {
			get {
				int level = 0;

				Page parent = Parent as Page;
				while (parent != null) {
					level++;
					parent = parent.Parent as Page;
				}

				return level;
			}
		}

		public int Level {
			get {
				int level = ParentCount;
				
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
		
		public CustomCollection<Group> AllowedGroups { get; private set; }

		internal Page(Project project) {
			Project = project;
			Pages = new PageCollection(this);
			Title = new LocalizedString(project);
			MetaDescription = new LocalizedString(project);
			MetaKeywords = new LocalizedStringArray(project);
			AllowedGroups = new CustomCollection<Group>(project);
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
			Project.Dirty = true;
			return content;
		}

		internal PageContent AddContent(int index, String id) {
			PageContent content = new PageContent(id, this);
			_Content.Insert(index, content);
			Project.Dirty = true;
			return content;
		}

		public void RemoveContent(int index) {
			_Content.RemoveAt(index);
			Project.Dirty = true;
		}
		
		public int MoveContent(int index, PageMoveDirection direction) {
			if (index < 0 || index > _Content.Count - 1) {
				return -1;
			}

			PageContent content = _Content[index];

			if (direction == PageMoveDirection.Up && index > 0) {
				int newIndex = index - 1;
				_Content.Remove(content);
				_Content.Insert(newIndex, content);
				Project.Dirty = true;
				return newIndex;
			}
			else if (direction == PageMoveDirection.Down && index < _Content.Count - 1) {
				int newIndex = index + 1;
				_Content.Remove(content);
				_Content.Insert(newIndex, content);
				Project.Dirty = true;
				return newIndex;
			}

			return -1;
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
			Project.Dirty = true;
		}
	}
}
