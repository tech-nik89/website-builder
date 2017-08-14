﻿using System;
using System.Collections.Generic;
using System.IO;
using WebsiteStudio.Interface.Compiling;

namespace WebsiteStudio.Core.Compiling {
	class HtmlElement : IHtmlElement {
		
		private readonly List<IHtmlElement> _Children;
		private readonly List<IHtmlElement> _DelayedChildren;
		private readonly String _Name;
		private readonly Dictionary<String, String> _Attributes;
		
		public String Content { get; set; }

		public HtmlElement(String name) {
			_Children = new List<IHtmlElement>();
			_DelayedChildren = new List<IHtmlElement>();
			_Attributes = new Dictionary<String, String>();
			_Name = name;
		}

		public void AppendChild(IHtmlElement element) {
			_Children.Add(element);
		}

		public void AppendDelayedChild(IHtmlElement element) {
			_DelayedChildren.Add(element);
		}

		public void SetAttribute(String name, String value) {
			_Attributes[name] = value;
		}
		
		public String GetAttribute(String name) {
			String value = null;
			_Attributes.TryGetValue(name, out value);
			return value;
		}

		public void Compile(TextWriter writer) {
			WriteTag(writer, false);

			foreach (var child in _Children) {
				child.Compile(writer);
			}

			if (!String.IsNullOrWhiteSpace(Content)) {
				writer.Write(Content);
			}

			foreach (var child in _DelayedChildren) {
				child.Compile(writer);
			}

			WriteTag(writer, true);
		}

		private void WriteTag(TextWriter writer, bool closing) {
			writer.Write("<");

			if (closing) {
				writer.Write("/");
				writer.Write(_Name.ToLower());
			}
			else {
				writer.Write(_Name);
				foreach (var attr in _Attributes) {
					writer.Write(" ");
					writer.Write(attr.Key.ToLower());
					writer.Write("=\"");
					writer.Write(attr.Value);
					writer.Write("\"");
				}
			}

			writer.Write(">");
		}
	}
}
