using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.Core.Localization;
using WebsiteStudio.Core.Media;
using WebsiteStudio.Core.Pages;
using WebsiteStudio.Interface.Content;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI.Forms {
	public partial class GetLinkForm : Form {

		private readonly Project _Project;

		private readonly Language _Language;

		private readonly ImageList _ImageList;

		private readonly List<MediaItem> _FilteredMedia;

		private readonly GetLinkMode _Mode;

		public String LinkText { get; private set; }

		public String Link { get; private set; }

		public String MediaId { get; private set; }

		public String PageId { get; private set; }

		public GetLinkForm(Project project, Language language)
			: this(project, language, GetLinkMode.Files | GetLinkMode.Images | GetLinkMode.Pages) {
		}

		public GetLinkForm(Project project, Language language, GetLinkMode mode) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			DialogResult = DialogResult.Cancel;
			_Project = project;
			_Language = language;
			_Mode = mode;
			_FilteredMedia = new List<MediaItem>();

			if (!mode.HasFlag(GetLinkMode.Files) && !mode.HasFlag(GetLinkMode.Images)) {
				tabCtrl.TabPages.Remove(tabMedia);
			}

			if (!mode.HasFlag(GetLinkMode.Pages)) {
				tabCtrl.TabPages.Remove(tabPage);
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

		private void txtSearch_KeyUp(object sender, EventArgs e) {
			if (tabCtrl.SelectedTab == tabMedia) {
				FillMediaList();
			}
			else if (tabCtrl.SelectedTab == tabPage) {
				tvwPages.Nodes.Clear();
				FillProjectTree(tvwPages.Nodes, _Project.Pages);
			}
		}

		private bool FillProjectTree(TreeNodeCollection nodes, IEnumerable<Page> pages) {
			bool childVisible = false;

			foreach (Page page in pages) {
				TreeNode node = new TreeNode(page.PathName);
				node.Tag = page;
				node.ImageIndex = 0;
				node.Expand();

				if (FillProjectTree(node.Nodes, page.Pages)
					|| String.IsNullOrWhiteSpace(txtSearch.Text)
					|| page.PathName.Contains(txtSearch.Text)) {

					nodes.Add(node);
					childVisible = true;
				}
			}

			return childVisible;
		}

		private void FillMediaList() {
			_FilteredMedia.Clear();
			List<MediaItem> media = new List<MediaItem>();
			
			if (_Mode.HasFlag(GetLinkMode.Files) && _Mode.HasFlag(GetLinkMode.Images)) {
				media.AddRange(_Project.Media);
			}
			else if (_Mode.HasFlag(GetLinkMode.Images)) {
				media.AddRange(_Project.Media.Where(x => x.IsImage));
			}
			else if (_Mode.HasFlag(GetLinkMode.Files)) {
				media.AddRange(_Project.Media.Where(x => !x.IsImage));
			}

			if (!String.IsNullOrWhiteSpace(txtSearch.Text)) {
				media = media.Where(x => x.Name.Contains(txtSearch.Text)).ToList();
			}

			_FilteredMedia.AddRange(media);

			lvwMedia.VirtualListSize = 0;
			lvwMedia.VirtualListSize = _FilteredMedia.Count;
		}

		public void LocalizeComponent() {
			Text = Strings.GetLink;

			tabPage.Text = Strings.Page;
			tabMedia.Text = Strings.Media;

			btnAccept.Text = Strings.Accept;
			btnCancel.Text = Strings.Cancel;

			clnFile.Text = Strings.File;
			clnType.Text = Strings.Type;
			lblSearch.Text = Strings.Search + ":";
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
			MediaItem item = _FilteredMedia[e.ItemIndex];
			e.Item = new ListViewItem(new String[] { item.Name, item.Extension });
		}
	}
}
