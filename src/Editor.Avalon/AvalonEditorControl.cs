using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Windows.Forms;
using WebsiteBuilder.Editors.Avalon.Localization;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {
	public partial class AvalonEditorControl : UserControl, IUserInterface {
		
		private readonly TextEditor _Editor;

		private readonly IPluginHelper _PluginHelper;

		public bool Dirty { get; private set; }

		public String Data {
			get {
				Dirty = false;
				return _Editor.Text;
			}
			set {
				_Editor.Text = value;
				Dirty = false;
				UpdateButtons();
			}
		}

		public AvalonEditorControl(IPluginHelper pluginHelper, String highlightingMode) {
			InitializeComponent();
			_PluginHelper = pluginHelper;

			LocalizeComponent();
			ApplyIcons();
			
			_Editor = new TextEditor();
			_Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(highlightingMode);
			_Editor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
			_Editor.ShowLineNumbers = true;
			_Editor.TextChanged += (s, args) => {
				Dirty = true;
				UpdateButtons();
			};
			
			wpfHost.Child = _Editor;
		}

		private void LocalizeComponent() {
			tsbUndo.Text = Strings.Undo;
			tsbRedo.Text = Strings.Redo;
			tsbSearch.Text = Strings.Search;
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbUndo.Image = iconPack.GetImage(IconPackIcon.Undo);
			tsbRedo.Image = iconPack.GetImage(IconPackIcon.Redo);
			tsbSearch.Image = iconPack.GetImage(IconPackIcon.Search);
		}

		public void Insert(String str) {
			_Editor.Document.Insert(_Editor.TextArea.Caret.Offset, str);
		}

		public void UpdateButtons() {
			tsbUndo.Enabled = _Editor.CanUndo;
			tsbRedo.Enabled = _Editor.CanRedo;
		}

		private void tsbUndo_Click(object sender, EventArgs e) {
			_Editor.Undo();
		}

		private void tsbRedo_Click(object sender, EventArgs e) {
			_Editor.Redo();
		}
	}
}
