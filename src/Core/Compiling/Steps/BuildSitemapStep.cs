using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;

namespace WebsiteStudio.Core.Compiling.Steps {
	class BuildSitemapStep : CompilerStep {

		private readonly Project _Project;

		private readonly String _OutputPath;

		public BuildSitemapStep(Project project, DirectoryInfo outputDirectory) {
			_Project = project;
			_OutputPath = Path.Combine(outputDirectory.FullName, "sitemap.xml");
			Output = String.Format("Building sitemap: {0}", _OutputPath);
		}

		public override void Run() {
			if (String.IsNullOrWhiteSpace(_Project.BaseURL)) {
				throw new Exception("Could not generate sitemap. Base URL is required.");
			}

			XDocument xSitemap = new XDocument();
			XElement xRoot = new XElement("urlset");
			xSitemap.Add(xRoot);

			foreach (Language language in _Project.Languages) {
				foreach (Page page in _Project.AllPages) {
					if (page.RobotsNoIndex || page.Disable) {
						continue;
					}

					XElement xUrl = new XElement("url");
					xRoot.Add(xUrl);

					xUrl.Add(new XElement("loc", CreateUrl(page, language)));
					xUrl.Add(new XElement("changefreq", page.ChangeFrequency.ToString().ToLower()));

					if (page.LastModified != null && page.LastModified != DateTime.MinValue) {
						xUrl.Add(new XElement("lastmod", page.LastModified.ToString("yyyy-MM-dd")));
					}
				}
			}
			
			xSitemap.Save(_OutputPath);
		}

		private String CreateUrl(Page page, Language language) {
			UriBuilder builder = new UriBuilder(_Project.BaseURL);
			builder.Path = language.Id + "/" + Compiler.CreateUrl(page);
			return builder.Uri.ToString();
		}
	}
}
