using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.News.Localization;

namespace WebsiteBuilder.Modules.News {
    internal partial class NewsControl : UserControl, IUserInterface {

        private NewsData _Data;

        public String Data {
            get => NewsData.Serialize(_Data);
            set {
                _Data = NewsData.Deserialize(value);
                RefreshList();
            }
        }
        
        private readonly IPluginHelper _PluginHelper;

        public NewsControl(IPluginHelper pluginHelper) {
            InitializeComponent();
            _PluginHelper = pluginHelper;
            ApplyLocalization();
            ApplyIcons();
        }

        private void ApplyIcons() {
            IIconPack iconPack = _PluginHelper.GetIconPack();
            if (iconPack == null) {
                return;
            }

            tsbAdd.Image = iconPack.GetImage(IconPackIcon.Add);
            tsbEdit.Image = iconPack.GetImage(IconPackIcon.Edit);
            tsbDelete.Image = iconPack.GetImage(IconPackIcon.Delete);
            tsbSettings.Image = iconPack.GetImage(IconPackIcon.Settings);
        }

        private void ApplyLocalization() {
            tsbAdd.Text = Strings.Add;
            tsbEdit.Text = Strings.Edit;
            tsbDelete.Text = Strings.Delete;
            tsbSettings.Text = Strings.NewsSettings;

            clnAuthor.Text = Strings.Author;
            clnTitle.Text = Strings.Title;
            clnCreated.Text = Strings.Created;
        }

        public void Insert(String str) {
            // ignore
        }

        private void RefreshList() {
            lvwItems.VirtualListSize = 0;
            lvwItems.VirtualListSize = _Data.Count;
        }

        private void tsbAdd_Click(object sender, EventArgs e) {
            NewsItemForm form = new NewsItemForm(_PluginHelper);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            _Data.Add(form.Item);
            RefreshList();
        }

        private void tsbDelete_Click(object sender, EventArgs e) {
            if (lvwItems.SelectedIndices.Count == 0) {
                return;
            }

            DialogResult result = MessageBox.Show(Strings.DeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) {
                return;
            }

            _Data.RemoveAt(lvwItems.SelectedIndices[0]);
            RefreshList();
        }

        private void tsbEdit_Click(object sender, EventArgs e) {
            EditItem();
        }

        private void lvwItems_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            NewsItem item = _Data[e.ItemIndex];
            String[] columns = { item.Title, item.Author, item.Created.ToString() };
            e.Item = new ListViewItem(columns);
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e) {
            EditItem();
        }

        private void EditItem() {
            if (lvwItems.SelectedIndices.Count == 0) {
                return;
            }

            NewsItem item = _Data[lvwItems.SelectedIndices[0]];

            NewsItemForm form = new NewsItemForm(_PluginHelper, item);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            RefreshList();
        }

        private void tsbSettings_Click(object sender, EventArgs e) {
            NewsSettingsForm form = new NewsSettingsForm(_PluginHelper.GetIconPack(), _Data.LargeItemsCount, _Data.LargeItemsMaxHeight, _Data.ExpanderText);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            _Data.LargeItemsCount = form.LargeItemsCount;
            _Data.LargeItemsMaxHeight = form.LargeItemsMaxHeight;
            _Data.ExpanderText = form.ExpanderText;
        }
    }
}
