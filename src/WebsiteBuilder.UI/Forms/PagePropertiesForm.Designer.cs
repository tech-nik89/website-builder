namespace WebsiteBuilder.UI.Forms {
    partial class PagePropertiesForm {
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.lblLayout = new System.Windows.Forms.Label();
            this.cbxLayout = new System.Windows.Forms.ComboBox();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.lblPathName = new System.Windows.Forms.Label();
            this.tabTitle = new System.Windows.Forms.TabPage();
            this.lvwTitle = new System.Windows.Forms.ListView();
            this.clnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabDetails);
            this.tabMain.Controls.Add(this.tabTitle);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(390, 217);
            this.tabMain.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.lblLayout);
            this.tabDetails.Controls.Add(this.cbxLayout);
            this.tabDetails.Controls.Add(this.txtPathName);
            this.tabDetails.Controls.Add(this.lblPathName);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(382, 191);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "[Details]";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // lblLayout
            // 
            this.lblLayout.AutoSize = true;
            this.lblLayout.Location = new System.Drawing.Point(16, 51);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(48, 13);
            this.lblLayout.TabIndex = 3;
            this.lblLayout.Text = "[Layout:]";
            // 
            // cbxLayout
            // 
            this.cbxLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxLayout.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLayout.FormattingEnabled = true;
            this.cbxLayout.Location = new System.Drawing.Point(113, 48);
            this.cbxLayout.Name = "cbxLayout";
            this.cbxLayout.Size = new System.Drawing.Size(251, 21);
            this.cbxLayout.TabIndex = 2;
            // 
            // txtPathName
            // 
            this.txtPathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathName.Location = new System.Drawing.Point(113, 13);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.Size = new System.Drawing.Size(251, 20);
            this.txtPathName.TabIndex = 1;
            // 
            // lblPathName
            // 
            this.lblPathName.AutoSize = true;
            this.lblPathName.Location = new System.Drawing.Point(16, 16);
            this.lblPathName.Name = "lblPathName";
            this.lblPathName.Size = new System.Drawing.Size(67, 13);
            this.lblPathName.TabIndex = 0;
            this.lblPathName.Text = "[Path name:]";
            // 
            // tabTitle
            // 
            this.tabTitle.Controls.Add(this.lvwTitle);
            this.tabTitle.Location = new System.Drawing.Point(4, 22);
            this.tabTitle.Name = "tabTitle";
            this.tabTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tabTitle.Size = new System.Drawing.Size(382, 191);
            this.tabTitle.TabIndex = 1;
            this.tabTitle.Text = "[Title]";
            this.tabTitle.UseVisualStyleBackColor = true;
            // 
            // lvwTitle
            // 
            this.lvwTitle.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnTitle,
            this.clnLanguage});
            this.lvwTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTitle.FullRowSelect = true;
            this.lvwTitle.GridLines = true;
            this.lvwTitle.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTitle.HideSelection = false;
            this.lvwTitle.LabelEdit = true;
            this.lvwTitle.Location = new System.Drawing.Point(3, 3);
            this.lvwTitle.MultiSelect = false;
            this.lvwTitle.Name = "lvwTitle";
            this.lvwTitle.Size = new System.Drawing.Size(376, 185);
            this.lvwTitle.TabIndex = 0;
            this.lvwTitle.UseCompatibleStateImageBehavior = false;
            this.lvwTitle.View = System.Windows.Forms.View.Details;
            this.lvwTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwTitle_MouseUp);
            // 
            // clnTitle
            // 
            this.clnTitle.Text = "Title";
            this.clnTitle.Width = 140;
            // 
            // clnLanguage
            // 
            this.clnLanguage.Text = "Language";
            this.clnLanguage.Width = 160;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(298, 235);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(192, 235);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 25);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "[OK]";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // PagePropertiesForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 272);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabMain);
            this.Name = "PagePropertiesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Page]";
            this.tabMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TabPage tabTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtPathName;
        private System.Windows.Forms.Label lblPathName;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox cbxLayout;
        private System.Windows.Forms.ListView lvwTitle;
        private System.Windows.Forms.ColumnHeader clnTitle;
        private System.Windows.Forms.ColumnHeader clnLanguage;
    }
}