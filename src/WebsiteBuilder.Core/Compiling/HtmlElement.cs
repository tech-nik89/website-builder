using System;
using System.Collections.Generic;
using System.IO;

namespace WebsiteBuilder.Core.Compiling {
    class HtmlElement {
        
        private readonly List<HtmlElement> _Children;
        private readonly String _Name;
        private readonly Dictionary<String, String> _Attributes;
        
        public String Content { get; set; }

        public HtmlElement(String name) {
            _Children = new List<HtmlElement>();
            _Attributes = new Dictionary<String, String>();
            _Name = name;
        }

        public void AppendChild(HtmlElement element) {
            _Children.Add(element);
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
