﻿using System;
using System.IO;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Tools;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class MediaForm : Form {

		private readonly Project _Project;

		public MediaForm(Project project) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			_Project = project;

			FillDeployToOutputComboBox();
			EnableControls();
			RefreshListView();
		}

		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			Icon = IconPack.Current.GetIcon(IconPackIcon.Media);

			tsbAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
			tsbRemove.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
		}

		public void LocalizeComponent() {
			Text = Strings.Media;

			tsbAdd.Text = Strings.Add;
			tsbAddImport.Text = Strings.ImportIntoProject;
			tsbAddReference.Text = Strings.AddReference;
			tsbEdit.Text = Strings.Edit;
			tsbRemove.Text = Strings.Delete;
			tslDeployToOutput.Text = Strings.DeployToOutput + ":";

			clnName.Text = Strings.File;
			clnSize.Text = Strings.Size;
			clnType.Text = Strings.Type;
			clnDeployToOutput.Text = Strings.DeployToOutput;
		}

		private void FillDeployToOutputComboBox() {
			tscDeployToOutput.Items.Clear();
			tscDeployToOutput.Items.Add(Strings.Yes);
			tscDeployToOutput.Items.Add(Strings.No);
		}

		private void tsbAddReference_Click(object sender, System.EventArgs e) {
			Add(true);
		}

		private void tsbAddImport_Click(object sender, System.EventArgs e) {
			Add(false);
		}

		private void tsbRemove_Click(object sender, System.EventArgs e) {
			Remove();
		}

		private void lvwFiles_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			MediaItem item = _Project.Media[e.ItemIndex];
			e.Item = new ListViewItem(new String[] {
				item.Name,
				item.Size.FormatFileSize(),
				LocalizeMediaType(item.GetType()),
				item.DeployToOutput ? Strings.Yes : Strings.No
			});
		}

		private static String LocalizeMediaType(Type type) {
			if (type.Name == typeof(MediaFile).Name) {
				return Strings.Included;
			}
			else if (type.Name == typeof(MediaReference).Name) {
				return Strings.Reference;
			}

			return String.Empty;
		}

		private void Add(bool reference) {
			var result = ofdFile.ShowDialog();
			if (result != DialogResult.OK) {
				return;
			}

			FileInfo info = new FileInfo(ofdFile.FileName);
			if (!info.Exists) {
				return;
			}

			MediaItem file;
			if (reference) {
				MediaReference mediaReference = _Project.CreateMediaReference();
				mediaReference.FilePath = info.FullName;
				file = mediaReference;
			}
			else {
				MediaFile mediaFile = _Project.CreateMediaFile();
				mediaFile.FileName = info.Name;
				mediaFile.Data = File.ReadAllBytes(info.FullName);
				file = mediaFile;
			}

			_Project.Media.Add(file);
			RefreshListView();
		}

		private void Remove() {
			if (lvwFiles.SelectedIndices.Count == 0) {
				return;
			}

			if (MessageBox.Show(Strings.Delete, Strings.MediaDeleteConfirmMessage, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			foreach (int index in lvwFiles.SelectedIndices) {
				_Project.Media.RemoveAt(index);
			}
			
			RefreshListView();
		}

		private void RefreshListView() {
			int[] selectedIndices = new int[lvwFiles.SelectedIndices.Count];
			lvwFiles.SelectedIndices.CopyTo(selectedIndices, 0);

			lvwFiles.VirtualListSize = 0;
			lvwFiles.VirtualListSize = _Project.Media.Count;

			foreach (int index in selectedIndices) {
				if (index < _Project.Media.Count) {
					lvwFiles.SelectedIndices.Add(index);
				}
			}
		}

		private void EnableControls() {
			tsbRemove.Enabled = lvwFiles.SelectedIndices.Count == 1;

			if (lvwFiles.SelectedIndices.Count == 1) {
				MediaItem item = _Project.Media[lvwFiles.SelectedIndices[0]];
				bool isReference = item is MediaReference;

				tscDeployToOutput.Enabled = isReference;
				tslDeployToOutput.Enabled = isReference;
				tsbEdit.Enabled = item is MediaFile;

				tscDeployToOutput.SelectedIndex = item.DeployToOutput ? 0 : 1;
			}
			else {
				tscDeployToOutput.Enabled = false;
				tslDeployToOutput.Enabled = false;
				tsbEdit.Enabled = false;
			}
		}
		
		private void lvwFiles_SelectedIndexChanged(object sender, EventArgs e) {
			EnableControls();
		}

		private void tscDeployToOutput_SelectedIndexChanged(object sender, EventArgs e) {
			if (lvwFiles.SelectedIndices.Count != 1) {
				return;
			}

			MediaReference item = _Project.Media[lvwFiles.SelectedIndices[0]] as MediaReference;
			if (item == null) {
				return;
			}

			item.DeployToOutput = tscDeployToOutput.SelectedIndex == 0;
			RefreshListView();
		}

		private void tsbEdit_Click(object sender, EventArgs e) {
			if (lvwFiles.SelectedIndices.Count != 1) {
				return;
			}

			MediaFile item = _Project.Media[lvwFiles.SelectedIndices[0]] as MediaFile;
			if (item == null) {
				return;
			}

			var result = ofdFile.ShowDialog();
			if (result != DialogResult.OK) {
				return;
			}

			FileInfo info = new FileInfo(ofdFile.FileName);

			item.FileName = info.Name;
			item.Data = File.ReadAllBytes(info.FullName);

			RefreshListView();
		}
	}
}
