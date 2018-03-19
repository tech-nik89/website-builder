using System.Collections.Generic;
using System.IO;

namespace WebsiteStudio.Interface.Compiling.Security {
	public class PageSecurityInfo {

		public DirectoryInfo Directory { get; set; }

		public IEnumerable<IGroup> Groups { get; set; }

	}
}
