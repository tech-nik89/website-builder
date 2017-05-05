using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.News.Localization;

namespace WebsiteBuilder.Modules.News {
    internal partial class NewsItemForm : Form {

        private readonly IPluginHelper _PluginHelper;

        private readonly IUserInterface _Editor;

        public NewsItem Item { get; private set; }

        public NewsItemForm(IPluginHelper pluginHelper)
            : this(pluginHelper, new NewsItem()) {
        }

        public NewsItemForm(IPluginHelper pluginHelper, NewsItem item) {
            InitializeComponent();
            _PluginHelper = pluginHelper;
            DialogResult = DialogResult.Cancel;
            ApplyLocalization();

            IEditor editor = pluginHelper.CreateEditor();
            _Editor = editor.GetUserInterface();

            UserControl editorCtrl = (UserControl)_Editor;
            editorCtrl.Dock = DockStyle.Fill;
            pnlEditor.Controls.Add(editorCtrl);

            Item = item;
            txtTitle.Text = Item.Title;
            txtAuthor.Text = Item.Author;
            dtpCreated.Value = Item.Created;
            _Editor.Data = Item.Data;
        }

        private void ApplyLocalization() {
            Text = Strings.News;

            gbxDetails.Text = Strings.Details;
            gbxContent.Text = Strings.Content;

            lblTitle.Text = Strings.Title;
            lblAuthor.Text = Strings.Author;
            lblCreated.Text = Strings.Created;

            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            Item.Title = txtTitle.Text;
            Item.Author = txtAuthor.Text;
            Item.Data = _Editor.Data;
            Item.Created = dtpCreated.Value;

            if (String.IsNullOrWhiteSpace(Item.Id)) {
                Item.Id = _PluginHelper.NewGuid();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
