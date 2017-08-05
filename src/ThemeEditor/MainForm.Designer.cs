namespace ThemeEditor {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuViewPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabSettings = new System.Windows.Forms.TabPage();
			this.gbxDescription = new System.Windows.Forms.GroupBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.lblMaxMenuDepth = new System.Windows.Forms.Label();
			this.numMaxMenuDepth = new System.Windows.Forms.NumericUpDown();
			this.lblCssImageClass = new System.Windows.Forms.Label();
			this.txtCssImageClass = new System.Windows.Forms.TextBox();
			this.tabStyles = new System.Windows.Forms.TabPage();
			this.lvwStyles = new System.Windows.Forms.ListView();
			this.clnStylesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnStylesType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsStyles = new System.Windows.Forms.ToolStrip();
			this.tsbStylesAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbStylesEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbStylesDelete = new System.Windows.Forms.ToolStripButton();
			this.tabImages = new System.Windows.Forms.TabPage();
			this.scImages = new System.Windows.Forms.SplitContainer();
			this.lvwImages = new System.Windows.Forms.ListView();
			this.clnImagesName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.pbxImage = new System.Windows.Forms.PictureBox();
			this.tsImages = new System.Windows.Forms.ToolStrip();
			this.tsbImagesAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbImagesEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbImagesRemove = new System.Windows.Forms.ToolStripButton();
			this.tabTemplates = new System.Windows.Forms.TabPage();
			this.scTemplates = new System.Windows.Forms.SplitContainer();
			this.lvwTemplates = new System.Windows.Forms.ListView();
			this.clnTemplate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ofdTheme = new System.Windows.Forms.OpenFileDialog();
			this.sfdTheme = new System.Windows.Forms.SaveFileDialog();
			this.ofdImage = new System.Windows.Forms.OpenFileDialog();
			this.spcMain = new System.Windows.Forms.SplitContainer();
			this.wbPreview = new System.Windows.Forms.WebBrowser();
			this.ehHtmlEditor = new System.Windows.Forms.Integration.ElementHost();
			this.mnuMain.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabSettings.SuspendLayout();
			this.gbxDescription.SuspendLayout();
			this.gbxGeneral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxMenuDepth)).BeginInit();
			this.tabStyles.SuspendLayout();
			this.tsStyles.SuspendLayout();
			this.tabImages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scImages)).BeginInit();
			this.scImages.Panel1.SuspendLayout();
			this.scImages.Panel2.SuspendLayout();
			this.scImages.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxImage)).BeginInit();
			this.tsImages.SuspendLayout();
			this.tabTemplates.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scTemplates)).BeginInit();
			this.scTemplates.Panel1.SuspendLayout();
			this.scTemplates.Panel2.SuspendLayout();
			this.scTemplates.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.spcMain)).BeginInit();
			this.spcMain.Panel1.SuspendLayout();
			this.spcMain.Panel2.SuspendLayout();
			this.spcMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(842, 24);
			this.mnuMain.TabIndex = 0;
			this.mnuMain.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileOpen,
            this.toolStripSeparator1,
            this.mnuFileSave,
            this.mnuFileSaveAs,
            this.toolStripSeparator2,
            this.mnuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(45, 20);
			this.mnuFile.Text = "[File]";
			// 
			// mnuFileOpen
			// 
			this.mnuFileOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileOpen.Image")));
			this.mnuFileOpen.Name = "mnuFileOpen";
			this.mnuFileOpen.Size = new System.Drawing.Size(122, 22);
			this.mnuFileOpen.Text = "[Open]";
			this.mnuFileOpen.Click += new System.EventHandler(this.mnuFileOpen_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(119, 6);
			// 
			// mnuFileSave
			// 
			this.mnuFileSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileSave.Image")));
			this.mnuFileSave.Name = "mnuFileSave";
			this.mnuFileSave.Size = new System.Drawing.Size(122, 22);
			this.mnuFileSave.Text = "[Save]";
			this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
			// 
			// mnuFileSaveAs
			// 
			this.mnuFileSaveAs.Name = "mnuFileSaveAs";
			this.mnuFileSaveAs.Size = new System.Drawing.Size(122, 22);
			this.mnuFileSaveAs.Text = "[Save As]";
			this.mnuFileSaveAs.Click += new System.EventHandler(this.mnuFileSaveAs_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(119, 6);
			// 
			// mnuFileExit
			// 
			this.mnuFileExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuFileExit.Image")));
			this.mnuFileExit.Name = "mnuFileExit";
			this.mnuFileExit.Size = new System.Drawing.Size(122, 22);
			this.mnuFileExit.Text = "[Exit]";
			this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
			// 
			// mnuView
			// 
			this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewPreview});
			this.mnuView.Name = "mnuView";
			this.mnuView.Size = new System.Drawing.Size(52, 20);
			this.mnuView.Text = "[View]";
			// 
			// mnuViewPreview
			// 
			this.mnuViewPreview.Name = "mnuViewPreview";
			this.mnuViewPreview.Size = new System.Drawing.Size(152, 22);
			this.mnuViewPreview.Text = "[ShowPreview]";
			this.mnuViewPreview.Click += new System.EventHandler(this.mnuViewPreview_Click);
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabSettings);
			this.tabMain.Controls.Add(this.tabStyles);
			this.tabMain.Controls.Add(this.tabImages);
			this.tabMain.Controls.Add(this.tabTemplates);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Multiline = true;
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(465, 425);
			this.tabMain.TabIndex = 1;
			// 
			// tabSettings
			// 
			this.tabSettings.Controls.Add(this.gbxDescription);
			this.tabSettings.Controls.Add(this.gbxGeneral);
			this.tabSettings.Location = new System.Drawing.Point(4, 22);
			this.tabSettings.Name = "tabSettings";
			this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
			this.tabSettings.Size = new System.Drawing.Size(457, 399);
			this.tabSettings.TabIndex = 1;
			this.tabSettings.Text = "[Settings]";
			this.tabSettings.UseVisualStyleBackColor = true;
			// 
			// gbxDescription
			// 
			this.gbxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxDescription.Controls.Add(this.txtDescription);
			this.gbxDescription.Location = new System.Drawing.Point(6, 110);
			this.gbxDescription.Name = "gbxDescription";
			this.gbxDescription.Size = new System.Drawing.Size(445, 283);
			this.gbxDescription.TabIndex = 3;
			this.gbxDescription.TabStop = false;
			this.gbxDescription.Text = "[Description]";
			// 
			// txtDescription
			// 
			this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescription.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDescription.Location = new System.Drawing.Point(6, 19);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescription.Size = new System.Drawing.Size(433, 258);
			this.txtDescription.TabIndex = 1;
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.lblMaxMenuDepth);
			this.gbxGeneral.Controls.Add(this.numMaxMenuDepth);
			this.gbxGeneral.Controls.Add(this.lblCssImageClass);
			this.gbxGeneral.Controls.Add(this.txtCssImageClass);
			this.gbxGeneral.Location = new System.Drawing.Point(6, 6);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(445, 98);
			this.gbxGeneral.TabIndex = 2;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// lblMaxMenuDepth
			// 
			this.lblMaxMenuDepth.AutoSize = true;
			this.lblMaxMenuDepth.Location = new System.Drawing.Point(17, 59);
			this.lblMaxMenuDepth.Name = "lblMaxMenuDepth";
			this.lblMaxMenuDepth.Size = new System.Drawing.Size(89, 13);
			this.lblMaxMenuDepth.TabIndex = 3;
			this.lblMaxMenuDepth.Text = "[MaxMenuDepth]";
			// 
			// numMaxMenuDepth
			// 
			this.numMaxMenuDepth.Location = new System.Drawing.Point(165, 57);
			this.numMaxMenuDepth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numMaxMenuDepth.Name = "numMaxMenuDepth";
			this.numMaxMenuDepth.Size = new System.Drawing.Size(120, 20);
			this.numMaxMenuDepth.TabIndex = 2;
			this.numMaxMenuDepth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// lblCssImageClass
			// 
			this.lblCssImageClass.AutoSize = true;
			this.lblCssImageClass.Location = new System.Drawing.Point(17, 34);
			this.lblCssImageClass.Name = "lblCssImageClass";
			this.lblCssImageClass.Size = new System.Drawing.Size(67, 13);
			this.lblCssImageClass.TabIndex = 0;
			this.lblCssImageClass.Text = "[ImageClass]";
			// 
			// txtCssImageClass
			// 
			this.txtCssImageClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCssImageClass.Location = new System.Drawing.Point(165, 31);
			this.txtCssImageClass.Name = "txtCssImageClass";
			this.txtCssImageClass.Size = new System.Drawing.Size(258, 20);
			this.txtCssImageClass.TabIndex = 1;
			// 
			// tabStyles
			// 
			this.tabStyles.Controls.Add(this.lvwStyles);
			this.tabStyles.Controls.Add(this.tsStyles);
			this.tabStyles.Location = new System.Drawing.Point(4, 22);
			this.tabStyles.Name = "tabStyles";
			this.tabStyles.Padding = new System.Windows.Forms.Padding(3);
			this.tabStyles.Size = new System.Drawing.Size(457, 399);
			this.tabStyles.TabIndex = 2;
			this.tabStyles.Text = "[Styles]";
			this.tabStyles.UseVisualStyleBackColor = true;
			// 
			// lvwStyles
			// 
			this.lvwStyles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnStylesName,
            this.clnStylesType});
			this.lvwStyles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwStyles.FullRowSelect = true;
			this.lvwStyles.GridLines = true;
			this.lvwStyles.HideSelection = false;
			this.lvwStyles.Location = new System.Drawing.Point(3, 28);
			this.lvwStyles.Name = "lvwStyles";
			this.lvwStyles.Size = new System.Drawing.Size(451, 368);
			this.lvwStyles.TabIndex = 1;
			this.lvwStyles.UseCompatibleStateImageBehavior = false;
			this.lvwStyles.View = System.Windows.Forms.View.Details;
			this.lvwStyles.DoubleClick += new System.EventHandler(this.lvwStyles_DoubleClick);
			// 
			// clnStylesName
			// 
			this.clnStylesName.Text = "[Name]";
			this.clnStylesName.Width = 240;
			// 
			// clnStylesType
			// 
			this.clnStylesType.Text = "[Type]";
			this.clnStylesType.Width = 240;
			// 
			// tsStyles
			// 
			this.tsStyles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStylesAdd,
            this.tsbStylesEdit,
            this.tsbStylesDelete});
			this.tsStyles.Location = new System.Drawing.Point(3, 3);
			this.tsStyles.Name = "tsStyles";
			this.tsStyles.Size = new System.Drawing.Size(451, 25);
			this.tsStyles.TabIndex = 0;
			this.tsStyles.Text = "toolStrip1";
			// 
			// tsbStylesAdd
			// 
			this.tsbStylesAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbStylesAdd.Image")));
			this.tsbStylesAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStylesAdd.Name = "tsbStylesAdd";
			this.tsbStylesAdd.Size = new System.Drawing.Size(57, 22);
			this.tsbStylesAdd.Text = "[Add]";
			this.tsbStylesAdd.Click += new System.EventHandler(this.tsbStylesAdd_Click);
			// 
			// tsbStylesEdit
			// 
			this.tsbStylesEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbStylesEdit.Image")));
			this.tsbStylesEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStylesEdit.Name = "tsbStylesEdit";
			this.tsbStylesEdit.Size = new System.Drawing.Size(55, 22);
			this.tsbStylesEdit.Text = "[Edit]";
			this.tsbStylesEdit.Click += new System.EventHandler(this.tsbStylesEdit_Click);
			// 
			// tsbStylesDelete
			// 
			this.tsbStylesDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbStylesDelete.Image")));
			this.tsbStylesDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbStylesDelete.Name = "tsbStylesDelete";
			this.tsbStylesDelete.Size = new System.Drawing.Size(68, 22);
			this.tsbStylesDelete.Text = "[Delete]";
			this.tsbStylesDelete.Click += new System.EventHandler(this.tsbStylesDelete_Click);
			// 
			// tabImages
			// 
			this.tabImages.Controls.Add(this.scImages);
			this.tabImages.Controls.Add(this.tsImages);
			this.tabImages.Location = new System.Drawing.Point(4, 22);
			this.tabImages.Name = "tabImages";
			this.tabImages.Padding = new System.Windows.Forms.Padding(3);
			this.tabImages.Size = new System.Drawing.Size(457, 399);
			this.tabImages.TabIndex = 3;
			this.tabImages.Text = "[Images]";
			this.tabImages.UseVisualStyleBackColor = true;
			// 
			// scImages
			// 
			this.scImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scImages.Location = new System.Drawing.Point(3, 28);
			this.scImages.Name = "scImages";
			// 
			// scImages.Panel1
			// 
			this.scImages.Panel1.Controls.Add(this.lvwImages);
			// 
			// scImages.Panel2
			// 
			this.scImages.Panel2.Controls.Add(this.pbxImage);
			this.scImages.Size = new System.Drawing.Size(451, 368);
			this.scImages.SplitterDistance = 189;
			this.scImages.TabIndex = 4;
			// 
			// lvwImages
			// 
			this.lvwImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnImagesName});
			this.lvwImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwImages.FullRowSelect = true;
			this.lvwImages.GridLines = true;
			this.lvwImages.HideSelection = false;
			this.lvwImages.Location = new System.Drawing.Point(0, 0);
			this.lvwImages.Name = "lvwImages";
			this.lvwImages.Size = new System.Drawing.Size(189, 368);
			this.lvwImages.TabIndex = 3;
			this.lvwImages.UseCompatibleStateImageBehavior = false;
			this.lvwImages.View = System.Windows.Forms.View.Details;
			this.lvwImages.SelectedIndexChanged += new System.EventHandler(this.lvwImages_SelectedIndexChanged);
			// 
			// clnImagesName
			// 
			this.clnImagesName.Text = "[Name]";
			this.clnImagesName.Width = 200;
			// 
			// pbxImage
			// 
			this.pbxImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pbxImage.Location = new System.Drawing.Point(0, 0);
			this.pbxImage.Name = "pbxImage";
			this.pbxImage.Size = new System.Drawing.Size(258, 368);
			this.pbxImage.TabIndex = 0;
			this.pbxImage.TabStop = false;
			// 
			// tsImages
			// 
			this.tsImages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbImagesAdd,
            this.tsbImagesEdit,
            this.tsbImagesRemove});
			this.tsImages.Location = new System.Drawing.Point(3, 3);
			this.tsImages.Name = "tsImages";
			this.tsImages.Size = new System.Drawing.Size(451, 25);
			this.tsImages.TabIndex = 2;
			this.tsImages.Text = "toolStrip2";
			// 
			// tsbImagesAdd
			// 
			this.tsbImagesAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbImagesAdd.Image")));
			this.tsbImagesAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbImagesAdd.Name = "tsbImagesAdd";
			this.tsbImagesAdd.Size = new System.Drawing.Size(57, 22);
			this.tsbImagesAdd.Text = "[Add]";
			this.tsbImagesAdd.Click += new System.EventHandler(this.tsbImagesAdd_Click);
			// 
			// tsbImagesEdit
			// 
			this.tsbImagesEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbImagesEdit.Image")));
			this.tsbImagesEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbImagesEdit.Name = "tsbImagesEdit";
			this.tsbImagesEdit.Size = new System.Drawing.Size(55, 22);
			this.tsbImagesEdit.Text = "[Edit]";
			this.tsbImagesEdit.Click += new System.EventHandler(this.tsbImagesEdit_Click);
			// 
			// tsbImagesRemove
			// 
			this.tsbImagesRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbImagesRemove.Image")));
			this.tsbImagesRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbImagesRemove.Name = "tsbImagesRemove";
			this.tsbImagesRemove.Size = new System.Drawing.Size(68, 22);
			this.tsbImagesRemove.Text = "[Delete]";
			this.tsbImagesRemove.Click += new System.EventHandler(this.tsbImagesRemove_Click);
			// 
			// tabTemplates
			// 
			this.tabTemplates.Controls.Add(this.scTemplates);
			this.tabTemplates.Location = new System.Drawing.Point(4, 22);
			this.tabTemplates.Name = "tabTemplates";
			this.tabTemplates.Padding = new System.Windows.Forms.Padding(3);
			this.tabTemplates.Size = new System.Drawing.Size(457, 399);
			this.tabTemplates.TabIndex = 4;
			this.tabTemplates.Text = "[Templates]";
			this.tabTemplates.UseVisualStyleBackColor = true;
			// 
			// scTemplates
			// 
			this.scTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.scTemplates.Location = new System.Drawing.Point(3, 3);
			this.scTemplates.Name = "scTemplates";
			// 
			// scTemplates.Panel1
			// 
			this.scTemplates.Panel1.Controls.Add(this.lvwTemplates);
			// 
			// scTemplates.Panel2
			// 
			this.scTemplates.Panel2.Controls.Add(this.ehHtmlEditor);
			this.scTemplates.Size = new System.Drawing.Size(451, 393);
			this.scTemplates.SplitterDistance = 150;
			this.scTemplates.TabIndex = 0;
			// 
			// lvwTemplates
			// 
			this.lvwTemplates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnTemplate});
			this.lvwTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwTemplates.FullRowSelect = true;
			this.lvwTemplates.GridLines = true;
			this.lvwTemplates.HideSelection = false;
			this.lvwTemplates.Location = new System.Drawing.Point(0, 0);
			this.lvwTemplates.Name = "lvwTemplates";
			this.lvwTemplates.Size = new System.Drawing.Size(150, 393);
			this.lvwTemplates.TabIndex = 0;
			this.lvwTemplates.UseCompatibleStateImageBehavior = false;
			this.lvwTemplates.View = System.Windows.Forms.View.Details;
			this.lvwTemplates.SelectedIndexChanged += new System.EventHandler(this.lvwTemplates_SelectedIndexChanged);
			// 
			// clnTemplate
			// 
			this.clnTemplate.Text = "[Template]";
			this.clnTemplate.Width = 200;
			// 
			// spcMain
			// 
			this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.spcMain.Location = new System.Drawing.Point(0, 24);
			this.spcMain.Name = "spcMain";
			// 
			// spcMain.Panel1
			// 
			this.spcMain.Panel1.Controls.Add(this.tabMain);
			// 
			// spcMain.Panel2
			// 
			this.spcMain.Panel2.Controls.Add(this.wbPreview);
			this.spcMain.Size = new System.Drawing.Size(842, 425);
			this.spcMain.SplitterDistance = 465;
			this.spcMain.TabIndex = 2;
			// 
			// wbPreview
			// 
			this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbPreview.Location = new System.Drawing.Point(0, 0);
			this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbPreview.Name = "wbPreview";
			this.wbPreview.Size = new System.Drawing.Size(373, 425);
			this.wbPreview.TabIndex = 0;
			// 
			// ehHtmlEditor
			// 
			this.ehHtmlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ehHtmlEditor.Location = new System.Drawing.Point(0, 0);
			this.ehHtmlEditor.Name = "ehHtmlEditor";
			this.ehHtmlEditor.Size = new System.Drawing.Size(297, 393);
			this.ehHtmlEditor.TabIndex = 0;
			this.ehHtmlEditor.Text = "elementHost1";
			this.ehHtmlEditor.Child = null;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 449);
			this.Controls.Add(this.spcMain);
			this.Controls.Add(this.mnuMain);
			this.MainMenuStrip = this.mnuMain;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[ThemeEditor]";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabSettings.ResumeLayout(false);
			this.gbxDescription.ResumeLayout(false);
			this.gbxDescription.PerformLayout();
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxMenuDepth)).EndInit();
			this.tabStyles.ResumeLayout(false);
			this.tabStyles.PerformLayout();
			this.tsStyles.ResumeLayout(false);
			this.tsStyles.PerformLayout();
			this.tabImages.ResumeLayout(false);
			this.tabImages.PerformLayout();
			this.scImages.Panel1.ResumeLayout(false);
			this.scImages.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scImages)).EndInit();
			this.scImages.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pbxImage)).EndInit();
			this.tsImages.ResumeLayout(false);
			this.tsImages.PerformLayout();
			this.tabTemplates.ResumeLayout(false);
			this.scTemplates.Panel1.ResumeLayout(false);
			this.scTemplates.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.scTemplates)).EndInit();
			this.scTemplates.ResumeLayout(false);
			this.spcMain.Panel1.ResumeLayout(false);
			this.spcMain.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.spcMain)).EndInit();
			this.spcMain.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnuMain;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
		private System.Windows.Forms.ToolStripMenuItem mnuFileOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
		private System.Windows.Forms.ToolStripMenuItem mnuFileSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabSettings;
		private System.Windows.Forms.Label lblCssImageClass;
		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.TextBox txtCssImageClass;
		private System.Windows.Forms.TabPage tabStyles;
		private System.Windows.Forms.ToolStrip tsStyles;
		private System.Windows.Forms.ListView lvwStyles;
		private System.Windows.Forms.ToolStripButton tsbStylesAdd;
		private System.Windows.Forms.ToolStripButton tsbStylesEdit;
		private System.Windows.Forms.ToolStripButton tsbStylesDelete;
		private System.Windows.Forms.ColumnHeader clnStylesName;
		private System.Windows.Forms.ColumnHeader clnStylesType;
		private System.Windows.Forms.TabPage tabImages;
		private System.Windows.Forms.ListView lvwImages;
		private System.Windows.Forms.ColumnHeader clnImagesName;
		private System.Windows.Forms.ToolStrip tsImages;
		private System.Windows.Forms.ToolStripButton tsbImagesAdd;
		private System.Windows.Forms.ToolStripButton tsbImagesRemove;
		private System.Windows.Forms.TabPage tabTemplates;
		private System.Windows.Forms.SplitContainer scTemplates;
		private System.Windows.Forms.ListView lvwTemplates;
		private System.Windows.Forms.ColumnHeader clnTemplate;
		private System.Windows.Forms.GroupBox gbxDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.OpenFileDialog ofdTheme;
		private System.Windows.Forms.SaveFileDialog sfdTheme;
		private System.Windows.Forms.Label lblMaxMenuDepth;
		private System.Windows.Forms.NumericUpDown numMaxMenuDepth;
		private System.Windows.Forms.SplitContainer scImages;
		private System.Windows.Forms.PictureBox pbxImage;
		private System.Windows.Forms.OpenFileDialog ofdImage;
		private System.Windows.Forms.ToolStripButton tsbImagesEdit;
		private System.Windows.Forms.ToolStripMenuItem mnuView;
		private System.Windows.Forms.ToolStripMenuItem mnuViewPreview;
		private System.Windows.Forms.SplitContainer spcMain;
		private System.Windows.Forms.WebBrowser wbPreview;
		private System.Windows.Forms.Integration.ElementHost ehHtmlEditor;
	}
}

