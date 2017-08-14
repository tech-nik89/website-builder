using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Footer;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class FooterContentForm : Form {

		private readonly Project _Project;

		private Language SelectedLanguage => tscLanguage.SelectedIndex > -1 ? _Project.Languages[tscLanguage.SelectedIndex] : null;

		private bool _RefreshingSection;

		private bool _RefreshingSectionList;

		private FooterSection SelectedSection 
			=> lvwSections.SelectedIndices.Count > 0
			?_Project.Footer[lvwSections.SelectedIndices[0]]
			: null;

		public FooterContentForm(Project project) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			_Project = project;
			RefreshLanguageList();
		}

		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			Icon = IconPack.Current.GetIcon(IconPackIcon.Footer);
			tsbSectionAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
			tsbSectionDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
		}

		private void LocalizeComponent() {
			Text = Strings.Footer;

			tsbSectionAdd.Text = Strings.Add;
			tsbSectionDelete.Text = Strings.Delete;

			clnSectionTitle.Text = Strings.Title;
			clnLinkText.Text = Strings.Text;
			clnLinkURL.Text = Strings.URL;
			clnLinkTarget.Text = Strings.Target;

			gbxLinks.Text = Strings.Links;
			gbxTitle.Text = Strings.Title;

			btnLinkAdd.Text = Strings.Add;
			btnLinkEdit.Text = Strings.Edit;
			btnLinkDelete.Text = Strings.Delete;
		}

		public void RefreshLanguageList() {
			int previousIndex = tscLanguage.SelectedIndex;
			tscLanguage.Items.Clear();

			foreach (var language in _Project.Languages) {
				tscLanguage.Items.Add(language.Description);
			}

			if (_Project.Languages.Length > 0) {
				if (previousIndex > -1 && previousIndex < _Project.Languages.Length) {
					tscLanguage.SelectedIndex = previousIndex;
				}
				else {
					tscLanguage.SelectedIndex = 0;
				}
			}
		}

		private void RefreshSectionList() {
			_RefreshingSectionList = true;
			int index = lvwSections.SelectedIndices.Count > 0 ? lvwSections.SelectedIndices[0] : -1;

			lvwSections.VirtualListSize = 0;
			lvwSections.VirtualListSize = _Project.Footer.Count;

			if (index > -1 && index < lvwSections.VirtualListSize) {
				lvwSections.SelectedIndices.Add(index);
			}

			_RefreshingSectionList = false;
		}

		private void RefreshSection() {
			_RefreshingSection = true;
			txtTitle.Text = String.Empty;
			lvwLinks.VirtualListSize = 0;

			FooterSection section = SelectedSection;
			if (section == null) {
				_RefreshingSection = false;
				return;
			}

			txtTitle.Text = section.Title.Get(SelectedLanguage);
			int index = lvwLinks.SelectedIndices.Count > 0 ? lvwLinks.SelectedIndices[0] : -1;
			
			lvwLinks.VirtualListSize = section.Items.Count;

			if (index > -1 && index < lvwLinks.VirtualListSize) {
				lvwLinks.SelectedIndices.Add(index);
			}

			_RefreshingSection = false;
		}

		private void EditLink() {
			if (lvwLinks.SelectedIndices.Count == 0) {
				return;
			}

			FooterLinkForm form = new FooterLinkForm(_Project, SelectedLanguage, SelectedSection.Items[lvwLinks.SelectedIndices[0]]);
			DialogResult result = form.ShowDialog();

			if (result != DialogResult.OK && form.Link != null) {
				return;
			}
			
			RefreshSection();
		}

		private void tsbSectionAdd_Click(object sender, EventArgs e) {
			_Project.Footer.Add(_Project.CreateFooterSection());
			RefreshSectionList();
		}

		private void tsbSectionDelete_Click(object sender, EventArgs e) {
			if (lvwSections.SelectedIndices.Count == 0) {
				return;
			}

			DialogResult result = MessageBox.Show(Strings.FooterSectionDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.OK) {
				return;
			}

			_Project.Footer.RemoveAt(lvwSections.SelectedIndices[0]);
			RefreshSectionList();
		}

		private void btnLinkAdd_Click(object sender, EventArgs e) {
			FooterLinkForm form = new FooterLinkForm(_Project, SelectedLanguage);
			DialogResult result = form.ShowDialog();

			if (result != DialogResult.OK && form.Link != null) {
				return;
			}

			SelectedSection.Items.Add(form.Link);
			RefreshSection();
		}

		private void btnLinkEdit_Click(object sender, EventArgs e) {
			EditLink();
		}

		private void btnLinkDelete_Click(object sender, EventArgs e) {
			if (SelectedSection == null || lvwLinks.SelectedIndices.Count == 0) {
				return;
			}

			DialogResult result = MessageBox.Show(Strings.FooterLinkDeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.OK) {
				return;
			}

			SelectedSection.Items.RemoveAt(lvwLinks.SelectedIndices[0]);
			RefreshSection();
		}

		private void lvwSections_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			e.Item = new ListViewItem(new String[] {
				_Project.Footer[e.ItemIndex].Title.Get(SelectedLanguage)
			});
		}

		private void lvwLinks_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			if (SelectedSection == null) {
				return;
			}

			FooterLink link = SelectedSection.Items[e.ItemIndex];
			e.Item = new ListViewItem(new String[] {
				link.Text.Get(SelectedLanguage),
				link.DisplayUrl,
				link.Target
			});
		}

		private void tscLanguage_SelectedIndexChanged(object sender, EventArgs e) {
			RefreshSectionList();
			RefreshSection();
		}

		private void txtTitle_TextChanged(object sender, EventArgs e) {
			if (lvwSections.SelectedIndices.Count == 0 || _RefreshingSection) {
				return;
			}

			SelectedSection.Title.Set(SelectedLanguage, txtTitle.Text);
			RefreshSectionList();
		}

		private void lvwSections_SelectedIndexChanged(object sender, EventArgs e) {
			if (_RefreshingSectionList) {
				return;
			}

			RefreshSection();
		}

		private void lvwLinks_DoubleClick(object sender, EventArgs e) {
			EditLink();
		}
	}
}
