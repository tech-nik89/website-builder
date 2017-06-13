using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Forms;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Controls {
	public partial class PagesTreeView : UserControl {

		private readonly List<TreeItem> _FlatList;

		private bool _Dragging;

		private int _HighlightingIndex;

		private Project _Project;

		private readonly ImageList _ImageList;

		[Browsable(true)]
		public event EventHandler ContentUpdated;

		[Browsable(true)]
		public event EventHandler<BuildPageEventArgs> BuildPageRequested;

		public Page SelectedPage => SelectedItem?.Page;

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

		public PagesTreeView() {
			InitializeComponent();
			LocalizeComponent();
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

			tsbAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			tsbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);

			tsbContentAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbContentEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			tsbContentDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);

			tsbContentUp.Image = IconPack.Current.GetImage(IconPackIcon.OrderUp);
			tsbContentDown.Image = IconPack.Current.GetImage(IconPackIcon.OrderDown);

			cmbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			cmbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
			cmbEditContent.Image = IconPack.Current.GetImage(IconPackIcon.EditContent);
			cmbStartPage.Image = IconPack.Current.GetImage(IconPackIcon.PageStart);
			cmbBuildPage.Image = IconPack.Current.GetImage(IconPackIcon.BuildPage);

			cmsDragDropMoveAfter.Image = IconPack.Current.GetImage(IconPackIcon.OrderDown);
			cmsDragDropMoveBefore.Image = IconPack.Current.GetImage(IconPackIcon.OrderUp);
		}

		private void LocalizeComponent() {
			tsbAdd.Text = Strings.Add;
			tsbEdit.Text = Strings.Edit;
			tsbDelete.Text = Strings.Delete;

			tsbContentAdd.Text = Strings.Add;
			tsbContentEdit.Text = Strings.Edit;
			tsbContentDelete.Text = Strings.Delete;

			tsbContentUp.Text = Strings.Up;
			tsbContentDown.Text = Strings.Down;

			clnPathName.Text = Strings.PathName;
			clnContentType.Text = Strings.Type;
			clnContentEditor.Text = Strings.Editor;

			cmsDragDropMoveAfter.Text = Strings.InsertBelow;
			cmsDragDropMoveBefore.Text = Strings.InsertAbove;
			cmsDragDropMoveAsChild.Text = Strings.InsertAsChild;

			cmbDelete.Text = Strings.Delete;
			cmbEdit.Text = Strings.Edit;
			cmbEditContent.Text = Strings.EditContent;
			cmbStartPage.Text = Strings.SetStartPage;
			cmbBuildPage.Text = Strings.BuildThisPageOnly;
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

		private void RefreshTree() {
			int index = -1;
			if (lvwPages.SelectedIndices.Count > 0) {
				index = lvwPages.SelectedIndices[0];
			}

			lvwPages.SelectedIndices.Clear();

			_FlatList.Clear();
			FillFlatList(Project.Pages, 0);
			
			lvwPages.VirtualListSize = 0;
			lvwPages.VirtualListSize = _FlatList.Count;

			if (index > -1 && index < _FlatList.Count) {
				lvwPages.SelectedIndices.Add(index);
			}

			EnableTreeControls();
			FireContentUpdated();
		}

		private void FireContentUpdated() {
			ContentUpdated?.Invoke(this, new EventArgs());
		}

		private void FillFlatList(PageCollection pages, int level) {
			foreach (Page page in pages) {
				_FlatList.Add(new TreeItem(page, level));
				FillFlatList(page.Pages, level + 1);
			}
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

		private void tsbAdd_Click(object sender, EventArgs e) {
			PagePropertiesForm form = new PagePropertiesForm(_Project);
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

		private void tsbEdit_Click(object sender, EventArgs e) {
			EditPage();
		}

		private void lvwPages_DoubleClick(object sender, EventArgs e) {
			EditPage();
		}

		private void EditPage() {
			TreeItem item = SelectedItem;
			if (item == null) {
				return;
			}

			PagePropertiesForm form = new PagePropertiesForm(item.Page);
			DialogResult result = form.ShowDialog();

			if (result == DialogResult.OK) {
				RefreshTree();
			}
		}

		private void tsbDelete_Click(object sender, EventArgs e) {
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
			RefreshContentList();
			EnableContentControls();
		}
		
		private void EnableTreeControls() {
			bool canEdit = lvwPages.SelectedIndices.Count > 0;

			tsbEdit.Enabled = canEdit;
			tsbDelete.Enabled = canEdit;

			cmbEdit.Enabled = canEdit;
			cmbDelete.Enabled = canEdit;
			cmbStartPage.Enabled = canEdit;
			cmbBuildPage.Enabled = canEdit;
		}

		private void tscLanguage_SelectedIndexChanged(object sender, EventArgs e) {
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

		private void tsbContentAdd_Click(object sender, EventArgs e) {
			Page page = SelectedPage;
			if (page == null) {
				return;
			}

			PageContent content = page.AddContent();
			RefreshContentList();
			EditContent(page, content);
		}

		private void tsbContentEdit_Click(object sender, EventArgs e) {
			EditContent();
		}

		private void tsbContentDelete_Click(object sender, EventArgs e) {
			if (lvwContent.SelectedIndices.Count == 0) {
				return;
			}

			SelectedPage?.RemoveContent(lvwContent.SelectedIndices[0]);
			RefreshContentList();
			FireContentUpdated();
		}

		private void lvwContent_DoubleClick(object sender, EventArgs e) {
			EditContent();
		}

		private void EditContent() {
			if (lvwContent.SelectedIndices.Count == 0) {
				return;
			}

			TreeItem item = SelectedItem;
			if (item == null) {
				return;
			}

			PageContent content = item.Page[lvwContent.SelectedIndices[0]];
			if (content == null) {
				return;
			}

			EditContent(item.Page, content);
		}

		private void EditContent(Page page, PageContent content) {
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

		private void EnableContentControls() {
			bool enable = lvwContent.SelectedIndices.Count > 0;

			tsbContentAdd.Enabled = lvwContent.VirtualListSize > 0;
			tsbContentEdit.Enabled = enable;
			tsbContentDelete.Enabled = enable;

			bool canMoveUp = enable && lvwContent.SelectedIndices[0] > 0;
			bool canMoveDown = enable && lvwContent.SelectedIndices[0] < (SelectedPage?.ContentCount - 1);

			tsbContentUp.Enabled = canMoveUp;
			tsbContentDown.Enabled = canMoveDown;
		}

		private void tsbContentUp_Click(object sender, EventArgs e) {
			MoveContentUp();
		}

		private void tsbContentDown_Click(object sender, EventArgs e) {
			MoveContentDown();
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
