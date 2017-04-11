using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.UI.Localization;

namespace WebsiteBuilder.UI.Forms {
    public partial class LanguageForm : Form {

        public Language Language { get; private set; }

        public LanguageForm(Language language) {
            InitializeComponent();
            LocalizeComponent();

            DialogResult = DialogResult.Cancel;
            Language = language;
            FillForm();
        }

        private void LocalizeComponent() {
            Text = Strings.Language;

            lblId.Text = Strings.Id + ":";
            lblDescription.Text = Strings.Description + ":";

            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;
        }

        private void FillForm() {
            txtID.Text = Language.Id;
            txtDescription.Text = Language.Description;
        }

        private void FillLanguage() {
            Language.Id = txtID.Text;
            Language.Description = txtDescription.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            FillLanguage();
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
