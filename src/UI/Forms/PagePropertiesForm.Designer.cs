﻿namespace WebsiteStudio.UI.Forms {
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
            this.chkDisable = new System.Windows.Forms.CheckBox();
            this.chkIncludeInMenu = new System.Windows.Forms.CheckBox();
            this.txtPathName = new System.Windows.Forms.TextBox();
            this.lblPathName = new System.Windows.Forms.Label();
            this.tabTitle = new System.Windows.Forms.TabPage();
            this.lvwTitle = new System.Windows.Forms.ListView();
            this.clnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMeta = new System.Windows.Forms.TabPage();
            this.lvwMeta = new System.Windows.Forms.ListView();
            this.clnMetaLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabRobots = new System.Windows.Forms.TabPage();
            this.lblRobotsDescription = new System.Windows.Forms.Label();
            this.chkRobotsNoFollow = new System.Windows.Forms.CheckBox();
            this.chkRobotsNoIndex = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabTitle.SuspendLayout();
            this.tabMeta.SuspendLayout();
            this.tabRobots.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabDetails);
            this.tabMain.Controls.Add(this.tabTitle);
            this.tabMain.Controls.Add(this.tabMeta);
            this.tabMain.Controls.Add(this.tabRobots);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(460, 265);
            this.tabMain.TabIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.chkDisable);
            this.tabDetails.Controls.Add(this.chkIncludeInMenu);
            this.tabDetails.Controls.Add(this.txtPathName);
            this.tabDetails.Controls.Add(this.lblPathName);
            this.tabDetails.Location = new System.Drawing.Point(4, 22);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabDetails.Size = new System.Drawing.Size(452, 239);
            this.tabDetails.TabIndex = 0;
            this.tabDetails.Text = "[Details]";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // chkDisable
            // 
            this.chkDisable.AutoSize = true;
            this.chkDisable.Location = new System.Drawing.Point(19, 62);
            this.chkDisable.Name = "chkDisable";
            this.chkDisable.Size = new System.Drawing.Size(67, 17);
            this.chkDisable.TabIndex = 5;
            this.chkDisable.Text = "[Disable]";
            this.chkDisable.UseVisualStyleBackColor = true;
            // 
            // chkIncludeInMenu
            // 
            this.chkIncludeInMenu.AutoSize = true;
            this.chkIncludeInMenu.Location = new System.Drawing.Point(19, 39);
            this.chkIncludeInMenu.Name = "chkIncludeInMenu";
            this.chkIncludeInMenu.Size = new System.Drawing.Size(103, 17);
            this.chkIncludeInMenu.TabIndex = 4;
            this.chkIncludeInMenu.Text = "[IncludeInMenu]";
            this.chkIncludeInMenu.UseVisualStyleBackColor = true;
            // 
            // txtPathName
            // 
            this.txtPathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPathName.Location = new System.Drawing.Point(113, 13);
            this.txtPathName.Name = "txtPathName";
            this.txtPathName.Size = new System.Drawing.Size(281, 20);
            this.txtPathName.TabIndex = 1;
            this.txtPathName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPathName_KeyPress);
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
            this.tabTitle.Size = new System.Drawing.Size(452, 240);
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
            this.lvwTitle.Size = new System.Drawing.Size(446, 234);
            this.lvwTitle.TabIndex = 0;
            this.lvwTitle.UseCompatibleStateImageBehavior = false;
            this.lvwTitle.View = System.Windows.Forms.View.Details;
            this.lvwTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvwTitle_MouseUp);
            // 
            // clnTitle
            // 
            this.clnTitle.Text = "[Title]";
            this.clnTitle.Width = 140;
            // 
            // clnLanguage
            // 
            this.clnLanguage.Text = "[Language]";
            this.clnLanguage.Width = 160;
            // 
            // tabMeta
            // 
            this.tabMeta.Controls.Add(this.lvwMeta);
            this.tabMeta.Location = new System.Drawing.Point(4, 22);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeta.Size = new System.Drawing.Size(452, 240);
            this.tabMeta.TabIndex = 2;
            this.tabMeta.Text = "[Meta]";
            this.tabMeta.UseVisualStyleBackColor = true;
            // 
            // lvwMeta
            // 
            this.lvwMeta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnMetaLanguage});
            this.lvwMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMeta.FullRowSelect = true;
            this.lvwMeta.GridLines = true;
            this.lvwMeta.Location = new System.Drawing.Point(3, 3);
            this.lvwMeta.Name = "lvwMeta";
            this.lvwMeta.Size = new System.Drawing.Size(446, 234);
            this.lvwMeta.TabIndex = 0;
            this.lvwMeta.UseCompatibleStateImageBehavior = false;
            this.lvwMeta.View = System.Windows.Forms.View.Details;
            this.lvwMeta.DoubleClick += new System.EventHandler(this.lvwMeta_DoubleClick);
            // 
            // clnMetaLanguage
            // 
            this.clnMetaLanguage.Text = "[Language]";
            this.clnMetaLanguage.Width = 180;
            // 
            // tabRobots
            // 
            this.tabRobots.Controls.Add(this.lblRobotsDescription);
            this.tabRobots.Controls.Add(this.chkRobotsNoFollow);
            this.tabRobots.Controls.Add(this.chkRobotsNoIndex);
            this.tabRobots.Location = new System.Drawing.Point(4, 22);
            this.tabRobots.Name = "tabRobots";
            this.tabRobots.Padding = new System.Windows.Forms.Padding(3);
            this.tabRobots.Size = new System.Drawing.Size(452, 240);
            this.tabRobots.TabIndex = 3;
            this.tabRobots.Text = "[Robots]";
            this.tabRobots.UseVisualStyleBackColor = true;
            // 
            // lblRobotsDescription
            // 
            this.lblRobotsDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRobotsDescription.Location = new System.Drawing.Point(17, 121);
            this.lblRobotsDescription.Name = "lblRobotsDescription";
            this.lblRobotsDescription.Size = new System.Drawing.Size(413, 99);
            this.lblRobotsDescription.TabIndex = 2;
            this.lblRobotsDescription.Text = "[Description]";
            this.lblRobotsDescription.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // chkRobotsNoFollow
            // 
            this.chkRobotsNoFollow.AutoSize = true;
            this.chkRobotsNoFollow.Location = new System.Drawing.Point(20, 44);
            this.chkRobotsNoFollow.Name = "chkRobotsNoFollow";
            this.chkRobotsNoFollow.Size = new System.Drawing.Size(76, 17);
            this.chkRobotsNoFollow.TabIndex = 1;
            this.chkRobotsNoFollow.Text = "[NoFollow]";
            this.chkRobotsNoFollow.UseVisualStyleBackColor = true;
            // 
            // chkRobotsNoIndex
            // 
            this.chkRobotsNoIndex.AutoSize = true;
            this.chkRobotsNoIndex.Location = new System.Drawing.Point(20, 21);
            this.chkRobotsNoIndex.Name = "chkRobotsNoIndex";
            this.chkRobotsNoIndex.Size = new System.Drawing.Size(72, 17);
            this.chkRobotsNoIndex.TabIndex = 0;
            this.chkRobotsNoIndex.Text = "[NoIndex]";
            this.chkRobotsNoIndex.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(368, 283);
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
            this.btnAccept.Location = new System.Drawing.Point(262, 283);
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
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabMain);
            this.MinimumSize = new System.Drawing.Size(500, 360);
            this.Name = "PagePropertiesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Page]";
            this.tabMain.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabTitle.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.tabRobots.ResumeLayout(false);
            this.tabRobots.PerformLayout();
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
        private System.Windows.Forms.ListView lvwTitle;
        private System.Windows.Forms.ColumnHeader clnTitle;
        private System.Windows.Forms.ColumnHeader clnLanguage;
        private System.Windows.Forms.CheckBox chkIncludeInMenu;
        private System.Windows.Forms.CheckBox chkDisable;
        private System.Windows.Forms.TabPage tabMeta;
        private System.Windows.Forms.ListView lvwMeta;
        private System.Windows.Forms.ColumnHeader clnMetaLanguage;
        private System.Windows.Forms.TabPage tabRobots;
        private System.Windows.Forms.CheckBox chkRobotsNoIndex;
        private System.Windows.Forms.CheckBox chkRobotsNoFollow;
        private System.Windows.Forms.Label lblRobotsDescription;
    }
}