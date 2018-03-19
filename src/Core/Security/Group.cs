using System;
using System.Diagnostics;
using WebsiteStudio.Interface.Compiling.Security;

namespace WebsiteStudio.Core.Security {

	[DebuggerDisplay("{Name}")]
	public class Group : IGroup {

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
