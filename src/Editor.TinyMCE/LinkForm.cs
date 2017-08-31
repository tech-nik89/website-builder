using System;
using System.Windows.Forms;
using System.Xml.Linq;
using WebsiteStudio.Editors.TinyMCE.Properties;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.TinyMCE {
	public partial class LinkForm : Form {

		private readonly IPluginHelper _PluginHelper;

		public String Link { get; private set; }

		public LinkForm(IPluginHelper pluginHelper)
			: this(pluginHelper, null) {
		}

		public LinkForm(IPluginHelper pluginHelper, XElement htmlElement) {
			InitializeComponent();
			LocalizeComponent();

			_PluginHelper = pluginHelper;
			DialogResult = DialogResult.Cancel;

			ApplyIcons();

			if (htmlElement != null) {
				ReadLink(htmlElement);
			}
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.InsertLink);
		}

		private void LocalizeComponent() {
			Text = Resources.Link;

			tabGeneral.Text = Resources.General;
			tabOptions.Text = Resources.Options;

			lblURL.Text = Resources.URL + ":";
			lblDisplayText.Text = Resources.DisplayText + ":";
			lblTooltip.Text = Resources.Tooltip + ":";
			lblTarget.Text = Resources.Target + ":";

			btnAccept.Text = Resources.Accept;
			btnCancel.Text = Resources.Cancel;
		}

		private void ReadLink(XElement link) {
			txtDisplayText.Text = link.Value;
			txtURL.Text = link.Attribute("href")?.Value;
			cbxTarget.Text = link.Attribute("target")?.Value;
			txtTooltip.Text = link.Attribute("title")?.Value;
		}

		private void BuildLink() {
			XElement link = new XElement("a", txtDisplayText.Text);
			link.Add(new XAttribute("href", txtURL.Text));
			
			if (!String.IsNullOrWhiteSpace(cbxTarget.Text)) {
				link.Add(new XAttribute("target", cbxTarget.Text));
			}

			if (!String.IsNullOrWhiteSpace(txtTooltip.Text)) {
				link.Add(new XAttribute("title", txtTooltip.Text));
			}

			Link = link.ToString();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			BuildLink();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnBrowseURL_Click(object sender, EventArgs e) {
			ILink link = _PluginHelper.GetLink();
			if (link == null) {
				return;
			}

			txtURL.Text = link.Link;
			txtDisplayText.Text = link.Text;
		}
	}
}
