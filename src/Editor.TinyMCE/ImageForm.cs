using System;
using System.Windows.Forms;
using System.Xml.Linq;
using WebsiteStudio.Editors.TinyMCE.Properties;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.TinyMCE {
	public partial class ImageForm : Form {

		private readonly IPluginHelper _PluginHelper;

		public String Image { get; private set; }

		private decimal _Ratio;

		public ImageForm(IPluginHelper pluginHelper)
			: this(pluginHelper, null) {
		}

		public ImageForm(IPluginHelper pluginHelper, XElement image) {
			InitializeComponent();
			LocalizeComponent();

			_PluginHelper = pluginHelper;
			DialogResult = DialogResult.Cancel;

			ApplyIcons();

			numHeight.Maximum = numWidth.Maximum = decimal.MaxValue;

			if (image != null) {
				ReadImage(image);
			}
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.Image);
		}

		private void LocalizeComponent() {
			Text = Resources.Image;

			btnAccept.Text = Resources.Accept;
			btnCancel.Text = Resources.Cancel;

			tabGeneral.Text = Resources.General;
			tabSize.Text = Resources.Size;

			lblURL.Text = Resources.URL + ":";
			lblTooltip.Text = Resources.Tooltip + ":";
			lblAlternativeText.Text = Resources.AlternateText + ":";

			lblHeight.Text = Resources.Height + ":";
			lblWidth.Text = Resources.Width + ":";
			chkKeepRatio.Text = Resources.KeepRatio;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			BuildImage();
			Close();
		}

		private void btnBrowseURL_Click(object sender, EventArgs e) {
			ILink link = _PluginHelper.GetLink();
			if (link == null) {
				return;
			}

			txtURL.Text = link.Link;
			txtTooltip.Text = link.Text;
			txtAlternativeText.Text = link.Text;
		}

		private void BuildImage() {
			XElement img = new XElement("img");
			img.Add(new XAttribute("src", txtURL.Text));

			if (!String.IsNullOrWhiteSpace(txtTooltip.Text)) {
				img.Add(new XAttribute("title", txtTooltip.Text));
			}

			if (!String.IsNullOrWhiteSpace(txtAlternativeText.Text)) {
				img.Add(new XAttribute("alt", txtAlternativeText.Text));
			}

			if (numWidth.Value > 0) {
				img.Add(new XAttribute("width", (int)numWidth.Value));
			}

			if (numHeight.Value > 0) {
				img.Add(new XAttribute("height", (int)numHeight.Value));
			}

			Image = img.ToString();
		}

		private void ReadImage(XElement image) {
			txtURL.Text = image.Attribute("src")?.Value;
			txtTooltip.Text = image.Attribute("title")?.Value;
			txtAlternativeText.Text = image.Attribute("alt")?.Value;
			numWidth.Value = Convert.ToDecimal(image.Attribute("width")?.Value);
			numHeight.Value = Convert.ToDecimal(image.Attribute("height")?.Value);

			StoreRatio();
		}

		private void StoreRatio() {
			if (numWidth.Value == 0 || numHeight.Value == 0) {
				_Ratio = 0;
				return;
			}

			_Ratio = numWidth.Value / numHeight.Value;
		}

		private void numWidth_ValueChanged(object sender, EventArgs e) {
			if (!chkKeepRatio.Checked || _Ratio == 0) {
				return;
			}

			numHeight.Value = numWidth.Value / _Ratio;
		}

		private void numHeight_ValueChanged(object sender, EventArgs e) {
			if (!chkKeepRatio.Checked || _Ratio == 0) {
				return;
			}

			numWidth.Value = numHeight.Value * _Ratio;
		}

		private void chkKeepRatio_CheckedChanged(object sender, EventArgs e) {
			StoreRatio();
		}
	}
}
