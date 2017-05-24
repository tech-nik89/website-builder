using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Validation;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class PagePropertiesForm : Form {

        public Page Page { get; private set; }

        public PagePropertiesForm(Project project)
            : this(project.CreatePage()) {
        }

        public PagePropertiesForm(Page page) {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();

            Page = page;
            FillForm();
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            Icon = IconPack.Current.GetIcon(IconPackIcon.Edit);
        }

        private void LocalizeComponent() {
            Text = Strings.PageProperties;

            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;

            tabDetails.Text = Strings.Details;
            tabTitle.Text = Strings.Title;
            tabMeta.Text = Strings.Meta;
            tabRobots.Text = Strings.Robots;

            clnLanguage.Text = Strings.Language;
            clnTitle.Text = Strings.Title;
            
            clnMetaLanguage.Text = Strings.Language;
            
            lblPathName.Text = Strings.PathName + ":";
            lblRobotsDescription.Text = Strings.RobotsDescription;
            
            chkIncludeInMenu.Text = Strings.IncludeInMenu;
            chkDisable.Text = Strings.Disable;
            chkRobotsNoFollow.Text = Strings.RobotsNoFollow;
            chkRobotsNoIndex.Text = Strings.RobotsNoIndex;
        }

        private void FillForm() {
            FillTitleList();
            FillMetaList();

            txtPathName.Text = Page.PathName;
            chkIncludeInMenu.Checked = Page.IncludeInMenu;
            chkDisable.Checked = Page.Disable;
            chkRobotsNoFollow.Checked = Page.RobotsNoFollow;
            chkRobotsNoIndex.Checked = Page.RobotsNoIndex;
        }

        private void FillTitleList() {
            lvwTitle.Items.Clear();

            foreach(Language language in Page.Project.Languages) {
                lvwTitle.Items.Add(new ListViewItem(new String[] {
                    Page.Title.Get(language),
                    language.Description
                }));
            }
        }

        private void FillMetaList() {
            lvwMeta.Items.Clear();

            foreach (Language language in Page.Project.Languages) {
                lvwMeta.Items.Add(new ListViewItem(language.Description));
            }
        }
        
        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            Page validationPage = Page.Project.CreatePage();
            ApplyToPage(validationPage);

            ValidationHelper<Page> validator = new ValidationHelper<Page>(new PageValidator(validationPage));
            if (!validator.Valid) {
                validator.ShowMessage();
                return;
            }

            ApplyToPage(Page);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void ApplyToPage(Page page) {
            page.PathName = txtPathName.Text;
            page.IncludeInMenu = chkIncludeInMenu.Checked;
            page.Disable = chkDisable.Checked;
            page.RobotsNoFollow = chkRobotsNoFollow.Checked;
            page.RobotsNoIndex = chkRobotsNoIndex.Checked;

            for (int i = 0; i < page.Project.Languages.Length; i++) {
                page.Title.Set(page.Project.Languages[i], lvwTitle.Items[i].Text);
            }
        }

        private void lvwTitle_MouseUp(object sender, MouseEventArgs e) {
            if (lvwTitle.SelectedItems.Count == 0) {
                return;
            }

            lvwTitle.SelectedItems[0].BeginEdit();
        }

        private void txtPathName_KeyPress(object sender, KeyPressEventArgs e) {
            KeysConverter converter = new KeysConverter();
            String character = converter.ConvertToString(e.KeyChar);
            e.Handled = !PageValidator.ValidatePathNameInput(character);
        }

        private void lvwMeta_DoubleClick(object sender, EventArgs e) {
            if (lvwMeta.SelectedIndices.Count == 0) {
                return;
            }

            Language language = Page.Project.Languages[lvwMeta.SelectedIndices[0]];
            String description = Page.MetaDescription.Get(language);
            String[] keywords = Page.MetaKeywords.Get(language);

            MetaForm form = new MetaForm(description, keywords);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            Page.MetaDescription.Set(language, form.Description);
            Page.MetaKeywords.Set(language, form.Keywords);
        }
    }
}
