using System;

namespace WebsiteStudio.Core.Security {
	public class Group {

		private readonly Project _Project;
		
		private String _Name;
		public String Name {
			get => _Name;
			set { _Name = value; _Project.Dirty = true; }
		}

		internal Group(Project project) {
			_Project = project;
		}

	}
}
