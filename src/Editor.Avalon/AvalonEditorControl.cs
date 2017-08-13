using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Windows.Forms;
using System.Windows.Input;
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
			
			_Editor.KeyUp += (sender, e) => {
				if (e.Key == Key.F && e.KeyboardDevice.IsKeyDown(Key.LeftCtrl)) {
					e.Handled = true;
					tsbSearch_Click(sender, e);
				}
				else if (e.Key == Key.G && e.KeyboardDevice.IsKeyDown(Key.LeftCtrl)) {
					e.Handled = true;
					GoToLine();
				}
				else if (e.Key == Key.Down && e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.KeyboardDevice.IsKeyDown(Key.LeftShift)) {
					e.Handled = true;
					LineDown();
				}
				else if (e.Key == Key.Up && e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) && e.KeyboardDevice.IsKeyDown(Key.LeftShift)) {
					e.Handled = true;
					LineUp();
				}
			};
			
			wpfHost.Child = _Editor;
		}

		private void LocalizeComponent() {
			tsbUndo.Text = Strings.Undo;
			tsbRedo.Text = Strings.Redo;
			tsbSearch.Text = Strings.Search;
			tsbInsertLink.Text = Strings.InsertLink;
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbUndo.Image = iconPack.GetImage(IconPackIcon.Undo);
			tsbRedo.Image = iconPack.GetImage(IconPackIcon.Redo);
			tsbSearch.Image = iconPack.GetImage(IconPackIcon.Search);
			tsbInsertLink.Image = iconPack.GetImage(IconPackIcon.InsertLink);
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

		private void tsbSearch_Click(object sender, EventArgs e) {
			SearchForm form = new SearchForm(_Editor);
			form.ShowDialog();
		}

		private void GoToLine() {
			DocumentLine line = _Editor.Document.GetLineByOffset(_Editor.CaretOffset);
			GoToForm form = new GoToForm(_Editor.LineCount, line.LineNumber);

			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			GoToLine(form.TargetLine);
		}

		private void GoToLine(int lineNumber) {
			DocumentLine line = _Editor.Document.GetLineByNumber(lineNumber);
			_Editor.Select(line.Offset, 0);
			_Editor.ScrollToLine(lineNumber);
		}

		private void LineDown() {
			DocumentLine currentLine = _Editor.Document.GetLineByOffset(_Editor.CaretOffset);
			SwapLines(currentLine.LineNumber, currentLine.LineNumber + 1);
		}

		private void LineUp() {
			DocumentLine currentLine = _Editor.Document.GetLineByOffset(_Editor.CaretOffset);
			SwapLines(currentLine.LineNumber, currentLine.LineNumber - 1);
		}

		private void SwapLines(int lineNumber1, int lineNumber2) {
			if (!IsLineInRange(lineNumber1, lineNumber2)) {
				return;
			}

			DocumentLine line1 = _Editor.Document.GetLineByNumber(lineNumber1);
			DocumentLine line2 = _Editor.Document.GetLineByNumber(lineNumber2);
			
			String text1 = _Editor.Document.GetText(line1.Offset, line1.Length);
			String text2 = _Editor.Document.GetText(line2.Offset, line2.Length);

			SetTextAtLine(lineNumber1, text2);
			SetTextAtLine(lineNumber2, text1);

			GoToLine(lineNumber2);
		}

		private bool IsLineInRange(params int[] lineNumbers) {
			foreach (int lineNumber in lineNumbers) {
				if (lineNumber < 1 || lineNumber > _Editor.Document.LineCount) {
					return false;
				}
			}

			return true;
		}
		
		private void SetTextAtLine(int lineNumber, String text) {
			DocumentLine line = _Editor.Document.GetLineByNumber(lineNumber);
			_Editor.Document.Replace(line.Offset, line.Length, text);
		}

		private void tsbInsertLink_Click(object sender, EventArgs e) {
			String link = _PluginHelper.GetLink();
			if (String.IsNullOrWhiteSpace(link)) {
				return;
			}

			_Editor.Document.Insert(_Editor.TextArea.Caret.Offset, link);
		}
	}
}
