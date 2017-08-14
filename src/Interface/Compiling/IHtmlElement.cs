using System;
using System.IO;

namespace WebsiteStudio.Interface.Compiling {
	public interface IHtmlElement {

		void AppendChild(IHtmlElement element);

		void SetAttribute(String name, String value);

		String GetAttribute(String name);

		void Compile(TextWriter writer);

		String Content { get; set; }

	}
}
