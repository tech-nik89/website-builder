﻿using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
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

		private bool SingleItemSelected => lvwImages.SelectedIndices.Count == 1;
		private bool CanMoveUp => SingleItemSelected && lvwImages.SelectedIndices[0] > 0;
		private bool CanMoveDown => SingleItemSelected && lvwImages.SelectedIndices[0] < (_Data?.Files.Count - 1);

		public GalleryControl(IPluginHelper pluginHelper) {
			InitializeComponent();

			_PluginHelper = pluginHelper;
			LocalizeComponent();

			_Data = new GalleryData();
			_ImageList = new ImageList() { ImageSize = new Size(ImageSize, ImageSize), ColorDepth = ColorDepth.Depth32Bit };
			
			lvwImages.LargeImageList = _ImageList;
			lvwImages.View = View.LargeIcon;

			lblLoading.Visible = false;
			lblLoading.BackColor = Color.Transparent;

			EnableControls();
		}

		private void LocalizeComponent() {
			tsbAdd.Text = Strings.Add;
			tsbDelete.Text = Strings.Remove;
			tsbUp.Text = Strings.Up;
			tsbDown.Text = Strings.Down;
			tsbSettings.Text = Strings.GallerySettings;
			lblLoading.Text = Strings.Loading;
			
			tsbViewLargeIcon.Text = Strings.ViewLargeIcons;
			tsbViewList.Text = Strings.ViewList;
			tsbViewDetails.Text = Strings.ViewDetails;

			clnFile.Text = Strings.File;
			clnSize.Text = Strings.Size;

			IIconPack iconPack = _PluginHelper.GetIconPack();
			tsbAdd.Image = iconPack.GetImage(IconPackIcon.Add);
			tsbDelete.Image = iconPack.GetImage(IconPackIcon.Delete);
			tsbUp.Image = iconPack.GetImage(IconPackIcon.OrderUp);
			tsbDown.Image = iconPack.GetImage(IconPackIcon.OrderDown);
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
			tsbUp.Enabled = CanMoveUp;
			tsbDown.Enabled = CanMoveDown;
		}

		private void Delete() {
			if (lvwImages.SelectedIndices.Count == 0) {
				return;
			}

			bool itemsRemoved = false;
			bool askedForDeletingFiles = false;
			bool deleteFiles = false;
			
			for (int i = lvwImages.SelectedIndices.Count - 1; i >= 0; i--) {
				int index = lvwImages.SelectedIndices[i];
				String path = _Data.Files[index];
				bool isBelowProject = _PluginHelper.IsBelowProject(path);

				if (isBelowProject && !askedForDeletingFiles && !deleteFiles) {
					deleteFiles = MessageBox.Show(Strings.SuggestDeleteFromProjectDirectoryMessage, Strings.SuggestDeleteFromProjectDirectoryTitle,
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
					askedForDeletingFiles = true;
				}

				if (isBelowProject && deleteFiles) {
					File.Delete(path);
				}

				_Data.Files.Remove(path);
				itemsRemoved = true;
			}

			RefreshList();

			if (itemsRemoved) {
				Dirty = true;
			}
		}

		private async void RefreshList() {
			lvwImages.VirtualListSize = 0;
			lvwImages.Enabled = false;
			lblLoading.Visible = true;

			await CreateThumbnailsAsync();

			lblLoading.Visible = false;
			lvwImages.Enabled = true;
			lvwImages.VirtualListSize = _Data.Files.Count;
		}

		private async Task CreateThumbnailsAsync() {
			_ImageList.Images.Clear();
			Size thumbSize = lvwImages.TileSize;
			Image[] images = new Image[_Data.Files.Count];

			await Task.Run(() => {
				for (int i = 0; i < images.Length; i++) {
					using (Image image = Image.FromFile(_Data.Files[i])) {
						images[i] = ImageHelper.ResizeImageToSquare(image, ImageSize);
					}
				}
			});

			_ImageList.Images.AddRange(images);
		}

		private void lvwImages_SelectedIndexChanged(object sender, EventArgs e) {
			EnableControls();
		}

		private void lvwImages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			String path = _Data.Files[e.ItemIndex];
			FileInfo info = new FileInfo(path);

			ListViewItem item = new ListViewItem(new String[] { info.Name, _PluginHelper.GetFormattedFileSize(info.Length) });
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

		private void tsbViewLargeIcon_Click(object sender, EventArgs e) {
			lvwImages.View = View.LargeIcon;
		}

		private void tsbViewList_Click(object sender, EventArgs e) {
			lvwImages.View = View.List;
		}

		private void tsbViewDetails_Click(object sender, EventArgs e) {
			lvwImages.View = View.Details;
		}

		private void tsbUp_Click(object sender, EventArgs e) {
			if (!CanMoveUp) {
				return;
			}

			int index = lvwImages.SelectedIndices[0];
			String item = _Data.Files[index];
			_Data.Files.Remove(item);

			index--;
			_Data.Files.Insert(index, item);
			lvwImages.SelectedIndices.Clear();
			lvwImages.SelectedIndices.Add(index);

			RefreshList();
		}

		private void tsbDown_Click(object sender, EventArgs e) {
			if (!CanMoveDown) {
				return;
			}

			int index = lvwImages.SelectedIndices[0];
			String item = _Data.Files[index];
			_Data.Files.Remove(item);

			index++;
			_Data.Files.Insert(index, item);
			lvwImages.SelectedIndices.Clear();
			lvwImages.SelectedIndices.Add(index);

			RefreshList();
		}
	}
}
