using System;
using System.IO;
using System.Text;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core.Compiling {
	class HtmlDocument {

		private const String HtmlDoctype = "<!DOCTYPE html>";

		private const String TagHtml = "html";
		private const String TagHead = "head";
		private const String TagBody = "body";
		private const String TagScript = "script";
		private const String TagStyle = "style";
		private const String TagLink = "link";
        private const String TagMeta = "meta";

        private const String AttributeType = "type";
		private const String AttributeRel = "rel";
		private const String AttributeReference = "href";
		private const String AttributeSource = "src";
        private const String AttributeCharset = "charset";
        private const String AttributeName = "name";
        private const String AttributeContent = "content";

        private const String TypeJavascript = "text/javascript";
		private const String TypeCSS = "text/css";

		private const String RelCSS = "stylesheet";

        private readonly HtmlElement _Html;
        private readonly HtmlElement _Head;
        private readonly HtmlElement _Body;
        private readonly HtmlElement _Encoding;
        
        public Encoding Encoding {
            get {
                return Encoding.GetEncoding(_Encoding.GetAttribute(AttributeCharset));
            }
            set {
                _Encoding.SetAttribute(AttributeCharset, value.WebName);
            }
        }

        public HtmlDocument() {
            _Html = new HtmlElement(TagHtml);
            _Head = new HtmlElement(TagHead);
            _Body = new HtmlElement(TagBody);
            _Encoding = new HtmlElement(TagMeta);

            _Html.AppendChild(_Head);
            _Html.AppendChild(_Body);
            
            _Head.AppendChild(_Encoding);
            _Head.AppendChild(GetMetaViewport());

            Encoding = Encoding.UTF8;
        }

        private HtmlElement GetMetaViewport() {
            HtmlElement element = new HtmlElement(TagMeta);
            element.SetAttribute(AttributeName, "viewport");
            element.SetAttribute(AttributeContent, "width=device-width, initial-scale=1.0");
            return element;
        }

		public void AddScript(String script) {
            var tag = new HtmlElement(TagScript);
			tag.SetAttribute(AttributeType, TypeJavascript);
            tag.Content = Utilities.JavaScriptMinifier.Compile(script);
            _Head.AppendChild(tag);
		}

		public void AddStyle(String css) {
			var tag = new HtmlElement(TagStyle);
			tag.SetAttribute(AttributeType, TypeCSS);
			tag.Content = Utilities.CssMinifier.Compile(css);
			_Head.AppendChild(tag);
		}

		public void AddStyleLink(String path) {
			var tag = new HtmlElement(TagLink);
			tag.SetAttribute(AttributeRel, RelCSS);
			tag.SetAttribute(AttributeType, TypeCSS);
			tag.SetAttribute(AttributeReference, path);
			_Head.AppendChild(tag);
		}
        
		public String Body {
			get {
				return _Body.Content;
			}
			set {
				_Body.Content = value;
			}
		}

		public void Compile(String path) {
            using (TextWriter writer = new StreamWriter(path, false, Encoding.UTF8)) {
                writer.WriteLine(HtmlDoctype);
                
                _Html.Compile(writer);

                writer.Close();
            }
		}
	}
}
