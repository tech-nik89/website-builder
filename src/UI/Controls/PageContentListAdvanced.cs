using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.UI.Forms;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class PageContentListAdvanced : DockContent {

		[Browsable(true)]
		public event EventHandler ContentUpdated;

		public PagesTreeView Pages { get; set; }

		private int _SelectedIndex;

		public Page SelectedPage { get; private set; }

		public Language SelectedLanguage { get; set; }

		private readonly ToolStrip _Toolbar;

		public ToolStrip Toolbar => _Toolbar;

		private ToolStripButton _AddButton;
		private ToolStripButton _EditButton;
		private ToolStripButton _DeleteButton;
		private ToolStripButton _MoveUpButton;
		private ToolStripButton _MoveDownButton;

		public bool ContentSelected => _SelectedIndex > -1;
		public bool CanMoveUp => ContentSelected && _SelectedIndex > 0;
		public bool CanMoveDown => ContentSelected && _SelectedIndex < (SelectedPage?.ContentCount - 1);
		
		private const String _SvgPhoto = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/PjwhRE9DVFlQRSBzdmcgIFBVQkxJQyAnLS8vVzNDLy9EVEQgU1ZHIDEuMS8vRU4nICAnaHR0cDovL3d3dy53My5vcmcvR3JhcGhpY3MvU1ZHLzEuMS9EVEQvc3ZnMTEuZHRkJz48c3ZnIGVuYWJsZS1iYWNrZ3JvdW5kPSJuZXcgMCAwIDUwMCA1MDAiIGhlaWdodD0iNTAwcHgiIGlkPSJMYXllcl8xIiB2ZXJzaW9uPSIxLjEiIHZpZXdCb3g9IjAgMCA1MDAgNTAwIiB3aWR0aD0iNTAwcHgiIHhtbDpzcGFjZT0icHJlc2VydmUiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiPjxwYXRoIGNsaXAtcnVsZT0iZXZlbm9kZCIgZD0iTTM0MC44NTMsMTQ1LjUxOGMwLDEyLjUzNywxMC4xOCwyMi43MTMsMjIuNzE3LDIyLjcxMyAgYzEyLjUzNSwwLDIyLjcxNS0xMC4xNzcsMjIuNzE1LTIyLjcxM2MwLTEyLjUzOC0xMC4xOC0yMi43MTUtMjIuNzE1LTIyLjcxNUMzNTEuMDMyLDEyMi44MDMsMzQwLjg1MywxMzIuOTgsMzQwLjg1MywxNDUuNTE4eiAgIE0xMTMuNzE4LDI2OC4xNzN2MjQuOTg1YzAsMTEuMjY4LDkuMTc0LDIwLjQ0MSwyMC40NDIsMjAuNDQxaDI1Mi4xMjRsLTg2Ljg2NC04NS40MDNjLTcuMjY4LTcuMjcxLTE4Ljg5OC03LjI3MS0yNi4xNTQsMCAgbC0xOC4zNTksMTguMDc5bC00Ni4zNC00NS4zMzVjLTcuMjY3LTcuMjcxLTIwLjM0Ni03LjI3MS0yNy41MjMsMEwxMTMuNzE4LDI2OC4xNzN6IE0zMS45NDksNDIyLjYyNSAgYzAsMjAuMDc5LDE2LjI2NCwzNi4zNDEsMzYuMzQsMzYuMzQxaDM2My40MjFjMjAuMDc4LDAsMzYuMzQtMTYuMjYyLDM2LjM0LTM2LjM0MVY3Ny4zNzZjMC0yMC4wNzktMTYuMjYyLTM2LjM0Mi0zNi4zNC0zNi4zNDIgIEg2OC4yOWMtMjAuMDc3LDAtMzYuMzQsMTYuMjY0LTM2LjM0LDM2LjM0MlY0MjIuNjI1eiBNOTcuMzY3LDg2LjQ2M2gzMDUuMjY3YzExLjA4NCwwLDE5Ljk5LDguOTAyLDE5Ljk5LDE5Ljk4OXYyMjMuNSAgYzAsMTEuMDgyLTguOTA2LDE5Ljk4Ny0xOS45OSwxOS45ODdIOTcuMzY3Yy0xMS4wODMsMC0xOS45OTEtOC45MDUtMTkuOTkxLTE5Ljk4N3YtMjIzLjUgIEM3Ny4zNzUsOTUuMzY1LDg2LjI4NCw4Ni40NjMsOTcuMzY3LDg2LjQ2M3oiIGZpbGw9IiMwMTAxMDEiIGZpbGwtcnVsZT0iZXZlbm9kZCIvPjwvc3ZnPg==";

		private readonly API _API;

		private readonly CompileHelper _CompileHelper;

		public PageContentListAdvanced() {
			InitializeComponent();

			_Toolbar = CreateToolbar();
			_CompileHelper = new CompileHelper();

			_API = new API(wbContent);
			wbContent.ObjectForScripting = _API;
			_API.Selected += ContentApi_Selected;

			Text = Strings.Content;
			DockAreas = DockAreas.Document;
			CloseButton = false;
			CloseButtonVisible = false;
		}

		private void ContentApi_Selected(object sender, int index) {
			_SelectedIndex = index;
			RefreshContentList();
			EnableContentControls();
		}

		public void RefreshContent(Page page) {
			_SelectedIndex = 0;
			SelectedPage = page;
			RefreshContentList();
			EnableContentControls();
		}

		private void RefreshContentList(int selectedIndex = -1) {
			if (selectedIndex > -1) {
				_SelectedIndex = selectedIndex;
			}

			if (SelectedPage == null) {
				return;
			}

			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<!DOCTYPE html>");
			sb.AppendLine("<html><head>");
			sb.AppendLine("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=Edge\" />");
			sb.AppendLine("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\"></meta>");
			sb.AppendLine("<style type=\"text/css\">");
			sb.AppendLine("html,body{font-family:'Segoe UI';font-size:9pt;cursor:default;}");
			sb.AppendLine(".section{border:2px solid #eee;margin:15px; padding:15px;}");
			sb.AppendLine(".section.selected{background-color:#eee;}");
			sb.AppendLine(".section:not(.selected):hover{background-color:#eee;}");
			sb.AppendLine("</style>");
			
			for (int i = 0; i < SelectedPage.ContentCount; i++) {
				PageContent content = SelectedPage[i];
				if (content == null || content.ModuleType == null || content.EditorType == null) {
					continue;
				}

				IModule module = PluginManager.LoadModule(content, SelectedPage.Project);
				
				sb.Append("<div class=\"section");

				if (i == _SelectedIndex) {
					sb.Append(" selected");
				}

				sb.Append("\" onclick=\"window.external.Select(");
				sb.Append(i);
				sb.Append(")\">");
				sb.Append(module.Compile(content.LoadData(SelectedLanguage), _CompileHelper, true));
				sb.AppendLine("</div>");
			}

			sb.Append("<script type=\"text/javascript\">");
			sb.Append("setTimeout(function(){var imgs=document.getElementsByTagName('img');for(var i=0;i<imgs.length;i++)imgs[i].src='");
			sb.Append(_SvgPhoto);
			sb.Append("';var as=document.getElementsByTagName('a');for(var i=0;i<as.length;i++)as[i].href='javascript:void(0);';}, 5);");
			sb.AppendLine("</script>");

			sb.Append("</body></html>");
			wbContent.DocumentText = sb.ToString();
		}

		private void FireContentUpdated() {
			ContentUpdated?.Invoke(this, new EventArgs());
		}

		private ToolStrip CreateToolbar() {
			ToolStrip bar = new ToolStrip();

			if (IconPack.Current == null) {
				return bar;
			}

			_AddButton = new ToolStripButton(Strings.ContentAdd, IconPack.Current.GetImage(IconPackIcon.Add));
			_AddButton.Click += (sender, e) => { Add(); };
			bar.Items.Add(_AddButton);

			_EditButton = new ToolStripButton(Strings.ContentEdit, IconPack.Current.GetImage(IconPackIcon.Edit));
			_EditButton.Click += (sender, e) => { Edit(); };
			bar.Items.Add(_EditButton);

			_DeleteButton = new ToolStripButton(Strings.ContentDelete, IconPack.Current.GetImage(IconPackIcon.Delete));
			_DeleteButton.Click += (sender, e) => { Delete(); };
			bar.Items.Add(_DeleteButton);

			bar.Items.Add(new ToolStripSeparator());

			_MoveUpButton = new ToolStripButton(Strings.Up, IconPack.Current.GetImage(IconPackIcon.OrderUp));
			_MoveUpButton.Click += (sender, e) => { MoveContentUp(); };
			bar.Items.Add(_MoveUpButton);

			_MoveDownButton = new ToolStripButton(Strings.Down, IconPack.Current.GetImage(IconPackIcon.OrderDown));
			_MoveDownButton.Click += (sender, e) => { MoveContentDown(); };
			bar.Items.Add(_MoveDownButton);

			return bar;
		}

		private void Add() {
			Page page = SelectedPage;
			if (page == null) {
				return;
			}

			PageContent content = page.AddContent();
			RefreshContentList();
			Edit(page, content);
		}

		private void Delete() {
			if (_SelectedIndex == -1) {
				return;
			}

			if (MessageBox.Show(Strings.ContentDeleteConfirmMessage, Strings.ContentDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			SelectedPage?.RemoveContent(_SelectedIndex);
			RefreshContentList();
			FireContentUpdated();
		}

		private void Edit() {
			if (_SelectedIndex == -1) {
				return;
			}

			PageContent content = SelectedPage[_SelectedIndex];
			if (content == null) {
				return;
			}

			Edit(SelectedPage, content);
		}

		private void Edit(Page page, PageContent content) {
			Language language = SelectedLanguage;
			if (language == null) {
				return;
			}

			PageContentForm form = new PageContentForm(page, SelectedLanguage, content);
			form.ShowDialog();

			RefreshContentList();
			FireContentUpdated();
		}

		private void MoveContentUp() {
			if (SelectedPage == null || _SelectedIndex == -1) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(_SelectedIndex, PageMoveDirection.Up) ?? -1;
			RefreshContentList(newIndex);
			EnableContentControls();
			FireContentUpdated();
		}

		private void MoveContentDown() {
			if (SelectedPage == null || _SelectedIndex == -1 || _SelectedIndex >= SelectedPage?.ContentCount - 1) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(_SelectedIndex, PageMoveDirection.Down) ?? -1;
			RefreshContentList(newIndex);
			EnableContentControls();
			FireContentUpdated();
		}

		public void EnableContentControls() {
			_AddButton.Enabled = Pages?.SelectedPage != null;
			_EditButton.Enabled = ContentSelected;
			_DeleteButton.Enabled = ContentSelected;
			_MoveUpButton.Enabled = CanMoveUp;
			_MoveDownButton.Enabled = CanMoveDown;
		}

		[ComVisible(true)]
		public class API {

			private readonly WebBrowser _Browser;

			public event EventHandler<int> Selected;

			public API(WebBrowser browser) {
				_Browser = browser;
			}

			public void Select(int index) {
				Selected?.Invoke(this, index);
			}

		}

		class CompileHelper : ICompileHelper {

			public void AddPageStyleClass(String className) {
				// no style support
			}

			public String Compile(IHtmlElement element) {
				StringBuilder builder = new StringBuilder();

				using (TextWriter writer = new StringWriter(builder)) {
					element.Compile(writer);
				}

				return builder.ToString();
			}

			public void CreateCssFile(String css) {
				// no style support
			}

			public IHtmlElement CreateHtmlElement(String name) {
				return Compiler.CreateHtmlElement(name);
			}

			public void CreateJavaScriptFile(String javaScript) {
				// no style support
			}

			public void CreateJavaScriptFile(String javaScript, bool runAfterLoad) {
				// no style support
			}

			public void CreateLessFile(String less) {
				// no style support
			}

			public String CreateSubPage(String pathName, String content) {
				// no sub page support
				return String.Empty;
			}

			public String GetFilePath(String targetFileName) {
				return String.Empty;
			}

			public bool HasPageFlag(int flag) {
				// assume all flags are already set to
				// prevent modules from adding resources
				return true;
			}

			public void RequireLibrary(Library library) {
				// no library support
			}

			public void SetPageFlag(int flag, bool value) {
				// no flags support
			}

		}

	}
}
