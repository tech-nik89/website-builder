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

		private IIconPack IconPack => _PluginHelper.GetIconPack();

		private ToolStripButton _UndoButton;
		private ToolStripButton _RedoButton;

		private ToolStripButton _BoldButton;
		private ToolStripButton _ItalicButton;
		private ToolStripButton _UnderlineButton;

		private ToolStripButton _JustifyLeftButton;
		private ToolStripButton _JustifyCenterButton;
		private ToolStripButton _JustifyRightButton;
		private ToolStripButton _JustifyFullButton;

		private ToolStripButton _UnorderedListButton;
		private ToolStripButton _OrderedListButton;

		public EditorControl(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			tscMain.TopToolStripPanel.Controls.Add(CreateFormatsToolbar());
			tscMain.TopToolStripPanel.Controls.Add(CreateBasicToolbar());
			tscMain.TopToolStripPanel.Controls.Add(CreateMainToolbar());

			_EditorAPI = new EditorAPI(wbEditor);
			_EditorAPI.SelectionChanged += Editor_SelectionChanged;

			wbEditor.ObjectForScripting = _EditorAPI;
			wbEditor.Navigate(GetEditorIndexURL());
		}

		private void LocalizeComponent() {
			cmsEditorCut.Text = Resources.Cut;
			cmsEditorCopy.Text = Resources.Copy;
			cmsEditorPaste.Text = Resources.Paste;
		}

		private void ApplyIcons() {
			cmsEditorCut.Image = IconPack?.GetImage(IconPackIcon.Cut);
			cmsEditorCopy.Image = IconPack?.GetImage(IconPackIcon.Copy);
			cmsEditorPaste.Image = IconPack?.GetImage(IconPackIcon.Paste);
		}

		private static String GetEditorIndexURL() {
			FileInfo assemblyFileInfo = new FileInfo(Assembly.GetAssembly(typeof(EditorControl)).Location);
			return Path.Combine(assemblyFileInfo.DirectoryName, "TinyMCE", "Index.html");
		}
		
		private ToolStrip CreateMainToolbar() {
			ToolStrip bar = new ToolStrip();

			_UndoButton = new ToolStripButton(Resources.Undo) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			_UndoButton.Image = IconPack?.GetImage(IconPackIcon.Undo);
			_UndoButton.Click += tsbUndo_Click;
			bar.Items.Add(_UndoButton);

			_RedoButton = new ToolStripButton(Resources.Redo) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			_RedoButton.Image = IconPack?.GetImage(IconPackIcon.Redo);
			_RedoButton.Click += tsbRedo_Click;
			bar.Items.Add(_RedoButton);

			bar.Items.Add(new ToolStripSeparator());

			ToolStripButton cut = new ToolStripButton(Resources.Cut) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			cut.Image = IconPack?.GetImage(IconPackIcon.Cut);
			cut.Click += tsbCut_Click;
			bar.Items.Add(cut);

			ToolStripButton copy = new ToolStripButton(Resources.Copy) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			copy.Image = IconPack?.GetImage(IconPackIcon.Copy);
			copy.Click += tsbCopy_Click;
			bar.Items.Add(copy);

			ToolStripButton paste = new ToolStripButton(Resources.Paste) { DisplayStyle = ToolStripItemDisplayStyle.Image };
			paste.Image = IconPack?.GetImage(IconPackIcon.Paste);
			paste.Click += tsbPaste_Click;
			bar.Items.Add(paste);
			
			return bar;
		}

		private ToolStrip CreateBasicToolbar() {
			ToolStrip bar = new ToolStrip();
			
			_BoldButton = new ToolStripButton(Resources.Bold) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconBold };
			_BoldButton.Click += tsbBold_Click;
			bar.Items.Add(_BoldButton);

			_ItalicButton = new ToolStripButton(Resources.ForeColor) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconItalic };
			_ItalicButton.Click += tsbItalic_Click;
			bar.Items.Add(_ItalicButton);

			_UnderlineButton = new ToolStripButton(Resources.Underline) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconUnderline };
			_UnderlineButton.Click += tsbUnderline_Click;
			bar.Items.Add(_UnderlineButton);

			bar.Items.Add(new ToolStripSeparator());

			_JustifyLeftButton = new ToolStripButton(Resources.JustifyLeft) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconJustifyLeft };
			_JustifyLeftButton.Click += tsbJustifyLeft_Click;
			bar.Items.Add(_JustifyLeftButton);

			_JustifyCenterButton = new ToolStripButton(Resources.JustifyCenter) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconJustifyCenter };
			_JustifyCenterButton.Click += tsbJustifyCenter_Click;
			bar.Items.Add(_JustifyCenterButton);

			_JustifyRightButton = new ToolStripButton(Resources.JustifyRight) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconJustifyRight };
			_JustifyRightButton.Click += tsbJustifyRight_Click;
			bar.Items.Add(_JustifyRightButton);

			_JustifyFullButton = new ToolStripButton(Resources.JustifyFull) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconJustifyFull };
			_JustifyFullButton.Click += tsbJustifyFull_Click;
			bar.Items.Add(_JustifyFullButton);

			bar.Items.Add(new ToolStripSeparator());

			ToolStripButton indent = new ToolStripButton(Resources.Indent) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconIndent };
			indent.Click += tsbIndent_Click;
			bar.Items.Add(indent);

			ToolStripButton outdent = new ToolStripButton(Resources.Outdent) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconOutdent };
			outdent.Click += tsbOutdent_Click;
			bar.Items.Add(outdent);

			return bar;
		}

		private ToolStrip CreateFormatsToolbar() {
			ToolStrip bar = new ToolStrip();

			ToolStripDropDownButton formats = new ToolStripDropDownButton(Resources.Formats);
			formats.Image = Resources.IconFormats;
			CreateFormatButtons(formats);
			bar.Items.Add(formats);

			ToolStripButton removeFormats = new ToolStripButton(Resources.RemoveFormat) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconFormatsRemove };
			removeFormats.Click += tsbRemoveFormat_Click;
			bar.Items.Add(removeFormats);

			bar.Items.Add(new ToolStripSeparator());

			ToolStripButton foregroundColor = new ToolStripButton(Resources.ForeColor) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconForeColor };
			foregroundColor.Click += tsbForeColor_Click;
			bar.Items.Add(foregroundColor);

			ToolStripButton backgroundColor = new ToolStripButton(Resources.BackColor) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconBackColor };
			backgroundColor.Click += tsbBackColor_Click;
			bar.Items.Add(backgroundColor);

			bar.Items.Add(new ToolStripSeparator());

			_UnorderedListButton = new ToolStripButton(Resources.UnorderedList) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconUnorderedList };
			_UnorderedListButton.Click += tsbUnorderedList_Click;
			bar.Items.Add(_UnorderedListButton);

			_OrderedListButton = new ToolStripButton(Resources.OrderedList) { DisplayStyle = ToolStripItemDisplayStyle.Image, Image = Resources.IconOrderedList };
			_OrderedListButton.Click += tsbOrderedList_Click;
			bar.Items.Add(_OrderedListButton);

			return bar;
		}

		private void CreateFormatButtons(ToolStripDropDownButton formats) {
			for(int i = 1; i <= 6; i++) {
				formats.DropDownItems.Add(CreateFormatButton(String.Format(Resources.Headline, i), String.Format("h{0}", i)));
			}

			formats.DropDownItems.Add(new ToolStripSeparator());

			formats.DropDownItems.Add(CreateFormatButton(Resources.Paragraph, "p"));
			formats.DropDownItems.Add(CreateFormatButton(Resources.Code, "pre"));
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
		
		private void Editor_SelectionChanged(object sender, EventArgs e) {
			UpdateControls();
		}
		
		private void UpdateControls() {
			_UndoButton.Enabled = _EditorAPI.HasUndo();
			_RedoButton.Enabled = _EditorAPI.HasRedo();

			_BoldButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.Bold);
			_ItalicButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.Italic);
			_UnderlineButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.Underline);

			_JustifyLeftButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyLeft);
			_JustifyCenterButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyCenter);
			_JustifyRightButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyRight);
			_JustifyFullButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.JustifyFull);

			_UnorderedListButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.InsertUnorderedList);
			_OrderedListButton.Checked = _EditorAPI.QueryCommandState(EditorCommand.InsertOrderedList);
		}

		private void tsbCopy_Click(object sender, EventArgs e) {
			_EditorAPI.Copy();
		}

		private void tsbCut_Click(object sender, EventArgs e) {
			_EditorAPI.Cut();
		}

		private void tsbPaste_Click(object sender, EventArgs e) {
			_EditorAPI.Paste();
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
