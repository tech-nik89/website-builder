using System;
using System.Text;
using System.Windows.Forms;
using WebsiteStudio.Editors.TinyMCE.Properties;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.TinyMCE {
	public partial class LinkForm : Form {

		private readonly IPluginHelper _PluginHelper;

		public String Link { get; private set; }

		public LinkForm(IPluginHelper pluginHelper) {
			InitializeComponent();
			LocalizeComponent();

			_PluginHelper = pluginHelper;
			DialogResult = DialogResult.Cancel;

			ApplyIcons();
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

		private void BuildLink() {
			StringBuilder link = new StringBuilder();

			link.Append("<a href=\"");
			link.Append(txtURL.Text);
			link.Append("\"");

			if (!String.IsNullOrWhiteSpace(cbxTarget.Text)) {
				link.Append(" target=\"");
				link.Append(cbxTarget.Text);
				link.Append("\"");
			}

			if (!String.IsNullOrWhiteSpace(txtTooltip.Text)) {
				link.Append(" title=\"");
				link.Append(txtTooltip.Text);
				link.Append("\"");
			}

			link.Append(">");
			link.Append(txtDisplayText.Text);
			link.Append("</a>");

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
