﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ThemeEditor {
	class Theme {

		private readonly XmlDocument _Document;

		public String Path { get; private set; }

		private Theme() {
			_Document = new XmlDocument();
			_Document.PreserveWhitespace = true;
		}

		public static Theme Create() {
			return new Theme();
		}

		public static Theme Load(String path) {
			Theme theme = new Theme();
			theme._Document.Load(path);
			theme.Path = path;
			return theme;
		}

		public static void Save(Theme theme, String path) {
			theme._Document.Save(path);
			theme.Path = path;
		}

		public XmlElement CreateStyle() {
			XmlElement element = _Document.CreateElement("style");
			Root.AppendChild(element);
			return element;
		}

		public XmlElement CreateImage() {
			XmlElement element = _Document.CreateElement("image");
			Root.AppendChild(element);
			return element;
		}

		private XmlElement Root {
			get {
				if (_Document.FirstChild == null) {
					_Document.AppendChild(_Document.CreateElement("theme"));
				}

				return (XmlElement)_Document.FirstChild;
			}
		}

		public XmlElement Description {
			get {
				if (Root.SelectSingleNode("description") == null) {
					Root.AppendChild(_Document.CreateElement("description"));
				}

				return (XmlElement)Root.SelectSingleNode("description");
			}
		}

		public XmlElement Settings {
			get {
				if (Root.SelectSingleNode("settings") == null) {
					Root.AppendChild(_Document.CreateElement("settings"));
				}

				return (XmlElement)Root.SelectSingleNode("settings");
			}
		}

		public XmlElement ImageCssClass {
			get {
				if (Settings.SelectSingleNode("imageCssClass") == null) {
					Settings.AppendChild(_Document.CreateElement("imageCssClass"));
				}

				return (XmlElement)Settings.SelectSingleNode("imageCssClass");
			}
		}

		public XmlElement MaxMenuDepth {
			get {
				if (Settings.SelectSingleNode("maxMenuDepth") == null) {
					Settings.AppendChild(_Document.CreateElement("maxMenuDepth"));
				}

				return (XmlElement)Settings.SelectSingleNode("maxMenuDepth");
			}
		}

		public XmlElement NavItems {
			get {
				if (Root.SelectSingleNode("navItems") == null) {
					Root.AppendChild(_Document.CreateElement("navItems"));
				}

				return (XmlElement)Root.SelectSingleNode("navItems");
			}
		}

		public XmlElement NavItem {
			get {
				if (Root.SelectSingleNode("navItem") == null) {
					Root.AppendChild(_Document.CreateElement("navItem"));
				}

				return (XmlElement)Root.SelectSingleNode("navItem");
			}
		}

		public XmlElement LanguageItems {
			get {
				if (Root.SelectSingleNode("languageItems") == null) {
					Root.AppendChild(_Document.CreateElement("languageItems"));
				}

				return (XmlElement)Root.SelectSingleNode("languageItems");
			}
		}

		public XmlElement LanguageItem {
			get {
				if (Root.SelectSingleNode("languageItem") == null) {
					Root.AppendChild(_Document.CreateElement("languageItem"));
				}

				return (XmlElement)Root.SelectSingleNode("languageItem");
			}
		}

		public XmlElement Body {
			get {
				if (Root.SelectSingleNode("body") == null) {
					Root.AppendChild(_Document.CreateElement("body"));
				}

				return (XmlElement)Root.SelectSingleNode("body");
			}
		}

		public IEnumerable<XmlElement> Styles {
			get => Root.SelectNodes("style").Cast<XmlElement>();
		}

		public IEnumerable<XmlElement> Images {
			get => Root.SelectNodes("image").Cast<XmlElement>();
		}
	}
}
