using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Toolbox.Localization;

namespace WebsiteBuilder.Modules.Toolbox.Quotes {
    partial class GenericControl<T> : UserControl, IUserInterface where T : IItem {

        public String Data {
            get => DataSerializer.Serialize(_Data);
            set {
                _Data.Clear();
                _Data.AddRange(DataSerializer.Deserialize<T>(value));
                RefreshList();
                EnableControls();
            }
        }

        private readonly List<T> _Data;

        private readonly GenericField<T>[] _Fields;
        
        private readonly IPluginHelper _PluginHelper;
        
        public GenericControl(IPluginHelper pluginHelper) {
            InitializeComponent();
            InitializeLocalization();

            _PluginHelper = pluginHelper;
            _Fields = GenericField<T>.GetItemFields(null);
            _Data = new List<T>();

            ApplyColumns();
            ApplyIcons();
            EnableControls();
        }

        private void ApplyColumns() {
            foreach (GenericField<T> field in _Fields) {
                if (!field.ShowColumn) {
                    continue;
                }

                lvwData.Columns.Add(field.Text, field.ColumnWidth);
            }
        }

        private void ApplyIcons() {
            IIconPack iconPack = _PluginHelper.GetIconPack();
            if (iconPack == null) {
                return;
            }

            tsbAdd.Image = iconPack.GetImage(IconPackIcon.Add);
            tsbEdit.Image = iconPack.GetImage(IconPackIcon.Edit);
            tsbDelete.Image = iconPack.GetImage(IconPackIcon.Delete);
        }

        private void InitializeLocalization() {
            tsbAdd.Text = Strings.Add;
            tsbEdit.Text = Strings.Edit;
            tsbDelete.Text = Strings.Delete;

            clnTitle.Text = Strings.Title;
            clnText.Text = Strings.Text;
        }

        private void RefreshList() {
            lvwData.VirtualListSize = 0;
            lvwData.VirtualListSize = _Data.Count;
        }
        
        public void Insert(String str) {
            // ignore
        }

        private void tsbAdd_Click(object sender, EventArgs e) {
            GenericItemForm<T> form = new GenericItemForm<T>(_PluginHelper);
            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            _Data.Add(form.Item);
            RefreshList();
        }

        private void tsbEdit_Click(object sender, EventArgs e) {
            EditItem();
        }

        private void tsbDelete_Click(object sender, EventArgs e) {
            if (lvwData.SelectedIndices.Count == 0) {
                return;
            }

            if (MessageBox.Show(Strings.DeleteItemConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
                return;
            }

            _Data.RemoveAt(lvwData.SelectedIndices[0]);
            RefreshList();
        }

        private void EditItem() {
            if (lvwData.SelectedIndices.Count == 0) {
                return;
            }

            T item = _Data[lvwData.SelectedIndices[0]];
            GenericItemForm<T> form = new GenericItemForm<T>(item, _PluginHelper);

            if (form.ShowDialog() != DialogResult.OK) {
                return;
            }

            RefreshList();
        }

        private void lvwData_SelectedIndexChanged(object sender, EventArgs e) {
            EnableControls();
        }

        private void lvwData_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
            T item = _Data[e.ItemIndex];
            e.Item = new ListViewItem(item.Columns);
        }

        private void lvwData_DoubleClick(object sender, EventArgs e) {
            EditItem();
        }

        private void EnableControls() {

        }
    }
}
