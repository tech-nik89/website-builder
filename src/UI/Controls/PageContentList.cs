using System;
using System.ComponentModel;
using System.Windows.Forms;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.UI.Forms;
using WebsiteStudio.UI.Localization;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class PageContentList : DockContent {

		[Browsable(true)]
		public event EventHandler ContentUpdated;

		public readonly Action EnableContentControls;

		public Page SelectedPage { get; private set; }

		public Language SelectedLanguage { get; set; }

		public bool ContentSelected => lvwContent.SelectedIndices.Count > 0;
		public bool CanMoveUp => ContentSelected && lvwContent.SelectedIndices[0] > 0;
		public bool CanMoveDown => ContentSelected && lvwContent.SelectedIndices[0] < (SelectedPage?.ContentCount - 1);

		public PageContentList(Action enableContentControls) {
			InitializeComponent();
			LocalizeComponent();

			Text = Strings.Content;
			DockAreas = DockAreas.Document;
			CloseButton = false;
			CloseButtonVisible = false;

			EnableContentControls = enableContentControls;
		}

		private void LocalizeComponent() {
			clnContentType.Text = Strings.Type;
			clnContentEditor.Text = Strings.Editor;
		}

		private void FireContentUpdated() {
			ContentUpdated?.Invoke(this, new EventArgs());
		}

		public void RefreshContent(Page page) {
			SelectedPage = page;
			RefreshContentList();
		}

		private void RefreshContentList(int selectedIndex = -1) {
			if (selectedIndex == -1) {
				selectedIndex = lvwContent.SelectedIndices.Count > 0 ? lvwContent.SelectedIndices[0] : -1;
			}

			lvwContent.VirtualListSize = 0;

			if (SelectedPage != null) {
				lvwContent.VirtualListSize = SelectedPage.ContentCount;
			}

			if (selectedIndex > -1 && selectedIndex < lvwContent.VirtualListSize) {
				lvwContent.SelectedIndices.Add(selectedIndex);
			}
		}

		private void lvwContent_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			if (SelectedPage == null) {
				return;
			}

			PageContent content = SelectedPage[e.ItemIndex];
			if (content == null) {
				return;
			}

			String[] columns = {
				content.ModuleType != null ? PluginManager.Modules[content.ModuleType] : "-",
				content.EditorType != null ? PluginManager.Editors[content.EditorType] : "-",
			};

			e.Item = new ListViewItem(columns);
		}

		public void Add() {
			Page page = SelectedPage;
			if (page == null) {
				return;
			}

			PageContent content = page.AddContent();
			RefreshContentList();
			Edit(page, content);
		}
		
		public void Delete() {
			if (lvwContent.SelectedIndices.Count == 0) {
				return;
			}

			SelectedPage?.RemoveContent(lvwContent.SelectedIndices[0]);
			RefreshContentList();
			FireContentUpdated();
		}

		private void lvwContent_DoubleClick(object sender, EventArgs e) {
			Edit();
		}

		public void Edit() {
			if (lvwContent.SelectedIndices.Count == 0) {
				return;
			}
			
			PageContent content = SelectedPage[lvwContent.SelectedIndices[0]];
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

		private void lvwContent_SelectedIndexChanged(object sender, EventArgs e) {
			EnableContentControls();
		}
		
		public void MoveContentUp() {
			if (SelectedPage == null || lvwContent.SelectedIndices.Count == 0 || lvwContent.SelectedIndices[0] <= 0) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(lvwContent.SelectedIndices[0], PageMoveDirection.Up) ?? -1;
			RefreshContentList(newIndex);
			EnableContentControls();
			FireContentUpdated();
		}

		public void MoveContentDown() {
			if (SelectedPage == null || lvwContent.SelectedIndices.Count == 0 || lvwContent.SelectedIndices[0] >= SelectedPage?.ContentCount - 1) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(lvwContent.SelectedIndices[0], PageMoveDirection.Down) ?? -1;
			RefreshContentList(newIndex);
			EnableContentControls();
			FireContentUpdated();
		}
	}
}
