using System;
using System.Windows.Forms;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
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

		private ILink GetLink() {
			InsertLinkForm form = new InsertLinkForm(_Page.Project, _Language);
			var result = form.ShowDialog();

			if (result != DialogResult.OK) {
				return null;
			}

			return new ContentLink(form.Link, form.LinkText);
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
			_Content.Page.LastModified = DateTime.Now;
		}

		private void PageContentForm_Shown(object sender, System.EventArgs e) {
			LoadModule();
		}

		private void PageContentForm_Load(object sender, EventArgs e) {
			ConfigHelper.RestoreContentForm(this);
		}

		private void PageContentForm_FormClosing(object sender, FormClosingEventArgs e) {
			if (_Control!= null && _Control.Dirty) {
				DialogResult result = MessageBox.Show(Strings.DirtyPageConfirmSaveMessage, Strings.DirtyProjectConfirmSaveTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

				switch(result) {
					case DialogResult.Cancel:
						e.Cancel = true;
						return;
					case DialogResult.Yes:
						Save();
						break;
				}
			}

			ConfigHelper.StoreContentForm(this);
		}
	}
}
