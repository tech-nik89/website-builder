﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WebsiteBuilder.Core.Footer;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Storage;
using WebsiteBuilder.Core.Theming;
using WebsiteBuilder.Core.Tools;

namespace WebsiteBuilder.Core {

    public class Project : IPage {

        public const String FileExtension = ".wbproj";

        public const String FileIndex = "index.html";

        public const String ContentDirectoryName = "content";

        private bool _UglyURLs;

        public bool UglyURLs {
            get => _UglyURLs;
            set { _UglyURLs = value; Dirty = true; }
        }

        public String Id => null;

        public IPage Parent => null;

        public String PathName => null;

        private String _ProjectFilePath;

        public String ProjectFilePath {
            get => _ProjectFilePath;
            set { _ProjectFilePath = value; Dirty = true; }
        }

        private String _OutputPath;

        public String OutputPath {
            get => _OutputPath;
            set { _OutputPath = value; Dirty = true; }
        }
        
        public String ProjectFileName 
            => (ProjectFilePath != null && File.Exists(ProjectFilePath))
            ? Path.GetFileNameWithoutExtension(ProjectFilePath)
            : String.Empty;

        public FileInfo ProjectFile => new FileInfo(ProjectFilePath);

        public DirectoryInfo ProjectContentDirectory => new DirectoryInfo(Path.Combine(ProjectFile.DirectoryName, ContentDirectoryName));

        public PageCollection Pages { get; private set; }

        private Language[] _Languages;

        public Language[] Languages {
            get => _Languages;
            set { _Languages = value; Dirty = true; }
        }

        private String _ThemePath;
        
        public String ThemePath {
            get {
                return _ThemePath;
            }
            set {
                _ThemePath = value;
                _Theme = null;
                Dirty = true;
            }
        }
        
        private Theme _Theme;
        
        public Theme Theme {
            get {
                if (_Theme == null && File.Exists(ThemePath)) {
                    try {
                        _Theme = Theme.Load(ThemePath);
                    }
                    catch {
                        _Theme = null;
                    }
                }

                return _Theme;
            }
        }
        
        public ReadOnlyCollection<Page> AllPages {
            get {
                List<Page> allPages = new List<Page>();
                FillAllPagesList(Pages, allPages);
                return allPages.AsReadOnly();
            }
        }

        private Page _StartPage;

        public Page StartPage {
            get => _StartPage;
            set { _StartPage = value; Dirty = true; }
        }

        public CustomCollection<MediaItem> Media { get; private set; }

        public CustomCollection<FooterSection> Footer { get; private set; }

        public bool Dirty { get; internal set; }

        public Project() {
            Pages = new PageCollection(this);
            Languages = new Language[0];
            Media = new CustomCollection<MediaItem>(this);
            Footer = new CustomCollection<FooterSection>(this);
            Dirty = false;
        }

        public void ReloadTheme() {
            _Theme = null;
        }

        public Page CreatePage() {
            return new Page(this) { Id = Utilities.NewGuid() };
        }

        public FooterLink CreateFooterLink() {
            return new FooterLink(this);
        }

        public FooterSection CreateFooterSection() {
            return new FooterSection(this);
        }

        public MediaFile CreateMediaFile() {
            return new MediaFile(this) { Id = Utilities.NewGuid() };
        }

        public MediaReference CreateMediaReference() {
            return new MediaReference(this) { Id = Utilities.NewGuid() };
        }

        private void FillAllPagesList(PageCollection pages, List<Page> allPages) {
            foreach (Page page in pages) {
                allPages.Add(page);
                FillAllPagesList(page.Pages, allPages);
            }
        }

        public void Save() {
            Save(this, ProjectFilePath);
        }

        public static void Save(Project project, String path) {
            using(ProjectWriter writer = new ProjectWriter(project, path)) {
                writer.Write();
                project.Dirty = false;
            }
        }

        public static Project Load(string path) {
            using (var reader = new ProjectReader(path)) {
                Project project = reader.Read();
                project.Dirty = false;
                return project;
            }
        }

    }
}
