using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Toolbox.Localization;

namespace WebsiteBuilder.Modules.Toolbox.Quotes {
    partial class GenericItemForm<T> : Form where T : IItem {

        public T Item => _Item;

        private readonly T _Item;

        private readonly IPluginHelper _PluginHelper;

        private readonly IEditor _Editor;

        private readonly GenericField<T>[] _Fields;

        private readonly Control[] _Controls;

        public GenericItemForm(IPluginHelper pluginHelper)
            : this(Activator.CreateInstance<T>(), pluginHelper) {
        }

        public GenericItemForm(T item, IPluginHelper pluginHelper) {
            InitializeComponent();
            LocalizeComponent();

            DialogResult = DialogResult.Cancel;
            _PluginHelper = pluginHelper;
            _Item = item;
            
            _Editor = _PluginHelper.CreateEditor();
            _Fields = GenericField<T>.GetItemFields(_Editor);
            _Controls = new Control[_Fields.Length];
            CreateItemControls();

            for(int i = 0; i < _Fields.Length; i++) {
                _Fields[i].GetValue(_Item, _Controls[i]);
            }
        }
        
        private void CreateItemControls() {
            tlpControls.RowCount = _Fields.Length;
            tlpControls.RowStyles.Clear();

            for(Int32 i = 0; i < _Fields.Length; i++) {
                GenericField<T> field = _Fields[i];
                tlpControls.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                Label label = new Label() { Text = field.Text + ":" };
                label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                tlpControls.Controls.Add(label, 0, i);

                Control ctrl = field.CreateControl();
                ctrl.Dock = DockStyle.Fill;
                tlpControls.Controls.Add(ctrl, 1, i);
                _Controls[i] = ctrl;
            }
        }

        private void LocalizeComponent() {
            Text = Strings.Item;
            btnAccept.Text = Strings.Accept;
            btnCancel.Text = Strings.Cancel;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnAccept_Click(object sender, EventArgs e) {
            for (int i = 0; i < _Fields.Length; i++) {
                _Fields[i].SetValue(_Item, _Controls[i]);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
