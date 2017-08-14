using System;
using System.Windows.Forms;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Modules.StaticPage {
	public partial class StaticPageControl : UserControl, IUserInterface {
		
		private readonly IPluginHelper _PluginHelper;

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

		public bool Dirty => EditorControl?.Dirty ?? false;

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

			_PluginHelper = pluginHelper;
			_Editor = pluginHelper.CreateEditor();
		}

		private void StaticPageUserInterfaceControl_Load(object sender, EventArgs e) {
			UserControl control = EditorControl as UserControl;
			if (control == null) {
				return;
			}

			pnlEditor.Controls.Clear();
			pnlEditor.Controls.Add(control);
			control.Dock = DockStyle.Fill;
		}
	}
}
