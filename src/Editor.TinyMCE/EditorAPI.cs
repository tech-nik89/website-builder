using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WebsiteStudio.Editors.TinyMCE {

	[ComVisible(true)]
	public class EditorAPI {

		public event EventHandler Init;

		public event EventHandler SelectionChanged;

		private readonly WebBrowser _Browser;

		private String _CachedData;

		private bool _Loaded;

		public EditorAPI(WebBrowser browser) {
			_Browser = browser;
		}

		public void FireInit() {
			_Browser.AllowNavigation = false;
			_Loaded = true;

			if (!String.IsNullOrWhiteSpace(_CachedData)) {
				SetData(_CachedData);
				_CachedData = null;
			}

			Init?.Invoke(this, new EventArgs());
		}

		public void FireSelectionChanged() {
			SelectionChanged?.Invoke(this, new EventArgs());
		}

		internal void SetData(String data) {
			if (_Loaded) {
				_Browser.Document.InvokeScript("SetData", new Object[] { data });
				SetDirty(false);
			}
			else {
				_CachedData = data;
			}
		}

		internal String GetData() {
			if (!_Loaded) {
				return String.Empty;
			}

			SetDirty(false);
			return (String)_Browser.Document.InvokeScript("GetData");
		}

		internal bool QueryCommandState(EditorCommand command) {
			if (!_Loaded) {
				return false;
			}

			return Convert.ToBoolean(_Browser.Document.InvokeScript("QueryCommandState", new Object[] { command.ToString() }));
		}

		internal bool ExecCommand(EditorCommand command) {
			return ExecCommand(command, null);
		}

		internal bool ExecCommand(EditorCommand command, Color color) {
			return ExecCommand(command, String.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B));
		}

		internal bool ExecCommand(EditorCommand command, Object argument) {
			if (!_Loaded) {
				return false;
			}

			return Convert.ToBoolean(_Browser.Document.InvokeScript("ExecCommand", new Object[] { command.ToString(), argument }));
		}

		internal bool IsDirty() {
			if (!_Loaded) {
				return false;
			}

			return Convert.ToBoolean(_Browser.Document.InvokeScript("IsDirty"));
		}

		private void SetDirty(bool value) {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.InvokeScript("SetDirty", new Object[] { value });
		}

		internal void Undo() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.InvokeScript("Undo");
		}

		internal void Redo() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.InvokeScript("Redo");
		}

		internal bool HasUndo() {
			if (!_Loaded) {
				return false;
			}

			return Convert.ToBoolean(_Browser.Document.InvokeScript("HasUndo"));
		}

		internal bool HasRedo() {
			if (!_Loaded) {
				return false;
			}

			return Convert.ToBoolean(_Browser.Document.InvokeScript("HasRedo"));
		}

		internal void ApplyFormat(String format) {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.InvokeScript("ApplyFormat", new Object[] { format });
		}

		internal void Cut() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.ExecCommand("Cut", false, null);
		}

		internal void Copy() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.ExecCommand("Copy", false, null);
		}

		internal void Paste() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.ExecCommand("Paste", false, null);
		}

		internal void InsertContent(String content) {
			if (!_Loaded) {
				return;
			}

			ExecCommand(EditorCommand.mceInsertContent, content);
		}

		internal String GetSelectedNode() {
			if (!_Loaded) {
				return null;
			}

			return (String)_Browser.Document.InvokeScript("GetSelectedNode");
		}

		internal void DeleteSelectedNode() {
			if (!_Loaded) {
				return;
			}

			_Browser.Document.InvokeScript("DeleteSelectedNode");
		}
	}
}
