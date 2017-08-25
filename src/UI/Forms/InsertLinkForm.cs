﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class InsertLinkForm : Form {

		private readonly Project _Project;

		private readonly Language _Language;

		private readonly ImageList _ImageList;

		public String LinkText { get; private set; }

		public String Link { get; private set; }

		public String MediaId { get; private set; }

		public String PageId { get; private set; }

		public InsertLinkForm(Project project, Language language)
			: this(project, language, Tabs.Media | Tabs.Page) {
		}

		public InsertLinkForm(Project project, Language language, Tabs tabs) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			DialogResult = DialogResult.Cancel;
			_Project = project;
			_Language = language;

			if (!tabs.HasFlag(Tabs.Media)) {
				tabMedia.Hide();
			}

			if (!tabs.HasFlag(Tabs.Page)) {
				tabPage.Hide();
			}

			_ImageList = new ImageList();
			_ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.Page));
			tvwPages.ImageList = _ImageList;

			FillProjectTree(tvwPages.Nodes, _Project.Pages);
			FillMediaList();
		}

		private void ApplyIcons() {
			Icon = IconPack.Current.GetIcon(IconPackIcon.InsertLink);
		}

		private void FillProjectTree(TreeNodeCollection nodes, IEnumerable<Page> pages) {
			foreach (Page page in pages) {
				TreeNode node = nodes.Add(page.PathName);
				node.Tag = page;
				node.ImageIndex = 0;

				FillProjectTree(node.Nodes, page.Pages);
			}
		}

		private void FillMediaList() {
			lvwMedia.VirtualListSize = _Project.Media.Count;
		}

		public void LocalizeComponent() {
			Text = Strings.InsertLink;

			tabPage.Text = Strings.Page;
			tabMedia.Text = Strings.Media;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			clnFile.Text = Strings.File;
		}

		private void btnAccept_Click(object sender, EventArgs e) {
			if (tabCtrl.SelectedTab == tabPage && tvwPages.SelectedNode != null) {
				Page page = tvwPages.SelectedNode.Tag as Page;
				if (page == null) {
					return;
				}

				LinkText = page.Title.Get(_Language);
				Link = String.Format(CompilerConstants.PageLinkFormat, page.Id);
				PageId = page.Id;
			}
			else if (tabCtrl.SelectedTab == tabMedia && lvwMedia.SelectedIndices.Count == 1) {
				MediaItem item = _Project.Media[lvwMedia.SelectedIndices[0]];

				LinkText = item.Name;
				Link = String.Format(CompilerConstants.MediaLinkFormat, item.Id);
				MediaId = item.Id;
			}
			else {
				return;
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void lvwMedia_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			e.Item = new ListViewItem(_Project.Media[e.ItemIndex].Name);
		}

		[Flags]
		public enum Tabs {
			Media = 1,
			Page = 2
		}
	}
}
