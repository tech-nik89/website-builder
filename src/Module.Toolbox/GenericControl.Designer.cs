﻿namespace WebsiteStudio.Modules.Toolbox.Quotes {
    partial class GenericControl<T> {
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
			this.lvwData = new System.Windows.Forms.ListView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUp = new System.Windows.Forms.ToolStripButton();
			this.tsbDown = new System.Windows.Forms.ToolStripButton();
			this.clnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwData
			// 
			this.lvwData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwData.FullRowSelect = true;
			this.lvwData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwData.HideSelection = false;
			this.lvwData.Location = new System.Drawing.Point(0, 25);
			this.lvwData.MultiSelect = false;
			this.lvwData.Name = "lvwData";
			this.lvwData.Size = new System.Drawing.Size(473, 299);
			this.lvwData.TabIndex = 0;
			this.lvwData.UseCompatibleStateImageBehavior = false;
			this.lvwData.View = System.Windows.Forms.View.Details;
			this.lvwData.VirtualMode = true;
			this.lvwData.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwData_RetrieveVirtualItem);
			this.lvwData.SelectedIndexChanged += new System.EventHandler(this.lvwData_SelectedIndexChanged);
			this.lvwData.DoubleClick += new System.EventHandler(this.lvwData_DoubleClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.tsbEdit,
            this.toolStripSeparator1,
            this.tsbUp,
            this.tsbDown});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(473, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsbAdd
			// 
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(41, 22);
			this.tsbAdd.Text = "[Add]";
			this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
			// 
			// tsbEdit
			// 
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(39, 22);
			this.tsbEdit.Text = "[Edit]";
			this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
			// 
			// tsbDelete
			// 
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(52, 22);
			this.tsbDelete.Text = "[Delete]";
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbUp
			// 
			this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUp.Name = "tsbUp";
			this.tsbUp.Size = new System.Drawing.Size(34, 22);
			this.tsbUp.Text = "[Up]";
			this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
			// 
			// tsbDown
			// 
			this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDown.Name = "tsbDown";
			this.tsbDown.Size = new System.Drawing.Size(50, 22);
			this.tsbDown.Text = "[Down]";
			this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
			// 
			// clnTitle
			// 
			this.clnTitle.Text = "[Title]";
			this.clnTitle.Width = 140;
			// 
			// clnText
			// 
			this.clnText.Text = "[Text]";
			this.clnText.Width = 240;
			// 
			// GenericControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwData);
			this.Controls.Add(this.toolStrip1);
			this.Name = "GenericControl";
			this.Size = new System.Drawing.Size(473, 324);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwData;
        private System.Windows.Forms.ColumnHeader clnTitle;
        private System.Windows.Forms.ColumnHeader clnText;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbUp;
		private System.Windows.Forms.ToolStripButton tsbDown;
	}
}
