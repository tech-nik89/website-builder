﻿using System;
using System.IO;
using System.Text;
using WebsiteStudio.Core.Compiling.Links;
using WebsiteStudio.Core.Tools;

namespace WebsiteStudio.Core.Compiling {
	class HtmlDocument {

		private const String HtmlDoctype = "<!DOCTYPE html>";

		private const String TagHtml = "html";
		private const String TagHead = "head";
		private const String TagBody = "body";
		private const String TagScript = "script";
		private const String TagStyle = "style";
		private const String TagLink = "link";
		private const String TagMeta = "meta";
		private const String TagTitle = "title";

		private const String AttributeType = "type";
		private const String AttributeRel = "rel";
		private const String AttributeReference = "href";
		private const String AttributeSource = "src";
		private const String AttributeCharset = "charset";
		private const String AttributeName = "name";
		private const String AttributeContent = "content";
		private const String AttributeHttpEquiv = "http-equiv";

		private const String TypeJavascript = "text/javascript";
		private const String TypeCSS = "text/css";

		private const String RelCSS = "stylesheet";

		private readonly HtmlElement _Html;
		private readonly HtmlElement _Head;
		private readonly HtmlElement _Body;
		private readonly HtmlElement _Encoding;
		private readonly HtmlElement _Title;

		public Encoding Encoding {
			get => Encoding.GetEncoding(_Encoding.GetAttribute(AttributeCharset));
			set =>	_Encoding.SetAttribute(AttributeCharset, value.WebName);
		}

		public String Title {
			get => _Title.Content;
			set => _Title.Content = value;
		}

		public HtmlDocument() {
			_Html = new HtmlElement(TagHtml);
			_Head = new HtmlElement(TagHead);
			_Body = new HtmlElement(TagBody);
			_Encoding = new HtmlElement(TagMeta);
			_Title = new HtmlElement(TagTitle);

			_Html.AppendChild(_Head);
			_Html.AppendChild(_Body);
			
			_Head.AppendChild(_Encoding);
			_Head.AppendChild(GetMetaViewport());
			_Head.AppendChild(_Title);

			ApplyWebkitTouchHoverFix();

			Encoding = Encoding.UTF8;
		}

		private void ApplyWebkitTouchHoverFix() {
			AddScript("document.addEventListener('touchstart', function(){}, true);");
		}

		private static HtmlElement GetMetaViewport() {
			HtmlElement element = new HtmlElement(TagMeta);
			element.SetAttribute(AttributeName, "viewport");
			element.SetAttribute(AttributeContent, "width=device-width, initial-scale=1.0");
			return element;
		}

		public void AddScript(String script) {
			AddScript(script, false);
		}
		
		public void AddScript(String script, bool runAfterLoad) {
			var tag = new HtmlElement(TagScript);
			tag.SetAttribute(AttributeType, TypeJavascript);
			tag.Content = Utilities.JavaScriptMinifier.Compile(script);

			if (runAfterLoad) {
				_Body.AppendDelayedChild(tag);
			}
			else {
				_Head.AppendChild(tag);
			}
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

		public void AddScriptLink(String path) {
			AddScriptLink(path, false);
		}

		public void AddScriptLink(ScriptLink link) {
			AddScriptLink(link.FileName, link.RunAfterLoad);
		}

		public void AddScriptLink(String path, bool runAfterLoad) {
			var tag = new HtmlElement(TagScript);
			tag.SetAttribute(AttributeType, TypeJavascript);
			tag.SetAttribute(AttributeSource, path);

			if (runAfterLoad) {
				_Body.AppendDelayedChild(tag);
			}
			else {
				_Head.AppendChild(tag);
			}
		}

		public void AddMetaTag(String name, String content) {
			HtmlElement tag = new HtmlElement(TagMeta);
			tag.SetAttribute(AttributeName, name);
			tag.SetAttribute(AttributeContent, content);
			_Head.AppendChild(tag);
		}

		public void AddMetaTagHttpEquiv(String httpEquiv, String content) {
			HtmlElement tag = new HtmlElement(TagMeta);
			tag.SetAttribute(AttributeHttpEquiv, httpEquiv);
			tag.SetAttribute(AttributeContent, content);
			_Head.AppendChild(tag);
		}

		public void AddFaviconTag(String path) {
			HtmlElement tag = new HtmlElement(TagLink);
			tag.SetAttribute(AttributeRel, "icon");
			tag.SetAttribute(AttributeReference, path);
			tag.SetAttribute(AttributeType, "image/x-icon");
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
