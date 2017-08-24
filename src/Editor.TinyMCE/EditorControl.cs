using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WebsiteStudio.Editors.TinyMCE.Properties;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Editors.TinyMCE {
	public partial class EditorControl : UserControl, IUserInterface {
		
		private readonly EditorAPI _EditorAPI;

		public String Data {
			get => _EditorAPI.GetData();
			set => _EditorAPI.SetData(value);
		}

		public bool Dirty => _EditorAPI.IsDirty();

		private readonly IPluginHelper _PluginHelper;

		public EditorControl(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			InitializeComponent();
			LocalizeComponent();
			CreateFormatButtons();
			ApplyIcons();

			_EditorAPI = new EditorAPI(wbEditor);
			_EditorAPI.SelectionChanged += Editor_SelectionChanged;

			wbEditor.ObjectForScripting = _EditorAPI;
			wbEditor.Navigate(GetEditorIndexURL());
		}

		private static String GetEditorIndexURL() {
			FileInfo assemblyFileInfo = new FileInfo(Assembly.GetAssembly(typeof(EditorControl)).Location);
			return Path.Combine(assemblyFileInfo.DirectoryName, "TinyMCE", "Index.html");
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbUndo.Image = iconPack.GetImage(IconPackIcon.Undo);
			tsbRedo.Image = iconPack.GetImage(IconPackIcon.Redo);
		}

		private void CreateFormatButtons() {
			for(int i = 1; i <= 6; i++) {
				tsddFormats.DropDownItems.Add(CreateFormatButton(String.Format(Resources.Headline, i), String.Format("h{0}", i)));
			}

			tsddFormats.DropDownItems.Add(new ToolStripSeparator());

			tsddFormats.DropDownItems.Add(CreateFormatButton(Resources.Paragraph, "p"));
			tsddFormats.DropDownItems.Add(CreateFormatButton(Resources.Code, "pre"));
		}

		private ToolStripMenuItem CreateFormatButton(String text, String format) {
			ToolStripMenuItem headlineButton = new ToolStripMenuItem();

			headlineButton.Text = text;
			headlineButton.Tag = format;
			headlineButton.Click += FormatButton_Click;

			return headlineButton;
		}

		private void FormatButton_Click(object sender, EventArgs e) {
			ToolStripMenuItem button = (ToolStripMenuItem)sender;
			String format = (String)button.Tag;
			_EditorAPI.ApplyFormat(format);
		}
		
		private void LocalizeComponent() {
			tsbUndo.Text = Resources.Undo;
			tsbRedo.Text = Resources.Redo;

			tsbBold.Text = Resources.Bold;
			tsbItalic.Text = Resources.Italic;
			tsbUnderline.Text = Resources.Underline;

			tsbJustifyLeft.Text = Resources.JustifyLeft;
			tsbJustifyCenter.Text = Resources.JustifyCenter;
			tsbJustifyRight.Text = Resources.JustifyRight;
			tsbJustifyFull.Text = Resources.JustifyFull;

			tsbUnorderedList.Text = Resources.UnorderedList;
			tsbOrderedList.Text = Resources.OrderedList;

			tsbIndent.Text = Resources.Indent;
			tsbOutdent.Text = Resources.Outdent;

			tsddFormats.Text = Resources.Formats;
			tsbRemoveFormat.Text = Resources.RemoveFormat;

			tsbForeColor.Text = Resources.ForeColor;
			tsbBackColor.Text = Resources.BackColor;
		}

		private void Editor_SelectionChanged(object sender, EventArgs e) {
			UpdateControls();
		}

		private void UpdateControls() {
			tsbUndo.Enabled = _EditorAPI.HasUndo();
			tsbRedo.Enabled = _EditorAPI.HasRedo();

			tsbBold.Checked = _EditorAPI.QueryCommandState(EditorCommand.Bold);
			tsbItalic.Checked = _EditorAPI.QueryCommandState(EditorCommand.Italic);
			tsbUnderline.Checked = _EditorAPI.QueryCommandState(EditorCommand.Underline);

			tsbJustifyLeft.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyLeft);
			tsbJustifyCenter.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyCenter);
			tsbJustifyRight.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyRight);
			tsbJustifyFull.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyFull);

			tsbUnorderedList.Checked = _EditorAPI.QueryCommandState(EditorCommand.InsertUnorderedList);
			tsbOrderedList.Checked = _EditorAPI.QueryCommandState(EditorCommand.InsertOrderedList);
		}

		private void tsbUndo_Click(object sender, EventArgs e) {
			_EditorAPI.Undo();
			UpdateControls();
		}

		private void tsbRedo_Click(object sender, EventArgs e) {
			_EditorAPI.Redo();
			UpdateControls();
		}

		private void tsbBold_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.Bold);
			UpdateControls();
		}

		private void tsbItalic_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.Italic);
			UpdateControls();
		}

		private void tsbUnderline_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.Underline);
			UpdateControls();
		}

		private void tsbJustifyLeft_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.JustifyLeft);
			UpdateControls();
		}

		private void tsbJustifyCenter_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.JustifyCenter);
			UpdateControls();
		}

		private void tsbJustifyRight_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.JustifyRight);
			UpdateControls();
		}

		private void tsbJustifyFull_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.JustifyFull);
			UpdateControls();
		}

		private void tsbUnorderedList_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.InsertUnorderedList);
			UpdateControls();
		}

		private void tsbOrderedList_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.InsertOrderedList);
			UpdateControls();
		}

		private void tsbIndent_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.Indent);
		}

		private void tsbOutdent_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.Outdent);
		}

		private void tsbRemoveFormat_Click(object sender, EventArgs e) {
			_EditorAPI.ExecCommand(EditorCommand.RemoveFormat);
			UpdateControls();
		}

		private void tsbForeColor_Click(object sender, EventArgs e) {
			if (cdColorPicker.ShowDialog() != DialogResult.OK) {
				return;
			}

			_EditorAPI.ExecCommand(EditorCommand.ForeColor, cdColorPicker.Color);
		}
		
		private void tsbBackColor_Click(object sender, EventArgs e) {
			if (cdColorPicker.ShowDialog() != DialogResult.OK) {
				return;
			}

			_EditorAPI.ExecCommand(EditorCommand.HiliteColor, cdColorPicker.Color);
		}
	}
}
