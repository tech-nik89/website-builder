using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Editors.Avalon {
    public partial class AvalonEditorControl : UserControl, IUserInterface {
        
        private readonly TextEditor _Editor;

        public String Data {
            get {
                return _Editor.Text;
            }
            set {
                _Editor.Text = value;
            }
        }

        public AvalonEditorControl(String highlightingMode) {
            InitializeComponent();

            _Editor = new TextEditor();
            _Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition(highlightingMode);
            _Editor.FontFamily = new System.Windows.Media.FontFamily("Consolas");
            _Editor.ShowLineNumbers = true;

            wpfHost.Child = _Editor;
        }

        public void Insert(String str) {
            _Editor.Document.Insert(_Editor.TextArea.Caret.Offset, str);
        }
    }
}
