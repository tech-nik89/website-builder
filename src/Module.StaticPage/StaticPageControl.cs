using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.StaticPage {
    public partial class StaticPageControl : UserControl, IUserInterface {

        private readonly IEditor _Editor;

        private IUserInterface _EditorControl;

        private IUserInterface EditorControl {
            get {
                if (_EditorControl == null && _Editor != null) {
                    _EditorControl = _Editor.GetUserInterface();
                }

                return _EditorControl;
            }
        }

        public String Data {
            get {
                return EditorControl?.Data ?? String.Empty;
            }
            set {
                if (EditorControl != null) {
                    EditorControl.Data = value;
                }
            }
        }

        public StaticPageControl(IPluginHelper pluginHelper) {
            InitializeComponent();
            _Editor = pluginHelper.CreateEditor();
        }
        
        private void StaticPageUserInterfaceControl_Load(object sender, EventArgs e) {
            UserControl control = EditorControl as UserControl;
            if (control == null) {
                return;
            }

            control.Dock = DockStyle.Fill;

            Controls.Clear();
            Controls.Add(control);
        }

        public void Insert(String str) {
            if (_EditorControl == null) {
                return;
            }

            _EditorControl.Insert(str);
        }
    }
}
