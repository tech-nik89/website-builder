using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;
using WebsiteBuilder.Modules.Localization;

namespace WebsiteBuilder.Modules.StaticPage {
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
			LocalizeComponent();

			_PluginHelper = pluginHelper;
			_Editor = pluginHelper.CreateEditor();

			ApplyIcons();
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbLink.Image = iconPack.GetImage(IconPackIcon.InsertLink);
		}

		private void LocalizeComponent() {
			tsbLink.Text = Strings.InsertLink;
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

		private void tsbLink_Click(object sender, EventArgs e) {
			String link = _PluginHelper.GetLink();
			Insert(link);
		}

		public void Insert(String str) {
			if (_EditorControl == null || String.IsNullOrWhiteSpace(str)) {
				return;
			}

			_EditorControl.Insert(str);
		}
	}
}
