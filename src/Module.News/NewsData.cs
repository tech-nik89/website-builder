using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebsiteStudio.Modules.News {
	class NewsData : IEnumerable<NewsItem>, IList<NewsItem>, ICollection<NewsItem> {

		private const String TagRoot = "news";

		private const String TagSettings = "settings";

		private const String TagSettingsLargeItemsCount = "largeItemsCount";

		private const String TagSettingsLargeItemsMaxHeight = "largeItemsMaxHeight";

		private const String TagSettingsExpanderText = "expanderText";

		private const String TagItem = "item";

		public const String AttributeId = "id";

		public const String AttributeCreated = "created";

		public const String AttributeAuthor = "author";

		public const String AttributeTitle = "title";

		private readonly List<NewsItem> _Items;

		public int Count => _Items.Count;

		public bool IsReadOnly => false;

		public int LargeItemsCount { get; set; }

		public int LargeItemsMaxHeight { get; set; }

		public String ExpanderText { get; set; }

		public NewsItem this[int index] {
			get => _Items[index];
			set => _Items[index] = value;
		}

		public NewsData() {
			_Items = new List<NewsItem>();
		}

		public static NewsData Deserialize(String str) {
			NewsData data = new NewsData();

			try {
				XDocument document = XDocument.Parse(str);
				XElement root = document.Element(TagRoot);

				data._Items.AddRange(root.Elements(TagItem).Select(x => new NewsItem() {
					Id = x.Attribute(AttributeId).Value,
					Author = x.Attribute(AttributeAuthor).Value,
					Title = x.Attribute(AttributeTitle).Value,
					Created = Convert.ToDateTime(x.Attribute(AttributeCreated).Value),
					Data = x.Value
				}));

				XElement settings = root.Element(TagSettings);
				data.LargeItemsCount = Convert.ToInt32(settings.Attribute(TagSettingsLargeItemsCount)?.Value ?? "3");
				data.LargeItemsMaxHeight = Convert.ToInt32(settings.Attribute(TagSettingsLargeItemsMaxHeight)?.Value ?? "300");
				data.ExpanderText = settings.Attribute(TagSettingsExpanderText)?.Value ?? "More";

				return data;
			}
			catch {
				
			}

			return data;
		}

		public static String Serialize(NewsData data) {
			XDocument document = new XDocument();

			XElement root = new XElement(TagRoot,
				new XElement(TagSettings,
					new XAttribute(TagSettingsLargeItemsCount, data.LargeItemsCount),
					new XAttribute(TagSettingsLargeItemsMaxHeight, data.LargeItemsMaxHeight),
					new XAttribute(TagSettingsExpanderText, data.ExpanderText)
				),
				data.Select(x => new XElement(TagItem,
					new XAttribute(AttributeId, x.Id),
					new XAttribute(AttributeAuthor, x.Author),
					new XAttribute(AttributeCreated, x.Created),
					new XAttribute(AttributeTitle, x.Title),
					x.Data
				)));

			document.Add(root);
			return document.ToString();
		}

		public IEnumerator<NewsItem> GetEnumerator() {
			return _Items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return _Items.GetEnumerator();
		}

		public int IndexOf(NewsItem item) {
			return _Items.IndexOf(item);
		}

		public void Insert(int index, NewsItem item) {
			_Items.Insert(index, item);
		}

		public void RemoveAt(int index) {
			_Items.RemoveAt(index);
		}

		public void Add(NewsItem item) {
			_Items.Add(item);
		}

		public void Clear() {
			_Items.Clear();
		}

		public bool Contains(NewsItem item) {
			return _Items.Contains(item);
		}

		public void CopyTo(NewsItem[] array, int arrayIndex) {
			_Items.CopyTo(array, arrayIndex);
		}

		public bool Remove(NewsItem item) {
			return _Items.Remove(item);
		}
	}
}
