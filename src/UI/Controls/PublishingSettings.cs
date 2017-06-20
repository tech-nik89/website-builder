using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Core.Publishing;
using WebsiteBuilder.UI.Forms;
using WebsiteBuilder.UI.Localization;

namespace WebsiteBuilder.UI.Controls {
	public partial class PublishingSettings : UserControl {

		public Project Project { get; set; }

		private readonly List<PublishItem> _Items;

		public IEnumerable<PublishItem> Items {
			get {
				return _Items;
			}
			set {
				_Items.Clear();
				_Items.AddRange(value);
				RefreshList();
				UpdateControlsEnabledState();
			}
		}

		public PublishingSettings() {
			InitializeComponent();
			LocalizeComponent();

			_Items = new List<PublishItem>();
		}

		private void LocalizeComponent() {
			btnAdd.Text = Strings.Add;
			btnEdit.Text = Strings.Edit;
			btnDelete.Text = Strings.Delete;

			clnName.Text = Strings.Name;
			clnType.Text = Strings.Type;
		}

		private void RefreshList() {
			lvwItems.VirtualListSize = 0;
			lvwItems.VirtualListSize = _Items.Count;
		}

		private void UpdateControlsEnabledState() {
			bool enabled = lvwItems.SelectedIndices.Count > 0;
			btnEdit.Enabled = enabled;
			btnDelete.Enabled = enabled;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			PublishItemForm form = new PublishItemForm(Project);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			_Items.Add(form.Item);
			RefreshList();
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0) {
				return;
			}

			PublishItem item = _Items[lvwItems.SelectedIndices[0]];
			PublishItemForm form = new PublishItemForm(item, Project);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			RefreshList();
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0) {
				return;
			}

			if (MessageBox.Show(Strings.PublishItemDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			_Items.RemoveAt(lvwItems.SelectedIndices[0]);
			RefreshList();
		}

		private void lvwItems_SelectedIndexChanged(object sender, EventArgs e) {
			UpdateControlsEnabledState();
		}

		private void lvwItems_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			PublishItem item = _Items[e.ItemIndex];
			String type = PluginManager.Publishers[item.Type];
			e.Item = new ListViewItem(new String[] { item.Name, type });
		}
	}
}
