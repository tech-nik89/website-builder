using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Footer;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class FooterLinkForm : Form {
		
		public FooterLink Link { get; private set; }

		private readonly Project _Project;

		private readonly Language _Language;

		private FooterLinkType SelectedType => (FooterLinkType)Enum.Parse(typeof(FooterLinkType), cbxType.Text);

		public FooterLinkForm(Project project, Language language)
			: this(project, language, project.CreateFooterLink()) {
		}

		public FooterLinkForm(Project project, Language language, FooterLink link) {
			InitializeComponent();
			LocalizeComponent();

			if (IconPack.Current != null) {
				Icon = IconPack.Current.GetIcon(IconPackIcon.Footer);
			}

			_Project = project;
			_Language = language;
			FillTypeComboBox(link.Type);

			DialogResult = DialogResult.Cancel;
			Link = link;

			txtText.Text = link.Text.Get(language);
			txtURL.Text = link.Data;
			cbxTarget.Text = link.Target;
		}

		private void LocalizeComponent() {
			Text = Strings.Link;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			lblText.Text = Strings.Text;
			lblType.Text = Strings.Type + ":";
			lblTarget.Text = Strings.Target + ":";
			lblURL.Text = Strings.URL + ":";
		}

		private void FillTypeComboBox(FooterLinkType selected) {
			String[] names = Enum.GetNames(typeof(FooterLinkType));
			int index = 0;

			for(int i = 0; i < names.Length; i++) {
				String name = names[i];
				cbxType.Items.Add(name);
				if (name == selected.ToString()) {
					index = i;
				}
			}

			cbxType.SelectedIndex = index;
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			Link.Text.Set(_Language, txtText.Text);
			Link.Data = txtURL.Text;
			Link.Target = cbxTarget.Text;
			Link.Type = SelectedType;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void cbxType_SelectedIndexChanged(object sender, EventArgs e) {
			bool enable = SelectedType != FooterLinkType.External;
			btnBrowse.Enabled = enable;
			txtURL.Enabled = !enable;
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			InsertLinkForm.Tabs tabs = 0;

			switch (SelectedType) {
				case FooterLinkType.Internal:
					tabs |= InsertLinkForm.Tabs.Page;
					break;
				case FooterLinkType.Media:
					tabs |= InsertLinkForm.Tabs.Media;
					break;
			}

			InsertLinkForm form = new InsertLinkForm(_Project, _Language, tabs);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			switch (SelectedType) {
				case FooterLinkType.Internal:
					txtURL.Text = form.PageId;
					break;
				case FooterLinkType.Media:
					txtURL.Text = form.MediaId;
					break;
			}
		}
	}
}
