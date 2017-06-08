using System;

namespace WebsiteBuilder.Modules.News {
	class NewsItem {

		public String Id { get; set; }

		public DateTime Created { get; set; }

		public String Title { get; set; }

		public String Data { get; set; }

		public String Author { get; set; }

		public NewsItem() {
			Created = DateTime.Now;
		}

	}
}
