namespace WebsiteStudio.Editors.TinyMCE {
	partial class EditorControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorControl));
			this.wbEditor = new System.Windows.Forms.WebBrowser();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbUndo = new System.Windows.Forms.ToolStripButton();
			this.tsbRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbBold = new System.Windows.Forms.ToolStripButton();
			this.tsbItalic = new System.Windows.Forms.ToolStripButton();
			this.tsbUnderline = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbJustifyLeft = new System.Windows.Forms.ToolStripButton();
			this.tsbJustifyCenter = new System.Windows.Forms.ToolStripButton();
			this.tsbJustifyRight = new System.Windows.Forms.ToolStripButton();
			this.tsbJustifyFull = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUnorderedList = new System.Windows.Forms.ToolStripButton();
			this.tsbOrderedList = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbIndent = new System.Windows.Forms.ToolStripButton();
			this.tsbOutdent = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.tsddFormats = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsbRemoveFormat = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbForeColor = new System.Windows.Forms.ToolStripButton();
			this.tsbBackColor = new System.Windows.Forms.ToolStripButton();
			this.cdColorPicker = new System.Windows.Forms.ColorDialog();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// wbEditor
			// 
			this.wbEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbEditor.IsWebBrowserContextMenuEnabled = false;
			this.wbEditor.Location = new System.Drawing.Point(0, 25);
			this.wbEditor.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbEditor.Name = "wbEditor";
			this.wbEditor.ScrollBarsEnabled = false;
			this.wbEditor.Size = new System.Drawing.Size(686, 373);
			this.wbEditor.TabIndex = 0;
			// 
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUndo,
            this.tsbRedo,
            this.toolStripSeparator1,
            this.tsbBold,
            this.tsbItalic,
            this.tsbUnderline,
            this.toolStripSeparator2,
            this.tsbJustifyLeft,
            this.tsbJustifyCenter,
            this.tsbJustifyRight,
            this.tsbJustifyFull,
            this.toolStripSeparator3,
            this.tsbUnorderedList,
            this.tsbOrderedList,
            this.toolStripSeparator4,
            this.tsbIndent,
            this.tsbOutdent,
            this.toolStripSeparator5,
            this.tsddFormats,
            this.tsbRemoveFormat,
            this.toolStripSeparator6,
            this.tsbForeColor,
            this.tsbBackColor});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(686, 25);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbUndo
			// 
			this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUndo.Image")));
			this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUndo.Name = "tsbUndo";
			this.tsbUndo.Size = new System.Drawing.Size(23, 22);
			this.tsbUndo.Text = "[Undo]";
			this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
			// 
			// tsbRedo
			// 
			this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsbRedo.Image")));
			this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRedo.Name = "tsbRedo";
			this.tsbRedo.Size = new System.Drawing.Size(23, 22);
			this.tsbRedo.Text = "[Redo]";
			this.tsbRedo.Click += new System.EventHandler(this.tsbRedo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbBold
			// 
			this.tsbBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBold.Image = ((System.Drawing.Image)(resources.GetObject("tsbBold.Image")));
			this.tsbBold.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBold.Name = "tsbBold";
			this.tsbBold.Size = new System.Drawing.Size(23, 22);
			this.tsbBold.Text = "[Bold]";
			this.tsbBold.Click += new System.EventHandler(this.tsbBold_Click);
			// 
			// tsbItalic
			// 
			this.tsbItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbItalic.Image = ((System.Drawing.Image)(resources.GetObject("tsbItalic.Image")));
			this.tsbItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbItalic.Name = "tsbItalic";
			this.tsbItalic.Size = new System.Drawing.Size(23, 22);
			this.tsbItalic.Text = "[Italic]";
			this.tsbItalic.Click += new System.EventHandler(this.tsbItalic_Click);
			// 
			// tsbUnderline
			// 
			this.tsbUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnderline.Image")));
			this.tsbUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUnderline.Name = "tsbUnderline";
			this.tsbUnderline.Size = new System.Drawing.Size(23, 22);
			this.tsbUnderline.Text = "[Underline]";
			this.tsbUnderline.Click += new System.EventHandler(this.tsbUnderline_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbJustifyLeft
			// 
			this.tsbJustifyLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbJustifyLeft.Image = ((System.Drawing.Image)(resources.GetObject("tsbJustifyLeft.Image")));
			this.tsbJustifyLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbJustifyLeft.Name = "tsbJustifyLeft";
			this.tsbJustifyLeft.Size = new System.Drawing.Size(23, 22);
			this.tsbJustifyLeft.Text = "[JustifyLeft]";
			this.tsbJustifyLeft.Click += new System.EventHandler(this.tsbJustifyLeft_Click);
			// 
			// tsbJustifyCenter
			// 
			this.tsbJustifyCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbJustifyCenter.Image = ((System.Drawing.Image)(resources.GetObject("tsbJustifyCenter.Image")));
			this.tsbJustifyCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbJustifyCenter.Name = "tsbJustifyCenter";
			this.tsbJustifyCenter.Size = new System.Drawing.Size(23, 22);
			this.tsbJustifyCenter.Text = "[JustifyCenter]";
			this.tsbJustifyCenter.Click += new System.EventHandler(this.tsbJustifyCenter_Click);
			// 
			// tsbJustifyRight
			// 
			this.tsbJustifyRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbJustifyRight.Image = ((System.Drawing.Image)(resources.GetObject("tsbJustifyRight.Image")));
			this.tsbJustifyRight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbJustifyRight.Name = "tsbJustifyRight";
			this.tsbJustifyRight.Size = new System.Drawing.Size(23, 22);
			this.tsbJustifyRight.Text = "[JustifyRight]";
			this.tsbJustifyRight.Click += new System.EventHandler(this.tsbJustifyRight_Click);
			// 
			// tsbJustifyFull
			// 
			this.tsbJustifyFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbJustifyFull.Image = ((System.Drawing.Image)(resources.GetObject("tsbJustifyFull.Image")));
			this.tsbJustifyFull.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbJustifyFull.Name = "tsbJustifyFull";
			this.tsbJustifyFull.Size = new System.Drawing.Size(23, 22);
			this.tsbJustifyFull.Text = "[JustifyFull]";
			this.tsbJustifyFull.Click += new System.EventHandler(this.tsbJustifyFull_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbUnorderedList
			// 
			this.tsbUnorderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUnorderedList.Image = ((System.Drawing.Image)(resources.GetObject("tsbUnorderedList.Image")));
			this.tsbUnorderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUnorderedList.Name = "tsbUnorderedList";
			this.tsbUnorderedList.Size = new System.Drawing.Size(23, 22);
			this.tsbUnorderedList.Text = "toolStripButton1";
			this.tsbUnorderedList.Click += new System.EventHandler(this.tsbUnorderedList_Click);
			// 
			// tsbOrderedList
			// 
			this.tsbOrderedList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOrderedList.Image = ((System.Drawing.Image)(resources.GetObject("tsbOrderedList.Image")));
			this.tsbOrderedList.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOrderedList.Name = "tsbOrderedList";
			this.tsbOrderedList.Size = new System.Drawing.Size(23, 22);
			this.tsbOrderedList.Text = "toolStripButton1";
			this.tsbOrderedList.Click += new System.EventHandler(this.tsbOrderedList_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbIndent
			// 
			this.tsbIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbIndent.Image = ((System.Drawing.Image)(resources.GetObject("tsbIndent.Image")));
			this.tsbIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIndent.Name = "tsbIndent";
			this.tsbIndent.Size = new System.Drawing.Size(23, 22);
			this.tsbIndent.Text = "toolStripButton1";
			this.tsbIndent.Click += new System.EventHandler(this.tsbIndent_Click);
			// 
			// tsbOutdent
			// 
			this.tsbOutdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbOutdent.Image = ((System.Drawing.Image)(resources.GetObject("tsbOutdent.Image")));
			this.tsbOutdent.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbOutdent.Name = "tsbOutdent";
			this.tsbOutdent.Size = new System.Drawing.Size(23, 22);
			this.tsbOutdent.Text = "toolStripButton1";
			this.tsbOutdent.Click += new System.EventHandler(this.tsbOutdent_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// tsddFormats
			// 
			this.tsddFormats.Image = ((System.Drawing.Image)(resources.GetObject("tsddFormats.Image")));
			this.tsddFormats.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsddFormats.Name = "tsddFormats";
			this.tsddFormats.Size = new System.Drawing.Size(87, 22);
			this.tsddFormats.Text = "[Formats]";
			// 
			// tsbRemoveFormat
			// 
			this.tsbRemoveFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRemoveFormat.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveFormat.Image")));
			this.tsbRemoveFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRemoveFormat.Name = "tsbRemoveFormat";
			this.tsbRemoveFormat.Size = new System.Drawing.Size(23, 22);
			this.tsbRemoveFormat.Text = "[RemoveFormat]";
			this.tsbRemoveFormat.Click += new System.EventHandler(this.tsbRemoveFormat_Click);
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbForeColor
			// 
			this.tsbForeColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbForeColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbForeColor.Image")));
			this.tsbForeColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbForeColor.Name = "tsbForeColor";
			this.tsbForeColor.Size = new System.Drawing.Size(23, 22);
			this.tsbForeColor.Text = "[ForeColor]";
			this.tsbForeColor.Click += new System.EventHandler(this.tsbForeColor_Click);
			// 
			// tsbBackColor
			// 
			this.tsbBackColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbBackColor.Image = ((System.Drawing.Image)(resources.GetObject("tsbBackColor.Image")));
			this.tsbBackColor.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbBackColor.Name = "tsbBackColor";
			this.tsbBackColor.Size = new System.Drawing.Size(23, 22);
			this.tsbBackColor.Text = "[BackColor]";
			this.tsbBackColor.Click += new System.EventHandler(this.tsbBackColor_Click);
			// 
			// EditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.wbEditor);
			this.Controls.Add(this.tsMain);
			this.Name = "EditorControl";
			this.Size = new System.Drawing.Size(686, 398);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbEditor;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbBold;
		private System.Windows.Forms.ToolStripButton tsbItalic;
		private System.Windows.Forms.ToolStripButton tsbUnderline;
		private System.Windows.Forms.ToolStripButton tsbUndo;
		private System.Windows.Forms.ToolStripButton tsbRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbJustifyLeft;
		private System.Windows.Forms.ToolStripButton tsbJustifyCenter;
		private System.Windows.Forms.ToolStripButton tsbJustifyRight;
		private System.Windows.Forms.ToolStripButton tsbJustifyFull;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton tsbUnorderedList;
		private System.Windows.Forms.ToolStripButton tsbOrderedList;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton tsbIndent;
		private System.Windows.Forms.ToolStripButton tsbOutdent;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripDropDownButton tsddFormats;
		private System.Windows.Forms.ToolStripButton tsbRemoveFormat;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ColorDialog cdColorPicker;
		private System.Windows.Forms.ToolStripButton tsbForeColor;
		private System.Windows.Forms.ToolStripButton tsbBackColor;
	}
}
