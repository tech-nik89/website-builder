using System;
using System.ComponentModel;
using System.Windows.Forms;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Forms;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class PageContentList : DockContent {

		[Browsable(true)]
		public event EventHandler ContentUpdated;
		
		public Page SelectedPage { get; private set; }

		public Language SelectedLanguage { get; set; }

		public bool ContentSelected => lvwContent.SelectedIndices.Count > 0;
		public bool CanMoveUp => ContentSelected && lvwContent.SelectedIndices[0] > 0;
		public bool CanMoveDown => ContentSelected && lvwContent.SelectedIndices[0] < (SelectedPage?.ContentCount - 1);

		private ToolStripButton _AddButton;
		private ToolStripButton _EditButton;
		private ToolStripButton _DeleteButton;
		private ToolStripButton _MoveUpButton;
		private ToolStripButton _MoveDownButton;

		private readonly ToolStrip _Toolbar;

		public ToolStrip Toolbar => _Toolbar;

		public PagesTreeView Pages { get; set; }

		public PageContentList() {
			InitializeComponent();
			LocalizeComponent();
			
			_Toolbar = CreateToolbar();

			Text = Strings.Content;
			DockAreas = DockAreas.Document;
			CloseButton = false;
			CloseButtonVisible = false;
		}

		private void LocalizeComponent() {
			clnContentType.Text = Strings.Type;
			clnContentEditor.Text = Strings.Editor;
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
			if (lvwContent.SelectedIndices.Count == 0) {
				return;
			}

			if (MessageBox.Show(Strings.ContentDeleteConfirmMessage, Strings.ContentDelete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			SelectedPage?.RemoveContent(lvwContent.SelectedIndices[0]);
			RefreshContentList();
			FireContentUpdated();
		}

		private void lvwContent_DoubleClick(object sender, EventArgs e) {
			Edit();
		}

		private void Edit() {
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

		private void MoveContentUp() {
			if (SelectedPage == null || lvwContent.SelectedIndices.Count == 0 || lvwContent.SelectedIndices[0] <= 0) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(lvwContent.SelectedIndices[0], PageMoveDirection.Up) ?? -1;
			RefreshContentList(newIndex);
			EnableContentControls();
			FireContentUpdated();
		}

		private void MoveContentDown() {
			if (SelectedPage == null || lvwContent.SelectedIndices.Count == 0 || lvwContent.SelectedIndices[0] >= SelectedPage?.ContentCount - 1) {
				return;
			}

			int newIndex = SelectedPage?.MoveContent(lvwContent.SelectedIndices[0], PageMoveDirection.Down) ?? -1;
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
	}
}
