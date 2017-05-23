using System;
using System.Linq;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Theming;
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

            lblPathName.Text = Strings.PathName + ":";
            
            chkIncludeInMenu.Text = Strings.IncludeInMenu;
            chkDisable.Text = Strings.Disable;
        }

        private void FillForm() {
            FillTitleList();

            txtPathName.Text = Page.PathName;
            chkIncludeInMenu.Checked = Page.IncludeInMenu;
            chkDisable.Checked = Page.Disable;
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
    }
}
