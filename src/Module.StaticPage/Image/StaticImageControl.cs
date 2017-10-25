using System;
using System.Resources;
using System.Windows.Forms;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Localization;

namespace WebsiteStudio.Modules.Image {
	public partial class StaticImageControl : UserControl, IUserInterface {
		
		public String Data {
			get {
				ImageData data = new ImageData();

				data.Id = txtID.Text;
				data.AlternateText = txtAlternateText.Text;

				data.Width = (int)numWidth.Value;
				data.MaxWidth = (int)numMaxWidth.Value;
				data.Height = (int)numHeight.Value;
				data.MaxHeight = (int)numMaxHeight.Value;

				data.WidthUnit = cbxWidth.Text;
				data.MaxWidthUnit = cbxMaxWidth.Text;
				data.HeightUnit = cbxHeight.Text;
				data.MaxHeightUnit = cbxMaxHeight.Text;

				data.Alignment = (StaticImageAlignment)cbxAlignment.SelectedIndex;

				data.Link = txtLink.Text;
				data.LinkTarget = cbxLinkTarget.Text;
				data.FooterText = txtFooterText.Text;

				Dirty = false;

				return ImageData.Serialize(data);
			}
			set {
				ImageData data = new ImageData();

				try {
					data = ImageData.Derserialize(value);
				}
				catch {
				}

				txtID.Text = data.Id;
				txtAlternateText.Text = data.AlternateText;

				numWidth.Value = data.Width;
				numMaxWidth.Value = data.MaxWidth;
				numHeight.Value = data.Height;
				numMaxHeight.Value = data.MaxHeight;

				cbxWidth.Text = data.WidthUnit;
				cbxMaxWidth.Text = data.MaxWidthUnit;
				cbxHeight.Text = data.HeightUnit;
				cbxMaxHeight.Text = data.MaxHeightUnit;

				cbxAlignment.SelectedIndex = (int)data.Alignment;

				txtLink.Text = data.Link;
				cbxLinkTarget.Text = data.LinkTarget;
				txtFooterText.Text = data.FooterText;

				Dirty = false;
			}
		}

		public bool Dirty { get; private set; }

		private readonly IPluginHelper _PluginHelper;

		private static readonly ResourceManager _ResourceManager = new ResourceManager("WebsiteStudio.Modules.Localization.Strings", typeof(StaticImageControl).Assembly);

		public StaticImageControl(IPluginHelper pluginHelper) {
			InitializeComponent();
			LocalizeComponent();
			_PluginHelper = pluginHelper;

			numWidth.Maximum = decimal.MaxValue;
			numMaxWidth.Maximum = decimal.MaxValue;
			numHeight.Maximum = decimal.MaxValue;
			numMaxHeight.Maximum = decimal.MaxValue;

			cbxWidth.Items.AddRange(ImageData.SizeUnits);
			cbxMaxWidth.Items.AddRange(ImageData.SizeUnits);
			cbxHeight.Items.AddRange(ImageData.SizeUnits);
			cbxMaxHeight.Items.AddRange(ImageData.SizeUnits);

			cbxWidth.SelectedIndex = 0;
			cbxMaxWidth.SelectedIndex = 0;
			cbxHeight.SelectedIndex = 0;
			cbxMaxHeight.SelectedIndex = 0;
		}

		private void LocalizeComponent() {
			tabImage.Text = Strings.Image;
			tabLink.Text = Strings.Link;

			gbxGeneral.Text = Strings.General;
			gbxSize.Text = Strings.Size;
			gbxOptions.Text = Strings.Options;

			lblID.Text = Strings.Id + ":";
			lblAlternateText.Text = Strings.AlternateText + ":";

			lblWidth.Text = Strings.Width + ":";
			lblMaxWidth.Text = Strings.MaxWidth + ":";
			lblHeight.Text = Strings.Height + ":";
			lblMaxHeight.Text = Strings.MaxHeight + ":";

			lblAlignment.Text = Strings.Alignment + ":";

			lblLink.Text = Strings.Link + ":";
			lblLinkTarget.Text = Strings.LinkTarget + ":";
			lblFooterText.Text = Strings.FooterText + ":";
			lblFooterTextExplanation.Text = Strings.FooterTextExplanation;

			String[] alignmentItems = Enum.GetNames(typeof(StaticImageAlignment));
			foreach(String item in alignmentItems) {
				String text = _ResourceManager.GetString("Alignment" + item);
				cbxAlignment.Items.Add(text);
			}
		}

		private void btnID_Click(object sender, EventArgs e) {
			ILink link = _PluginHelper.GetLink(GetLinkMode.Images);
			if (link == null) {
				return;
			}

			txtID.Text = link.Link;
		}

		private void Control_Changed(object sender, EventArgs e) {
			Dirty = true;
		}

		private void btnLinkBrowse_Click(object sender, EventArgs e) {
			ILink link = _PluginHelper.GetLink();
			if (link == null) {
				return;
			}

			txtLink.Text = link.Link;
		}
	}
}
