using System.Windows.Forms;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class PageContentForm : Form {

        private readonly Page _Page;

        private readonly Language _Language;

        private readonly int _LayoutSection;

        private PageContent Content => _Page[_LayoutSection];

        private IUserInterface _Control;

        public PageContentForm(Page page, Language language, int layoutSection) {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();

            _Page = page;
            _Language = language;
            _LayoutSection = layoutSection;
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            Icon = IconPack.Current.GetIcon(IconPack.Icon.EditContent);
            tsbSave.Image = IconPack.Current.GetImage(IconPack.Icon.Save);
            tsbInsertLink.Image = IconPack.Current.GetImage(IconPack.Icon.InsertLink);
            tsbSettings.Image = IconPack.Current.GetImage(IconPack.Icon.Settings);
        }

        private void LocalizeComponent() {
            Text = Strings.EditContent;
            tsbSave.Text = Strings.Save;
            tsbInsertLink.Text = Strings.InsertLink;
            tsbSettings.Text = Strings.ContentSettings;
        }

        private void LoadModule() {
            IModule module = PluginManager.LoadModule(Content);
            if (module == null) {
                ShowSettings(true);
                return;
            }

            _Control = module.GetUserInterface();

            UserControl control = _Control as UserControl;
            if (control == null) {
                ShowSettings(true);
                return;
            }

            control.Dock = DockStyle.Fill;

            pnlModuleContainer.Controls.Clear();
            pnlModuleContainer.Controls.Add(control);

            LoadData();
        }

        private void LoadData() {
            if (_Control == null) {
                return;
            }

            _Control.Data = Content.LoadData(_Language);
        }

        private void ShowSettings(bool hideFormOnCancel) {
            PageContentSettingsForm form = new PageContentSettingsForm(Content);
            DialogResult result = form.ShowDialog();

            if (result == DialogResult.OK) {
                LoadModule();
            }
            else if (hideFormOnCancel) {
                Close();
            }
        }

        private void tsbSettings_Click(object sender, System.EventArgs e) {
            ShowSettings(false);
        }

        private void tsbSave_Click(object sender, System.EventArgs e) {
            if (_Control == null) {
                return;
            }

            Content.WriteData(_Language, _Control.Data);
            Close();
        }
        
        private void PageContentForm_Activated(object sender, System.EventArgs e) {
            LoadModule();
        }

        private void tsbInsertLink_Click(object sender, System.EventArgs e) {
            InsertLinkForm form = new InsertLinkForm(_Page.Project);
            var result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return;
            }

            _Control.Insert(form.Link);
        }
    }
}
