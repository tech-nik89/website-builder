using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.Core.Publishing;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Plugins;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
	public partial class PublishItemForm : Form {

		private readonly Project _Project;

		private readonly PublishItem _Item;

		public PublishItem Item => _Item;

		private IUserInterface _Control;

		public PublishItemForm(Project project)
			: this(new PublishItem(), project) {
		}

		public PublishItemForm(PublishItem item, Project project) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			DialogResult = DialogResult.Cancel;

			_Item = item;
			_Project = project;

			cbxType.FillWithPublishPlugins();
			cbxType.SelectPublishPlugin(item.Type);
		}

		private void ApplyIcons() {
			Icon = IconPack.Current.GetIcon(IconPackIcon.Publish);
		}

		private void LocalizeComponent() {
			Text = Strings.PublishingTarget;
			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;
		}

		private void LoadSettings() {
			Type type = cbxType.GetPublishPlugin();
			IPublish instance = PluginManager.LoadPublisher(type, _Project);
			_Control = instance.GetUserInterface();

			UserControl control = (UserControl)_Control;
			control.Dock = DockStyle.Fill;

			pnlControl.Controls.Clear();
			pnlControl.Controls.Add(control);

			_Control.Data = _Item.Data;
		}

		private void cbxType_SelectedIndexChanged(object sender, EventArgs e) {
			LoadSettings();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			_Item.Type = cbxType.GetPublishPlugin();
			_Item.Data = _Control.Data;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
