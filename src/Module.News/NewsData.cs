﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace WebsiteBuilder.Modules.News {
    class NewsData : IEnumerable<NewsItem>, IList<NewsItem> {

        private const String TagRoot = "news";

        private const String TagItem = "item";

        public const String AttributeId = "id";

        public const String AttributeCreated = "created";

        public const String AttributeAuthor = "author";

        public const String AttributeTitle = "title";

        private readonly List<NewsItem> _Items;

        public int Count => _Items.Count;

        public bool IsReadOnly => false;

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
                
                data._Items.AddRange(document.Element(TagRoot).Elements(TagItem).Select(x => new NewsItem() {
                    Id = x.Attribute(AttributeId).Value,
                    Author = x.Attribute(AttributeAuthor).Value,
                    Title = x.Attribute(AttributeTitle).Value,
                    Created = Convert.ToDateTime(x.Attribute(AttributeCreated).Value),
                    Data = x.Value
                }));

                return data;
            }
            catch {
                
            }

            return data;
        }

        public static String Serialize(NewsData data) {
            XDocument document = new XDocument();

            document.Add(new XElement(TagRoot,
                data.Select(x => new XElement(TagItem,
                    new XAttribute(AttributeId, x.Id),
                    new XAttribute(AttributeAuthor, x.Author),
                    new XAttribute(AttributeCreated, x.Created),
                    new XAttribute(AttributeTitle, x.Title),
                    x.Data
                ))));
            
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
