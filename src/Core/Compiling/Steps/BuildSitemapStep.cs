using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using WebsiteStudio.Core.Pages;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildSitemapStep : ICompilerStep {

		public String Output { get; private set; }

		private readonly Project _Project;

		private readonly String _OutputPath;

		public BuildSitemapStep(Project project, DirectoryInfo outputDirectory) {
			_Project = project;
			_OutputPath = Path.Combine(outputDirectory.FullName, "sitemap.xml");
			Output = String.Format("Building sitemap: {0}", _OutputPath);
		}

		public void Run() {
			if (String.IsNullOrWhiteSpace(_Project.BaseURL)) {
				throw new Exception("Could not generate sitemap. Base URL is required.");
			}

			XDocument xSitemap = new XDocument();
			XElement xRoot = new XElement("urlset");
			xSitemap.Add(xRoot);

			foreach(Page page in _Project.AllPages) {
				if (page.RobotsNoIndex || page.Disable) {
					continue;
				}

				XElement xUrl = new XElement("url");
				xRoot.Add(xUrl);
				xUrl.Add(new XElement("loc", CreateUrl(page)));
			}
			
			xSitemap.Save(_OutputPath);
		}

		private String CreateUrl(Page page) {
			StringBuilder urlBuilder = new StringBuilder();

			if (!_Project.BaseURL.StartsWith("http://") && !_Project.BaseURL.StartsWith("https://")) {
				urlBuilder.Append("http://");
			}

			urlBuilder.Append(_Project.BaseURL);

			if (!EndsWith(urlBuilder, "/")) {
				urlBuilder.Append("/");
			}

			urlBuilder.Append(Compiler.CreateUrl(page));
			
			if (!_Project.UglyURLs && !EndsWith(urlBuilder, "/")) {
				urlBuilder.Append("/");
			}

			return urlBuilder.ToString();
		}

		private static bool EndsWith(StringBuilder builder, String value) {
			if (builder.Length < value.Length)
				return false;

			String endsWidth = builder.ToString(builder.Length - value.Length, value.Length);
			return endsWidth.Equals(value);
		}
	}
}
