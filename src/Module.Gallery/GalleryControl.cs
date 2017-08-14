using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Gallery.Localization;

namespace WebsiteStudio.Modules.Gallery {
	internal partial class GalleryControl : UserControl, IUserInterface {

		private static readonly String[] SupportedExtensions = { ".jpg", ".jpeg", ".gif", ".png" };

		private const String AutoCopyGalleryDirectoryName = "gallery";

		private const int ImageSize = 64;
		
		private readonly IPluginHelper _PluginHelper;

		private GalleryData _Data;

		private readonly ImageList _ImageList;

		public bool Dirty { get; private set; }

		public String Data {
			get {
				Dirty = false;
				return GalleryData.Serialize(_Data, _PluginHelper);
			}
			set {
				_Data = GalleryData.Deserialize(value, _PluginHelper);
				RefreshList();
				Dirty = false;
			}
		}

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

			bool itemsRemoved = false;
			for (int i = lvwImages.SelectedIndices.Count - 1; i >= 0; i--) {
				_Data.Files.RemoveAt(lvwImages.SelectedIndices[i]);
				itemsRemoved = true;
			}

			RefreshList();

			if (itemsRemoved) {
				Dirty = true;
			}
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
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void lvwImages_DragDrop(object sender, DragEventArgs e) {
			if (!e.Data.GetDataPresent(DataFormats.FileDrop)) {
				return;
			}

			Add((String[])e.Data.GetData(DataFormats.FileDrop));
		}

		private void Add(String[] fileNames) {
			bool fileAdded = false;
			bool copyToProjectDirectory = false;
			bool alreadyAskedForCopyToProjectDirectory = false;

			foreach (String path in fileNames) {
				String filePath = path;

				if (!File.Exists(filePath) || Array.IndexOf(SupportedExtensions, Path.GetExtension(filePath).ToLower()) == -1) {
					continue;
				}

				if (!alreadyAskedForCopyToProjectDirectory && _PluginHelper.CanSuggestCopyToProjectDirectory(filePath)) {
					alreadyAskedForCopyToProjectDirectory = true;
					copyToProjectDirectory = AskUserWantsFilesToBeCopiedToProjectDirectory();
				}

				if (copyToProjectDirectory) {
					String newPath = _PluginHelper.GetFullPath(Path.Combine(AutoCopyGalleryDirectoryName, _PluginHelper.NewGuid() + Path.GetExtension(filePath)));
					FileInfo newFile = new FileInfo(newPath);
					newFile.Directory.Create();

					File.Copy(filePath, newFile.FullName);
					filePath = newFile.FullName;
				}

				_Data.Files.Add(filePath);
				fileAdded = true;
			}

			if (fileAdded) {
				RefreshList();
				Dirty = true;
			}
		}

		private static bool AskUserWantsFilesToBeCopiedToProjectDirectory() {
			DialogResult result = MessageBox.Show(Strings.SuggestCopyToProjectDirectoryMessage, Strings.SuggestCopyToProjectDirectoryTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return result == DialogResult.Yes;
		}

		private void tsbSettings_Click(object sender, EventArgs e) {
			SettingsForm form = new SettingsForm(_PluginHelper.GetIconPack(), _Data.ThumbnailSize, _Data.FullSize, _Data.Title);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			_Data.Title = form.Title;
			_Data.FullSize = form.FullSize;
			_Data.ThumbnailSize = form.ThumbnailSize;
		}
	}
}
