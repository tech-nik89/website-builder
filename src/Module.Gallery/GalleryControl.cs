using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Gallery.Localization;

namespace WebsiteBuilder.Modules.Gallery {
    public partial class GalleryControl : UserControl, IUserInterface {

        private static readonly String[] SupportedExtensions = { ".jpg", ".jpeg", ".gif", ".png" };

        private const int ImageSize = 64;

        public Boolean SupportsMediaLinks => false;

        private readonly IPluginHelper _PluginHelper;

        private GalleryData _Data;

        private readonly ImageList _ImageList;

        public GalleryControl(IPluginHelper pluginHelper) {
            InitializeComponent();

            _PluginHelper = pluginHelper;
            LocalizeComponent();

            _Data = new GalleryData();
            _ImageList = new ImageList() { ImageSize = new Size(ImageSize, ImageSize), ColorDepth = ColorDepth.Depth32Bit };
            
            lvwImages.LargeImageList = _ImageList;

            EnableControls();
        }

        private void LocalizeComponent() {
            tsbAdd.Text = Strings.Add;
            tsbDelete.Text = Strings.Remove;
            tsbSettings.Text = Strings.GallerySettings;

            IIconPack iconPack = _PluginHelper.GetIconPack();
            tsbAdd.Image = iconPack.GetImage(IconPackIcon.Add);
            tsbDelete.Image = iconPack.GetImage(IconPackIcon.Delete);
            tsbSettings.Image = iconPack.GetImage(IconPackIcon.Settings);
        }

        public String Data {
            get {
                return GalleryData.Serialize(_Data, _PluginHelper);
            }
            set {
                _Data = GalleryData.Deserialize(value, _PluginHelper);
                RefreshList();
            }
        }

        public void ApplyMediaLink(String str) {
            
        }

        private void tsbAdd_Click(object sender, EventArgs e) {
            if (ofdImages.ShowDialog() != DialogResult.OK) {
                return;
            }

            Add(ofdImages.FileNames);
        }

        private void tsbDelete_Click(object sender, EventArgs e) {
            Delete();
        }

        private void EnableControls() {
            bool enabled = lvwImages.SelectedIndices.Count > 0;
            tsbDelete.Enabled = enabled;
        }

        private void Delete() {
            if (lvwImages.SelectedIndices.Count == 0) {
                return;
            }

            for (int i = lvwImages.SelectedIndices.Count - 1; i >= 0; i--) {
                _Data.Files.RemoveAt(lvwImages.SelectedIndices[i]);
            }

            RefreshList();
        }

        private void RefreshList() {
            lvwImages.VirtualListSize = 0;
            _ImageList.Images.Clear();

            Size thumbSize = lvwImages.TileSize;

            foreach(String path in _Data.Files) {
                using (Image image = Image.FromFile(path)) {
                    int height = image.Height * ImageSize / image.Width;
                    _ImageList.Images.Add(ImageHelper.ResizeImageToSquare(image, ImageSize));
                }
            }

            lvwImages.VirtualListSize = _Data.Files.Count;
        }

        private void lvwImages_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void lvwImages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            String path = _Data.Files[e.ItemIndex];
            String name = Path.GetFileNameWithoutExtension(path);
            ListViewItem item = new ListViewItem(name);
            item.ImageIndex = e.ItemIndex;

            e.Item = item;
        }

        private void lvwImages_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete) {
                Delete();
            }
        }

        private void lvwImages_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void lvwImages_DragDrop(object sender, DragEventArgs e) {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) {
                return;
            }

            Add((String[])e.Data.GetData(DataFormats.FileDrop));
        }

        private void Add(String[] fileNames) {
            Boolean fileAdded = false;

            foreach (String path in fileNames) {
                if (!File.Exists(path) || Array.IndexOf(SupportedExtensions, Path.GetExtension(path).ToLower()) == -1) {
                    continue;
                }

                _Data.Files.Add(path);
                fileAdded = true;
            }

            if (fileAdded) {
                RefreshList();
            }
        }

        private void tsbSettings_Click(object sender, EventArgs e) {
            SettingsForm form = new SettingsForm(_PluginHelper.GetIconPack(), _Data.ThumbnailSize, _Data.FullSize);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            _Data.FullSize = form.FullSize;
            _Data.ThumbnailSize = form.ThumbnailSize;
        }
    }
}
