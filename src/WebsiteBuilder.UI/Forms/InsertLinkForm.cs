using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;
using WebsiteBuilder.Core.Media;
using WebsiteBuilder.Core.Pages;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class InsertLinkForm : Form {

        private readonly Project _Project;

        private readonly ImageList _ImageList;

        public string Link { get; private set; }

        public InsertLinkForm(Project project) {
            InitializeComponent();
            LocalizeComponent();

            DialogResult = DialogResult.Cancel;
            _Project = project;

            _ImageList = new ImageList();
            _ImageList.Images.Add(IconPack.Current.GetImage(IconPackIcon.Page));
            tvwPages.ImageList = _ImageList;

            FillProjectTree(tvwPages.Nodes, _Project.Pages);
            FillMediaList();
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

                Link = String.Format(CompilerConstants.PageLinkFormat, page.Id);
            }
            else if (tabCtrl.SelectedTab == tabMedia && lvwMedia.SelectedIndices.Count == 1) {
                MediaItem item = _Project.Media[lvwMedia.SelectedIndices[0]];
                Link = String.Format(CompilerConstants.MediaLinkFormat, item.Id);
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
    }
}
