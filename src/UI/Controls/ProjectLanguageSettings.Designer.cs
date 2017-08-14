namespace WebsiteStudio.UI.Controls
{
    partial class ProjectLanguageSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectLanguageSettings));
            this.lvwLanguages = new System.Windows.Forms.ListView();
            this.clnID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwLanguages
            // 
            this.lvwLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLanguages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnID,
            this.clnDescription});
            this.lvwLanguages.FullRowSelect = true;
            this.lvwLanguages.GridLines = true;
            this.lvwLanguages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwLanguages.Location = new System.Drawing.Point(0, 28);
            this.lvwLanguages.MultiSelect = false;
            this.lvwLanguages.Name = "lvwLanguages";
            this.lvwLanguages.Size = new System.Drawing.Size(481, 235);
            this.lvwLanguages.TabIndex = 0;
            this.lvwLanguages.UseCompatibleStateImageBehavior = false;
            this.lvwLanguages.View = System.Windows.Forms.View.Details;
            this.lvwLanguages.VirtualMode = true;
            this.lvwLanguages.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwLanguages_RetrieveVirtualItem);
            this.lvwLanguages.SelectedIndexChanged += new System.EventHandler(this.lvwLanguages_SelectedIndexChanged);
            // 
            // clnID
            // 
            this.clnID.Text = "[ID]";
            this.clnID.Width = 120;
            // 
            // clnDescription
            // 
            this.clnDescription.Text = "[Description]";
            this.clnDescription.Width = 240;
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(481, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(57, 22);
            this.tsbAdd.Text = "[Add]";
            this.tsbAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(55, 22);
            this.tsbEdit.Text = "[Edit]";
            this.tsbEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(68, 22);
            this.tsbDelete.Text = "[Delete]";
            this.tsbDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ProjectLanguageSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.lvwLanguages);
            this.Name = "ProjectLanguageSettings";
            this.Size = new System.Drawing.Size(481, 263);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwLanguages;
        private System.Windows.Forms.ColumnHeader clnID;
        private System.Windows.Forms.ColumnHeader clnDescription;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
    }
}
