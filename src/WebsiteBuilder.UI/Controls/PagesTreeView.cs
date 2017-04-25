using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Theming;
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

        public Project Project {
            get {
                return _Project;
            }
            set {
                _Project = value;

                if (_Project != null) {
                    RefreshTree();
                    RefreshLanguageList();
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

        private Language SelectedLanguage {
            get {
                if (tscLanguage.SelectedIndex == -1) {
                    return null;
                }

                return Project.Languages[tscLanguage.SelectedIndex];
            }
        }

        private DragDropInfo _DropInfo;

        public PagesTreeView() {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();
            EnableControls();

            _HighlightingIndex = -1;
            _FlatList = new List<TreeItem>();

            if (IconPack.Current != null) {
                _ImageList = new ImageList() { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };
                _ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.Page));
                _ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.PageStart));
                lvwPages.SmallImageList = _ImageList;
            }
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            tsbAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
            tsbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
            tsbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
            tsbEditContent.Image = IconPack.Current.GetImage(IconPackIcon.EditContent);

            cmbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
            cmbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
            cmbEditContent.Image = IconPack.Current.GetImage(IconPackIcon.EditContent);
        }

        private void LocalizeComponent() {
            tsbAdd.Text = Strings.Add;
            tsbEdit.Text = Strings.Edit;
            tsbDelete.Text = Strings.Delete;
            tsbEditContent.Text = Strings.EditContent;

            clnPathName.Text = Strings.PathName;
            clnTitle.Text = Strings.Title;
            clnLayout.Text = Strings.Layout;

            cmsDragDropMoveAfter.Text = Strings.InsertBelow;
            cmsDragDropMoveBefore.Text = Strings.InsertAbove;
            cmsDragDropMoveAsChild.Text = Strings.InsertAsChild;

            cmbDelete.Text = Strings.Delete;
            cmbEdit.Text = Strings.Edit;
            cmbEditContent.Text = Strings.EditContent;
            cmbStartPage.Text = Strings.SetStartPage;
        }

        public void RefreshLanguageList() {
            int previousIndex = tscLanguage.SelectedIndex;
            tscLanguage.Items.Clear();
            
            foreach(var language in _Project.Languages) {
                tscLanguage.Items.Add(language.Description);
            }

            if (_Project.Languages.Length > 0) {
                if (previousIndex > -1 && previousIndex < _Project.Languages.Length) {
                    tscLanguage.SelectedIndex = previousIndex;
                }
                else {
                    tscLanguage.SelectedIndex = 0;
                }
            }
        }

        private void RefreshLayoutSectionList() {

            TreeItem item = SelectedItem;

            tscLayoutSection.Enabled = false;
            tscLayoutSection.Items.Clear();

            if (item == null) {
                return;
            }

            Layout layout = item.Page.Layout;
            if (layout == null) {
                return;
            }

            for(int i = 0; i < layout.SectionCount; i++) {
                tscLayoutSection.Items.Add(String.Format(Strings.SectionListItem, i + 1));
            }

            if (layout.SectionCount > 0) {
                tscLayoutSection.SelectedIndex = 0;
                tscLayoutSection.Enabled = true;
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

            EnableControls();
        }

        private void FillFlatList(PageCollection pages, int level) {
            foreach (Page page in pages) {
                _FlatList.Add(new TreeItem(page, level));
                FillFlatList(page.Pages, level + 1);
            }
        }

        private void lvwPages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            TreeItem item = _FlatList[e.ItemIndex];

            e.Item = new ListViewItem(new String[] {
                GetItemText(item),
                item.Page.Title.Get(SelectedLanguage),
                item.Page.Layout?.Title ?? String.Empty
            });

            if (item.Page.Project.StartPage != null && item.Page.Project.StartPage.Id == item.Page.Id) {
                e.Item.ImageIndex = 1;
            }
            else {
                e.Item.ImageIndex = 0;
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
            EnableControls();
            RefreshLayoutSectionList();
        }
        
        private void EnableControls() {
            Boolean canEdit = lvwPages.SelectedIndices.Count > 0;

            tsbEdit.Enabled = canEdit;
            tsbDelete.Enabled = canEdit;
            tsbEditContent.Enabled = canEdit;

            cmbEdit.Enabled = canEdit;
            cmbDelete.Enabled = canEdit;
            cmbEditContent.Enabled = canEdit;
            cmbStartPage.Enabled = canEdit;
        }

        private void tscLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            lvwPages.Refresh();
            RefreshLayoutSectionList();
        }

        private void lvwPages_MouseDoubleClick(object sender, MouseEventArgs e) {
            EditContent();
        }

        private void tsbEditContent_Click(object sender, EventArgs e) {
            EditContent();
        }

        private void EditContent() {
            TreeItem item = SelectedItem;
            Language language = SelectedLanguage;
            int layoutSection = tscLayoutSection.SelectedIndex;

            if (item == null || language == null || layoutSection == -1) {
                return;
            }

            PageContentForm form = new PageContentForm(SelectedItem.Page, SelectedLanguage, layoutSection);
            form.ShowDialog();
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
}
