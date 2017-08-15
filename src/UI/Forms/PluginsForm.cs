﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class PluginsForm : Form {

		private readonly PluginInfo[] _Plugins;

		public PluginsForm() {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();
			_Plugins = PluginManager.AllPlugins.ToArray();
		}

		private void ApplyIcons() {
			Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.Plugin);
		}

		private void LocalizeComponent() {
			Text = Strings.Plugins;

			clnName.Text = Strings.Name;
			clnVersion.Text = Strings.Version;
			clnAuthor.Text = Strings.Author;

			tslDoubleClickForDetails.Text = Strings.DoubleClickForDetails;
		}

		private void PluginsForm_Load(object sender, EventArgs e) {
			
			String[] groupNames = _Plugins.Select(plugin => plugin.Category).Distinct().ToArray();
			Dictionary<String, ListViewGroup> groups = new Dictionary<String, ListViewGroup>();

			foreach(String groupName in groupNames) {
				ListViewGroup group = lvwPlugins.Groups.Add(groupName, groupName);
				groups[groupName] = group;
			}

			foreach(PluginInfo info in _Plugins) {
				String[] columns = { info.Name, info.Version, info.Author };
				ListViewItem item = new ListViewItem(columns);
				item.Group = groups[info.Category];
				lvwPlugins.Items.Add(item);
			}
		}

		private void lvwPlugins_DoubleClick(object sender, EventArgs e) {
			if (lvwPlugins.SelectedIndices.Count == 0) {
				return;
			}

			PluginInfo info = _Plugins[lvwPlugins.SelectedIndices[0]];
			PluginDetailsForm form = new PluginDetailsForm();

			form.License = info.LicenseInfo;
			form.ShowDialog();
		}
	}
}
