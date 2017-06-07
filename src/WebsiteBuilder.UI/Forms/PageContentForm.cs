using System;
using System.Windows.Forms;
using WebsiteBuilder.Core.Localization;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class PageContentForm : Form {

        private readonly Page _Page;

        private readonly Language _Language;
        
        private readonly PageContent _Content;

        private IUserInterface _Control;

        public PageContentForm(Page page, Language language, PageContent content) {
            InitializeComponent();
            LocalizeComponent();
            ApplyIcons();

            _Page = page;
            _Language = language;
            _Content = content;
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            Icon = IconPack.Current.GetIcon(IconPackIcon.EditContent);
            tsbSaveAndClose.Image = IconPack.Current.GetImage(IconPackIcon.SaveClose);
            tsbSave.Image = IconPack.Current.GetImage(IconPackIcon.Save);
            tsbSettings.Image = IconPack.Current.GetImage(IconPackIcon.Settings);
        }

        private void LocalizeComponent() {
            Text = Strings.EditContent;
            tsbSaveAndClose.Text = Strings.SaveAndClose;
            tsbSave.Text = Strings.Save;
            tsbSettings.Text = Strings.ContentSettings;
        }

        private String GetLink() {
            InsertLinkForm form = new InsertLinkForm(_Page.Project);
            var result = form.ShowDialog();

            if (result != DialogResult.OK) {
                return String.Empty;
            }

            return form.Link;
        }

        private void LoadModule() {
            IModule module = PluginManager.LoadModule(_Content, IconPack.Current, _Page.Project, GetLink);

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

            _Control.Data = _Content.LoadData(_Language);
        }

        private void ShowSettings(bool hideFormOnCancel) {
            PageContentSettingsForm form = new PageContentSettingsForm(_Content);
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
            Save();
        }
        
        private void tsbSaveAndClose_Click(object sender, System.EventArgs e) {
            Save();
            Close();
        }

        private void Save() {
            if (_Control == null) {
                return;
            }

            _Content.WriteData(_Language, _Control.Data);
        }

        private void PageContentForm_Shown(object sender, System.EventArgs e) {
            LoadModule();
        }

        private void PageContentForm_Load(object sender, EventArgs e) {
            ConfigHelper.RestoreContentForm(this);
        }

        private void PageContentForm_FormClosing(object sender, FormClosingEventArgs e) {
            ConfigHelper.StoreContentForm(this);
        }
    }
}
