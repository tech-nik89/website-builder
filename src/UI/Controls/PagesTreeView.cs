using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Forms;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WeifenLuo.WinFormsUI.Docking;

namespace WebsiteStudio.UI.Controls {
	public partial class PagesTreeView : DockContent {

		private static readonly String SearchPlaceholder = Strings.Search + " ...";

		private readonly List<TreeItem> _FlatList;

		private bool _Dragging;

		private int _HighlightingIndex;

		private Project _Project;

		private readonly ImageList _ImageList;

		private readonly Action<Page> RefreshContent;

		public readonly Action EnableContentControls;
		
		public event EventHandler TreeChanged;
		
		public event EventHandler<BuildPageEventArgs> BuildPageRequested;

		public Page SelectedPage => SelectedItem?.Page;

		private ToolStripButton _AddButton;
		private ToolStripButton _EditButton;
		private ToolStripButton _DeleteButton;

		private readonly ToolStrip _Toolbar;

		public ToolStrip Toolbar => _Toolbar;

		public Project Project {
			get {
				return _Project;
			}
			set {
				_Project = value;

				if (_Project != null) {
					RefreshTree();
				}
			}
		}

		private TreeItem SelectedItem {
			get {
				if (lvwPages.SelectedIndices.Count == 0) {
					return null;
				}

				return _FlatList[lvwPages.SelectedIndices[0]];
			}
		}

		public Language SelectedLanguage { get; set; }

		private DragDropInfo _DropInfo;

		public PagesTreeView(Action enableContentControls, Action<Page> refreshContent) {
			InitializeComponent();
			LocalizeComponent();
			_Toolbar = CreateToolbar();

			EnableContentControls = enableContentControls;
			RefreshContent = refreshContent;

			ApplyIcons();
			EnableTreeControls();
			EnableContentControls();

			_HighlightingIndex = -1;
			_FlatList = new List<TreeItem>();

			if (IconPack.Current != null) {
				_ImageList = new ImageList() { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };
				_ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.Page));
				_ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.PageStart));
				_ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.PageDisabled));
				_ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.PageStartDisabled));
				lvwPages.SmallImageList = _ImageList;
			}

			Text = Strings.PageStructure;
			DockAreas = DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.DockBottom;
			CloseButton = false;
			CloseButtonVisible = false;

			txtSearch.GotFocus += RemoveSearchPlaceholder;
			txtSearch.LostFocus += AddSearchPlaceholder;
			txtSearch.KeyDown += SearchKeyDown;
			txtSearch.TextChanged += Search;
			AddSearchPlaceholder(txtSearch, null);
		}

		private void Search(object sender, EventArgs e) {
			TextBox box = (TextBox)sender;
			if (!box.Focused) {
				return;
			}
			
			RefreshTree(box.Text);
		}

		private void SearchKeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Escape) {
				TextBox box = (TextBox)sender;
				box.Text = String.Empty;
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
		}

		private void RemoveSearchPlaceholder(object sender, EventArgs e) {
			TextBox box = (TextBox)sender;
			if (box.Text.Equals(SearchPlaceholder)) {
				box.Text = String.Empty;
			}
		}

		private void AddSearchPlaceholder(object sender, EventArgs e) {
			TextBox box = (TextBox)sender;
			if (String.IsNullOrWhiteSpace(box.Text)) {
				box.Text = SearchPlaceholder;
			}
		}

		private ToolStrip CreateToolbar() {
			ToolStrip bar = new ToolStrip();

			if (IconPack.Current == null) {
				return bar;
			}

			_AddButton = new ToolStripButton(Strings.PageAdd, IconPack.Current.GetImage(IconPackIcon.Add));
			_AddButton.Click += (sender, e) => { Add(); };
			bar.Items.Add(_AddButton);

			_EditButton = new ToolStripButton(Strings.PageEdit, IconPack.Current.GetImage(IconPackIcon.Edit));
			_EditButton.Click += (sender, e) => { Edit(); };
			bar.Items.Add(_EditButton);

			_DeleteButton = new ToolStripButton(Strings.PageDelete, IconPack.Current.GetImage(IconPackIcon.Delete));
			_DeleteButton.Click += (sender, e) => { Delete(); };
			bar.Items.Add(_DeleteButton);

			return bar;
		}

		private static int ResolveImageIndex(Page page) {
			if (page.Project.StartPage != null && page.Project.StartPage.Id == page.Id) {
				return page.Disable ? 3 : 1;
			}

			return page.Disable ? 2 : 0;
		}

		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			cmbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			cmbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
			cmbStartPage.Image = IconPack.Current.GetImage(IconPackIcon.PageStart);
			cmbBuildPage.Image = IconPack.Current.GetImage(IconPackIcon.BuildPage);

			cmsDragDropMoveAfter.Image = IconPack.Current.GetImage(IconPackIcon.OrderDown);
			cmsDragDropMoveBefore.Image = IconPack.Current.GetImage(IconPackIcon.OrderUp);
		}

		private void LocalizeComponent() {
			cmsDragDropMoveAfter.Text = Strings.InsertBelow;
			cmsDragDropMoveBefore.Text = Strings.InsertAbove;
			cmsDragDropMoveAsChild.Text = Strings.InsertAsChild;

			cmbDelete.Text = Strings.Delete;
			cmbEdit.Text = Strings.Edit;
			cmbStartPage.Text = Strings.SetStartPage;
			cmbBuildPage.Text = Strings.BuildThisPageOnly;

			clnPathName.Text = Strings.Page;
		}

		private async void RefreshTree() {
			await RefreshTree(null);
		}

		private async Task RefreshTree(String searchText) {
			int index = -1;
			if (lvwPages.SelectedIndices.Count > 0) {
				index = lvwPages.SelectedIndices[0];
			}

			lvwPages.SelectedIndices.Clear();
			
			await Task.Run(() => {
				_FlatList.Clear();
				FillFlatList(Project.Pages, 0, searchText);
			});
			
			lvwPages.VirtualListSize = 0;
			lvwPages.VirtualListSize = _FlatList.Count;

			if (index > -1 && index < _FlatList.Count) {
				lvwPages.SelectedIndices.Add(index);
			}

			EnableTreeControls();
			FireTreeChanged();
		}

		private void FillFlatList(PageCollection pages, int level, String searchText) {
			foreach (Page page in pages) {
				if (IsSearchTextMatch(searchText, page, SelectedLanguage)) {
					_FlatList.Add(new TreeItem(page, level));
				}

				FillFlatList(page.Pages, level + 1, searchText);
			}
		}

		private static bool IsSearchTextMatch(String searchText, Page page, Language language) {
			if (String.IsNullOrWhiteSpace(searchText)) {
				return true;
			}

			if (page.Id.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) > -1) {
				return true;
			}

			if (page.Title.Get(language)?.IndexOf(searchText, StringComparison.CurrentCultureIgnoreCase) > -1) {
				return true;
			}

			return false;
		}

		private void FireTreeChanged() {
			TreeChanged?.Invoke(this, new EventArgs());
		}

		private void lvwPages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			TreeItem item = _FlatList[e.ItemIndex];

			String[] columns = { GetItemText(item) };

			e.Item = new ListViewItem(columns);
			e.Item.ImageIndex = ResolveImageIndex(item.Page);
			
			if (item.Page.Disable) {
				e.Item.ForeColor = Color.Gray;
			}

			if (e.ItemIndex == _HighlightingIndex) {
				e.Item.BackColor = Color.LightGray;
			}
		}

		private static String GetItemText(TreeItem item) {
			StringBuilder builder = new StringBuilder();

			for (int i = 0; i < item.Level; i++) {
				builder.Append("-- ");
			}

			builder.Append(item.Page.PathName);

			return builder.ToString();
		}

		private void Add() {
			PagePropertiesForm form = new PagePropertiesForm(_Project, SelectedLanguage);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				if (lvwPages.SelectedIndices.Count == 0) {
					_Project.Pages.Add(form.Page);
				}
				else {
					TreeItem page = _FlatList[lvwPages.SelectedIndices[0]];
					page.Page.Pages.Add(form.Page);
				}

				RefreshTree();
			}
		}
		
		private void lvwPages_DoubleClick(object sender, EventArgs e) {
			Edit();
		}

		private void cmbDelete_Click(object sender, EventArgs e) {
			Delete();
		}

		private void cmbEdit_Click(object sender, EventArgs e) {
			Edit();
		}

		private void Edit() {
			TreeItem item = SelectedItem;
			if (item == null) {
				return;
			}

			PagePropertiesForm form = new PagePropertiesForm(item.Page, SelectedLanguage);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				RefreshTree();
			}
		}

		private void Delete() {
			TreeItem item = SelectedItem;
			if (item == null) {
				return;
			}

			DialogResult result = MessageBox.Show(Strings.PageDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes) {
				return;
			}

			item.Page.Remove();
			RefreshTree();
		}

		private void lvwPages_SelectedIndexChanged(object sender, EventArgs e) {
			EnableTreeControls();
			RefreshContent(SelectedItem?.Page);
			EnableContentControls();
		}
		
		private void EnableTreeControls() {
			bool canEdit = lvwPages.SelectedIndices.Count > 0;

			_EditButton.Enabled
				= _DeleteButton.Enabled
				= SelectedPage != null;

			cmbEdit.Enabled = canEdit;
			cmbDelete.Enabled = canEdit;
			cmbStartPage.Enabled = canEdit;
			cmbBuildPage.Enabled = canEdit;
		}

		public void RedrawTree() {
			lvwPages.Refresh();
		}
		
		private void lvwPages_ItemDrag(object sender, ItemDragEventArgs e) {
			ListViewItem item = e.Item as ListViewItem;
			if (item == null) {
				return;
			}

			_DropInfo = null;
			_Dragging = true;
			DoDragDrop(item.Index, DragDropEffects.Move);
			_Dragging = false;

			_HighlightingIndex = -1;
			lvwPages.Refresh();
		}

		private void lvwPages_DragOver(object sender, DragEventArgs e) {
			if (!_Dragging || !e.Data.GetDataPresent(typeof(int))) {
				return;
			}

			DragDropInfo info = new DragDropInfo(lvwPages, e);
			HighlightRowIndex(info.CurrentIndex);
			e.Effect = info.Valid ? DragDropEffects.Move : DragDropEffects.None;
		}
		
		private void lvwPages_DragDrop(object sender, DragEventArgs e) {
			if (!_Dragging || !e.Data.GetDataPresent(typeof(int))) {
				return;
			}

			DragDropInfo info = new DragDropInfo(lvwPages, e);
			if (!info.Valid) {
				return;
			}

			ShowDragDropContextMenu(info);
		}
		
		private void ShowDragDropContextMenu(DragDropInfo info) {
			TreeItem draggedItem = _FlatList[info.StartIndex];
			TreeItem droppedOnItem = _FlatList[info.CurrentIndex];

			bool enabled = !droppedOnItem.Page.IsChildOf(draggedItem.Page);

			cmsDragDropMoveAfter.Enabled = enabled;
			cmsDragDropMoveBefore.Enabled = enabled;
			cmsDragDropMoveAsChild.Enabled = enabled;

			cmsDragDrop.Show(info.Point);
			_DropInfo = enabled ? info : null;
		}

		private void HighlightRowIndex(int index) {
			if (_HighlightingIndex != index) {
				_HighlightingIndex = index;
				lvwPages.Refresh();
			}
		}
		
		private void cmsDragDropMoveBefore_Click(object sender, EventArgs e) {
			if (_DropInfo == null) {
				return;
			}

			Page draggedItem = _FlatList[_DropInfo.StartIndex].Page;
			Page droppedOnItem = _FlatList[_DropInfo.CurrentIndex].Page;

			draggedItem.Remove();
			int targetIndex = droppedOnItem.Parent.Pages.IndexOf(droppedOnItem);
			droppedOnItem.Parent.Pages.Insert(targetIndex, draggedItem);

			RefreshTree();
		}

		private void cmsDragDropMoveAfter_Click(object sender, EventArgs e) {
			if (_DropInfo == null) {
				return;
			}

			Page draggedItem = _FlatList[_DropInfo.StartIndex].Page;
			Page droppedOnItem = _FlatList[_DropInfo.CurrentIndex].Page;

			draggedItem.Remove();
			int targetIndex = droppedOnItem.Parent.Pages.IndexOf(droppedOnItem);
			droppedOnItem.Parent.Pages.Insert(targetIndex + 1, draggedItem);

			RefreshTree();
		}

		private void cmsDragDropMoveAsChild_Click(object sender, EventArgs e) {
			if (_DropInfo == null) {
				return;
			}

			Page draggedItem = _FlatList[_DropInfo.StartIndex].Page;
			Page droppedOnItem = _FlatList[_DropInfo.CurrentIndex].Page;

			draggedItem.Remove();
			droppedOnItem.Pages.Add(draggedItem);

			RefreshTree();
		}

		private void tsbStartPage_Click(object sender, EventArgs e) {
			TreeItem item = SelectedItem;
			if (item == null) {
				return;
			}

			Project.StartPage = item.Page;
			RefreshTree();
		}

		private void cmbBuildPage_Click(object sender, EventArgs e) {
			BuildPageRequested?.Invoke(this, new BuildPageEventArgs() {
				Page = SelectedItem.Page,
				Language = SelectedLanguage
			});
		}
	}

	class DragDropInfo {

		public int StartIndex { get; private set; }

		public int CurrentIndex { get; private set; }

		public Point Point { get; private set; }

		public bool Valid => CurrentIndex != -1 && StartIndex != CurrentIndex;

		public DragDropInfo(ListView listView, DragEventArgs e) {
			CurrentIndex = GetCurrentItemIndex(listView, e);
			StartIndex = GetStartItemIndex(e);
			Point = new Point(e.X, e.Y);
		}

		private static int GetStartItemIndex(DragEventArgs e) {
			return (int)e.Data.GetData(typeof(int));
		}

		private static int GetCurrentItemIndex(ListView listView, DragEventArgs e) {
			Point position = listView.PointToClient(new Point(e.X, e.Y));
			ListViewHitTestInfo hit = listView.HitTest(position);
			return hit.Item?.Index ?? -1;
		}
	}

	class TreeItem {

		private readonly Page _Page;

		private readonly int _Level;

		public Page Page => _Page;

		public int Level => _Level;

		public TreeItem(Page page, int level) {
			_Page = page;
			_Level = level;
		}

	}

	public class BuildPageEventArgs : EventArgs {

		public Page Page { get; set; }

		public Language Language { get; set; }

	}
}
