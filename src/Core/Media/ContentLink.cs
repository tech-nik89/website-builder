using System;
using WebsiteStudio.Interface.Content;

namespace WebsiteStudio.Core.Media {
	public class ContentLink : ILink {
		
		public String Link { get; private set; }

		public String Text { get; private set; }

		public ContentLink(String link, String text) {
			Link = link;
			Text = text;
		}

	}
}
