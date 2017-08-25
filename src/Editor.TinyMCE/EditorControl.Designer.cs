﻿namespace WebsiteStudio.Editors.TinyMCE {
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
			this.components = new System.ComponentModel.Container();
			this.wbEditor = new System.Windows.Forms.WebBrowser();
			this.cdColorPicker = new System.Windows.Forms.ColorDialog();
			this.tscMain = new System.Windows.Forms.ToolStripContainer();
			this.cmsEditor = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsEditorCut = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsEditorCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsEditorPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.tscMain.ContentPanel.SuspendLayout();
			this.tscMain.SuspendLayout();
			this.cmsEditor.SuspendLayout();
			this.SuspendLayout();
			// 
			// wbEditor
			// 
			this.wbEditor.ContextMenuStrip = this.cmsEditor;
			this.wbEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbEditor.IsWebBrowserContextMenuEnabled = false;
			this.wbEditor.Location = new System.Drawing.Point(0, 0);
			this.wbEditor.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbEditor.Name = "wbEditor";
			this.wbEditor.ScrollBarsEnabled = false;
			this.wbEditor.Size = new System.Drawing.Size(686, 373);
			this.wbEditor.TabIndex = 0;
			// 
			// tscMain
			// 
			// 
			// tscMain.ContentPanel
			// 
			this.tscMain.ContentPanel.Controls.Add(this.wbEditor);
			this.tscMain.ContentPanel.Size = new System.Drawing.Size(686, 373);
			this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tscMain.Location = new System.Drawing.Point(0, 0);
			this.tscMain.Name = "tscMain";
			this.tscMain.Size = new System.Drawing.Size(686, 398);
			this.tscMain.TabIndex = 1;
			this.tscMain.Text = "toolStripContainer1";
			// 
			// cmsEditor
			// 
			this.cmsEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEditorCut,
            this.cmsEditorCopy,
            this.cmsEditorPaste});
			this.cmsEditor.Name = "cmsEditor";
			this.cmsEditor.Size = new System.Drawing.Size(153, 92);
			// 
			// cmsEditorCut
			// 
			this.cmsEditorCut.Name = "cmsEditorCut";
			this.cmsEditorCut.Size = new System.Drawing.Size(152, 22);
			this.cmsEditorCut.Text = "[Cut]";
			this.cmsEditorCut.Click += new System.EventHandler(this.tsbCut_Click);
			// 
			// cmsEditorCopy
			// 
			this.cmsEditorCopy.Name = "cmsEditorCopy";
			this.cmsEditorCopy.Size = new System.Drawing.Size(152, 22);
			this.cmsEditorCopy.Text = "[Copy]";
			this.cmsEditorCopy.Click += new System.EventHandler(this.tsbCopy_Click);
			// 
			// cmsEditorPaste
			// 
			this.cmsEditorPaste.Name = "cmsEditorPaste";
			this.cmsEditorPaste.Size = new System.Drawing.Size(152, 22);
			this.cmsEditorPaste.Text = "[Paste]";
			this.cmsEditorPaste.Click += new System.EventHandler(this.tsbPaste_Click);
			// 
			// EditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tscMain);
			this.Name = "EditorControl";
			this.Size = new System.Drawing.Size(686, 398);
			this.tscMain.ContentPanel.ResumeLayout(false);
			this.tscMain.ResumeLayout(false);
			this.tscMain.PerformLayout();
			this.cmsEditor.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbEditor;
		private System.Windows.Forms.ColorDialog cdColorPicker;
		private System.Windows.Forms.ToolStripContainer tscMain;
		private System.Windows.Forms.ContextMenuStrip cmsEditor;
		private System.Windows.Forms.ToolStripMenuItem cmsEditorCut;
		private System.Windows.Forms.ToolStripMenuItem cmsEditorCopy;
		private System.Windows.Forms.ToolStripMenuItem cmsEditorPaste;
	}
}
