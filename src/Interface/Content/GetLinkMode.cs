using System;

namespace WebsiteStudio.Interface.Content {

	[Flags]
	public enum GetLinkMode {
		Pages = 1,
		Files = 2,
		Images = 4
	}

}
