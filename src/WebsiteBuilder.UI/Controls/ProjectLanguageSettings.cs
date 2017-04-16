using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Forms;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Controls {
    public partial class ProjectLanguageSettings : UserControl {

        private List<Language> _Languages;

        public Language[] Languages {
            get {
                return _Languages.ToArray();
            }
            set {
                _Languages.AddRange(value);
                RefreshList();
            }
        }

        public ProjectLanguageSettings() {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();

            _Languages = new List<Language>();
            EnableControls();
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            tsbAdd.Image = IconPack.Current.GetImage(IconPackIcon.Add);
            tsbEdit.Image = IconPack.Current.GetImage(IconPackIcon.Edit);
            tsbDelete.Image = IconPack.Current.GetImage(IconPackIcon.Delete);
        }

        private void LocalizeComponent() {
            tsbAdd.Text = Strings.Add;
            tsbEdit.Text = Strings.Edit;
            tsbDelete.Text = Strings.Delete;

            clnID.Text = Strings.Id;
            clnDescription.Text = Strings.Description;
        }

        private void RefreshList() {
            lvwLanguages.VirtualListSize = 0;
            lvwLanguages.VirtualListSize = _Languages.Count;
            EnableControls();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            LanguageForm form = new LanguageForm(new Language());
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK) {
                _Languages.Add(form.Language);
                RefreshList();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (lvwLanguages.SelectedIndices.Count == 0) {
                return;
            }

            Language language = _Languages[lvwLanguages.SelectedIndices[0]];
            LanguageForm form = new LanguageForm(language);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK) {
                RefreshList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if (lvwLanguages.SelectedIndices.Count == 0) {
                return;
            }

            _Languages.RemoveAt(lvwLanguages.SelectedIndices[0]);

            RefreshList();
        }

        private void lvwLanguages_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            Language language = _Languages[e.ItemIndex];
            e.Item = new ListViewItem(new String[] {
                language.Id,
                language.Description
            });
        }

        private void lvwLanguages_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void EnableControls() {
            Boolean enabled = lvwLanguages.SelectedIndices.Count > 0;
            tsbEdit.Enabled = enabled;
            tsbDelete.Enabled = enabled;
        }
    }
}
