using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using WebsiteStudio.Core.Compiling.Steps;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;

namespace WebsiteStudio.Core.Compiling {
	public class Compiler {
		
		internal const String FileExtensionHtml = "html";

		internal const String MetaDirectoryName = "meta";

		internal const String MediaDirectoryName = "media";

		internal const String DirectoryUp = "..";

		private readonly Project _Project;
		
		public bool Error { get; private set; }

		public String ErrorMessage { get; private set; }
		
		private readonly List<String> _StyleSheetFiles;

		private readonly List<ICompilerStep> _Steps;

		private readonly Dictionary<Type, int> _ModuleCompilerFlags;

		internal IDictionary<Type, int> ModuleCompilerFlags => _ModuleCompilerFlags;
		
		public Compiler(Project project)
			: this(project, new CompilerSettings()) {
		}

		public Compiler(Project project, CompilerSettings settings) {
			ValidateProject(project);

			Error = false;
			_Project = project;
			_StyleSheetFiles = new List<String>();
			_ModuleCompilerFlags = new Dictionary<Type, int>();
			
			DirectoryInfo outputDirectory = new DirectoryInfo(_Project.OutputPath);
			DirectoryInfo metaDirectory = new DirectoryInfo(Path.Combine(_Project.OutputPath, MetaDirectoryName));
			DirectoryInfo mediaDirectory = new DirectoryInfo(Path.Combine(_Project.OutputPath, MediaDirectoryName));

			if (_Project.Theme == null) {
				throw new FileNotFoundException(_Project.ThemePath);
			}

			_Project.ReloadTheme();
			
			_Steps = new List<ICompilerStep>();

			_Steps.Add(new PrepareDirectoryStep(outputDirectory));
			_Steps.Add(new PrepareDirectoryStep(metaDirectory));
			_Steps.Add(new PrepareDirectoryStep(mediaDirectory));
			_Steps.Add(new BuildIndexFile(_Project));
			_Steps.Add(new BuildStyleSheetsStep(_Project.Theme, metaDirectory, _StyleSheetFiles));
			_Steps.Add(new BuildFontsStep(_Project.Theme, metaDirectory));
			_Steps.Add(new BuildImagesStep(_Project.Theme, metaDirectory, _StyleSheetFiles));
			_Steps.Add(new CopyMediaStep(_Project.Media, mediaDirectory));

			ReadOnlyCollection<String> styleSheetFiles = _StyleSheetFiles.AsReadOnly();
			foreach (Language language in _Project.Languages) {
				if (settings.PreviewLanguage != null && language.Id != settings.PreviewLanguage.Id) {
					continue;
				}

				foreach (Page page in _Project.AllPages) {
					if (settings.PreviewPage != null && page.Id != settings.PreviewPage.Id || page.Disable) {
						continue;
					}

					_Steps.Add(new BuildPageStep(language, page, _Project.Theme, outputDirectory, styleSheetFiles));
				}
			}
		}

		public static void ClearOutputDirectory(Project project) {
			if (project == null || project.OutputPath == null) {
				return;
			}

			DirectoryInfo directory = new DirectoryInfo(project.OutputPath);
			if (!directory.Exists) {
				return;
			}

			PrepareDirectoryStep step = new PrepareDirectoryStep(directory);
			step.Run();
		}

		private void ValidateProject(Project project) {
			if (String.IsNullOrWhiteSpace(project.OutputPath) || !Directory.Exists(project.OutputPath)) {
				throw new Exception("Output directory not found.");
			}
		}

		public async Task CompileAsync() {
			await CompileAsync(null);
		}

		public async Task CompileAsync(IProgress<CompilerProgressReport> progress) {
			await Task.Run(() => {
				Compile(progress);
			});
		}
		
		private CompilerProgressReport CreateProgressReport(int step, int steps, String message, bool newLine = false) {
			int percentage = 0;

			if (steps > 0) {
				percentage = (int)(((decimal)step / (decimal)steps) * 100.0M);
			}

			if (newLine) {
				 message += Environment.NewLine;
			}

			return new CompilerProgressReport(percentage, message);
		}

		public void Compile() {
			Compile(null);
		}

		public void Compile(IProgress<CompilerProgressReport> progress) {
			try {
				int steps = _Steps.Count;

				for(int i = 0; i < steps; i++) {
					var step = _Steps[i];
					progress?.Report(CreateProgressReport(i, steps, step.Output));

					step.Run();
					progress?.Report(CreateProgressReport(i, steps, " ... Done.", true));
				}

				progress?.Report(CreateProgressReport(1, 1, "Build succeeded."));
			}
			catch (Exception ex) {
				Error = true;
				ErrorMessage = ex.Message;
			}
		}

		internal static String CreateUrl(Page page, Language language) {
			List<String> path = new List<String>();
			Page parent = page.Parent as Page;

			while (parent != null) {
				path.Insert(0, parent.PathName);
				parent = parent.Parent as Page;
			}

			path.Insert(0, language.Id);

			int count = path.Count;
			for(int i = 0; i < count + 1; i++) {
				path.Insert(0, DirectoryUp);
			}

			if (page.Project.UglyURLs) {
				path.Add(String.Concat(page.PathName, ".", FileExtensionHtml));
			}
			else {
				path.Add(String.Concat(page.PathName, "/"));
			}

			return String.Join("/", path);
		}

		internal static String CreateUrl(Page targetPage) {
			return CreateUrl(targetPage, (Page)null);
		}

		internal static String CreateUrl(Page targetPage, Page currentPage) {
			List<String> path = new List<String>();
			Page parent = targetPage.Parent as Page;

			while (parent != null) {
				path.Insert(0, parent.PathName);
				parent = parent.Parent as Page;
			}

			if (targetPage.Project.UglyURLs) {
				path.Add(String.Concat(targetPage.PathName, ".", FileExtensionHtml));
			}
			else {
				path.Add(String.Concat(targetPage.PathName, "/"));
			}
			
			for (int i = 0; i < (currentPage?.Level ?? 0); i++) {
				path.Insert(0, DirectoryUp);
			}

			return String.Join("/", path);
		}
		
		private DirectoryInfo GetChildDirectory(DirectoryInfo currentDirectory, Page page) {
			String path = Path.Combine(currentDirectory.FullName, page.PathName);
			DirectoryInfo info = new DirectoryInfo(path);
			info.Create();
			return info;
		}
	}
}
