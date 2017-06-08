using System;
using System.Drawing;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Modules.Gallery.Localization;

namespace WebsiteBuilder.Modules.Gallery {
	public partial class SettingsForm : Form {

		public Size ThumbnailSize { get; private set; }

		public Size FullSize { get; private set; }

		public String Title { get; private set; }

		public SettingsForm(IIconPack iconPack, Size thumbnailSize, Size fullSize, String title) {
			InitializeComponent();
			LocalizeComponent();

			txtTitle.Text = title;

			numThumbnailHeight.Maximum = decimal.MaxValue;
			numThumbnailWidth.Maximum = decimal.MaxValue;
			numFullHeight.Maximum = decimal.MaxValue;
			numFullWidth.Maximum = decimal.MaxValue;

			numThumbnailHeight.Value = thumbnailSize.Height;
			numThumbnailWidth.Value = thumbnailSize.Width;
			numFullHeight.Value = fullSize.Height;
			numFullWidth.Value = fullSize.Width;

			Icon = iconPack.GetIcon(IconPackIcon.Settings);
			DialogResult = DialogResult.Cancel;
		}

		private void LocalizeComponent() {
			Text = Strings.GallerySettings;

			gbxTitle.Text = Strings.Title;
			gbxThumbnailSize.Text = Strings.ThumbnailSize;
			gbxFullSize.Text = Strings.FullSize;

			lblFullHeight.Text = Strings.Height;
			lblFullWidth.Text = Strings.Width;

			lblThumbnailHeight.Text = Strings.Height;
			lblThumbnailWidth.Text = Strings.Width;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			ThumbnailSize = new Size((int)numThumbnailWidth.Value, (int)numThumbnailHeight.Value);
			FullSize = new Size((int)numFullWidth.Value, (int)numFullHeight.Value);
			Title = txtTitle.Text;

			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
