using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using WebsiteBuilder.Core.Compiling.Steps;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;

namespace WebsiteBuilder.Core.Compiling {
    public class Compiler {
		
        internal const String FileExtensionHtml = "html";

		internal const String MetaDirectoryName = "meta";

		internal const String MediaDirectoryName = "media";

		internal const String DirectoryUp = "..";

        private readonly Project _Project;
        
        private readonly BackgroundWorker _Worker;

        public event EventHandler<EventArgs> Completed;

        public event EventHandler<ProgressEventArgs> ProgressChanged;

        public bool IsBusy => _Worker.IsBusy;

		public bool Error { get; private set; }

        public String ErrorMessage { get; private set; }
        
        private readonly List<String> _StyleSheetFiles;

        private readonly List<ICompilerStep> _Steps;
        
		public Compiler(Project project) {
            ValidateProject(project);

			Error = false;
            _Project = project;
            _StyleSheetFiles = new List<String>();

            _Worker = new BackgroundWorker();
            _Worker.WorkerReportsProgress = true;
            _Worker.DoWork += Worker_DoWork;
            _Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            _Worker.ProgressChanged += Worker_ProgressChanged;

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
            foreach (var language in _Project.Languages) {
                foreach (Page page in _Project.AllPages) {
                    _Steps.Add(new BuildPageStep(language, page, _Project.Theme, outputDirectory, styleSheetFiles));
                }
            }
        }

        private void ValidateProject(Project project) {
            if (String.IsNullOrWhiteSpace(project.OutputPath) || !Directory.Exists(project.OutputPath)) {
                throw new Exception("Output directory not found.");
            }
        }

        public void StartAsync() {
            if (_Worker.IsBusy) {
                return;
            }

            _Worker.RunWorkerAsync();
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            ProgressChanged?.Invoke(this, new ProgressEventArgs(e.ProgressPercentage, e.UserState as String));
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Completed?.Invoke(this, new EventArgs());
        }

        private void ReportProgress(int step, int steps, String message, bool newLine = false) {
            int percentage = 0;

            if (steps > 0) {
                percentage = (int)(((decimal)step / (decimal)steps) * 100.0M);
            }

            if (newLine) {
                 message += Environment.NewLine;
            }

            _Worker.ReportProgress(percentage, message);
        }
        
        private void Worker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                int steps = _Steps.Count;

                for(int i = 0; i < steps; i++) {
                    var step = _Steps[i];
                    ReportProgress(i, steps, step.Output);

                    step.Run();
                    ReportProgress(i, steps, " ... Done.", true);
                }

                ReportProgress(1, 1, "Build succeeded.");
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
			for(int i = 0; i < count; i++) {
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
