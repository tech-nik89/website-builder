﻿using System;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.Core.Publishing;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Plugins;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
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

			txtName.Text = item.Name;
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

			lblName.Text = Strings.Name + ":";
			lblType.Text = Strings.Type + ":";
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
			_Item.Name = txtName.Text;
			_Item.Type = cbxType.GetPublishPlugin();
			_Item.Data = _Control.Data;
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
