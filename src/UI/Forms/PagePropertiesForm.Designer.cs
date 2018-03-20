namespace WebsiteStudio.UI.Forms {
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
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.lblDisable = new System.Windows.Forms.Label();
			this.lblIncludeInMenu = new System.Windows.Forms.Label();
			this.cbxChangeFrequency = new System.Windows.Forms.ComboBox();
			this.lblChangeFrequency = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lblPathName = new System.Windows.Forms.Label();
			this.chkDisable = new System.Windows.Forms.CheckBox();
			this.txtPathName = new System.Windows.Forms.TextBox();
			this.chkIncludeInMenu = new System.Windows.Forms.CheckBox();
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
			this.tabLink = new System.Windows.Forms.TabPage();
			this.gbxLinkTarget = new System.Windows.Forms.GroupBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.txtLinkTarget = new System.Windows.Forms.TextBox();
			this.gbxLinkType = new System.Windows.Forms.GroupBox();
			this.rbLinkNone = new System.Windows.Forms.RadioButton();
			this.rbLinkRedirect = new System.Windows.Forms.RadioButton();
			this.tabSecurity = new System.Windows.Forms.TabPage();
			this.lvwSecurity = new System.Windows.Forms.ListView();
			this.clnGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.tabDetails.SuspendLayout();
			this.gbxGeneral.SuspendLayout();
			this.tabTitle.SuspendLayout();
			this.tabMeta.SuspendLayout();
			this.tabRobots.SuspendLayout();
			this.tabLink.SuspendLayout();
			this.gbxLinkTarget.SuspendLayout();
			this.gbxLinkType.SuspendLayout();
			this.tabSecurity.SuspendLayout();
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
			this.tabMain.Controls.Add(this.tabLink);
			this.tabMain.Controls.Add(this.tabSecurity);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(460, 265);
			this.tabMain.TabIndex = 0;
			// 
			// tabDetails
			// 
			this.tabDetails.Controls.Add(this.gbxGeneral);
			this.tabDetails.Location = new System.Drawing.Point(4, 22);
			this.tabDetails.Name = "tabDetails";
			this.tabDetails.Padding = new System.Windows.Forms.Padding(3);
			this.tabDetails.Size = new System.Drawing.Size(452, 239);
			this.tabDetails.TabIndex = 0;
			this.tabDetails.Text = "[Details]";
			this.tabDetails.UseVisualStyleBackColor = true;
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.lblDisable);
			this.gbxGeneral.Controls.Add(this.lblIncludeInMenu);
			this.gbxGeneral.Controls.Add(this.cbxChangeFrequency);
			this.gbxGeneral.Controls.Add(this.lblChangeFrequency);
			this.gbxGeneral.Controls.Add(this.label1);
			this.gbxGeneral.Controls.Add(this.lblPathName);
			this.gbxGeneral.Controls.Add(this.chkDisable);
			this.gbxGeneral.Controls.Add(this.txtPathName);
			this.gbxGeneral.Controls.Add(this.chkIncludeInMenu);
			this.gbxGeneral.Location = new System.Drawing.Point(6, 6);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(440, 189);
			this.gbxGeneral.TabIndex = 6;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// lblDisable
			// 
			this.lblDisable.AutoSize = true;
			this.lblDisable.Location = new System.Drawing.Point(14, 74);
			this.lblDisable.Name = "lblDisable";
			this.lblDisable.Size = new System.Drawing.Size(51, 13);
			this.lblDisable.TabIndex = 10;
			this.lblDisable.Text = "[Disable:]";
			// 
			// lblIncludeInMenu
			// 
			this.lblIncludeInMenu.AutoSize = true;
			this.lblIncludeInMenu.Location = new System.Drawing.Point(14, 51);
			this.lblIncludeInMenu.Name = "lblIncludeInMenu";
			this.lblIncludeInMenu.Size = new System.Drawing.Size(87, 13);
			this.lblIncludeInMenu.TabIndex = 9;
			this.lblIncludeInMenu.Text = "[IncludeInMenu:]";
			// 
			// cbxChangeFrequency
			// 
			this.cbxChangeFrequency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxChangeFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxChangeFrequency.FormattingEnabled = true;
			this.cbxChangeFrequency.Location = new System.Drawing.Point(147, 117);
			this.cbxChangeFrequency.Name = "cbxChangeFrequency";
			this.cbxChangeFrequency.Size = new System.Drawing.Size(273, 21);
			this.cbxChangeFrequency.TabIndex = 8;
			// 
			// lblChangeFrequency
			// 
			this.lblChangeFrequency.AutoSize = true;
			this.lblChangeFrequency.Location = new System.Drawing.Point(14, 120);
			this.lblChangeFrequency.Name = "lblChangeFrequency";
			this.lblChangeFrequency.Size = new System.Drawing.Size(103, 13);
			this.lblChangeFrequency.TabIndex = 7;
			this.lblChangeFrequency.Text = "[ChangeFrequency:]";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.label1.Location = new System.Drawing.Point(6, 102);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(428, 1);
			this.label1.TabIndex = 6;
			// 
			// lblPathName
			// 
			this.lblPathName.AutoSize = true;
			this.lblPathName.Location = new System.Drawing.Point(14, 27);
			this.lblPathName.Name = "lblPathName";
			this.lblPathName.Size = new System.Drawing.Size(67, 13);
			this.lblPathName.TabIndex = 0;
			this.lblPathName.Text = "[Path name:]";
			// 
			// chkDisable
			// 
			this.chkDisable.AutoSize = true;
			this.chkDisable.Location = new System.Drawing.Point(147, 73);
			this.chkDisable.Name = "chkDisable";
			this.chkDisable.Size = new System.Drawing.Size(50, 17);
			this.chkDisable.TabIndex = 5;
			this.chkDisable.Text = "[Yes]";
			this.chkDisable.UseVisualStyleBackColor = true;
			// 
			// txtPathName
			// 
			this.txtPathName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathName.Location = new System.Drawing.Point(147, 24);
			this.txtPathName.Name = "txtPathName";
			this.txtPathName.Size = new System.Drawing.Size(273, 20);
			this.txtPathName.TabIndex = 1;
			this.txtPathName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPathName_KeyPress);
			// 
			// chkIncludeInMenu
			// 
			this.chkIncludeInMenu.AutoSize = true;
			this.chkIncludeInMenu.Location = new System.Drawing.Point(147, 50);
			this.chkIncludeInMenu.Name = "chkIncludeInMenu";
			this.chkIncludeInMenu.Size = new System.Drawing.Size(65, 17);
			this.chkIncludeInMenu.TabIndex = 4;
			this.chkIncludeInMenu.Text = "[Enable]";
			this.chkIncludeInMenu.UseVisualStyleBackColor = true;
			// 
			// tabTitle
			// 
			this.tabTitle.Controls.Add(this.lvwTitle);
			this.tabTitle.Location = new System.Drawing.Point(4, 22);
			this.tabTitle.Name = "tabTitle";
			this.tabTitle.Padding = new System.Windows.Forms.Padding(3);
			this.tabTitle.Size = new System.Drawing.Size(452, 239);
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
			this.lvwTitle.Size = new System.Drawing.Size(446, 233);
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
			this.tabMeta.Size = new System.Drawing.Size(452, 239);
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
			this.lvwMeta.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwMeta.Location = new System.Drawing.Point(3, 3);
			this.lvwMeta.Name = "lvwMeta";
			this.lvwMeta.Size = new System.Drawing.Size(446, 233);
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
			this.tabRobots.Size = new System.Drawing.Size(452, 239);
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
			// tabLink
			// 
			this.tabLink.Controls.Add(this.gbxLinkTarget);
			this.tabLink.Controls.Add(this.gbxLinkType);
			this.tabLink.Location = new System.Drawing.Point(4, 22);
			this.tabLink.Name = "tabLink";
			this.tabLink.Padding = new System.Windows.Forms.Padding(3);
			this.tabLink.Size = new System.Drawing.Size(452, 239);
			this.tabLink.TabIndex = 4;
			this.tabLink.Text = "[Link]";
			this.tabLink.UseVisualStyleBackColor = true;
			// 
			// gbxLinkTarget
			// 
			this.gbxLinkTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxLinkTarget.Controls.Add(this.btnBrowse);
			this.gbxLinkTarget.Controls.Add(this.txtLinkTarget);
			this.gbxLinkTarget.Location = new System.Drawing.Point(6, 98);
			this.gbxLinkTarget.Name = "gbxLinkTarget";
			this.gbxLinkTarget.Size = new System.Drawing.Size(440, 79);
			this.gbxLinkTarget.TabIndex = 2;
			this.gbxLinkTarget.TabStop = false;
			this.gbxLinkTarget.Text = "[Target]";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(373, 32);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(49, 20);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// txtLinkTarget
			// 
			this.txtLinkTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLinkTarget.Location = new System.Drawing.Point(19, 32);
			this.txtLinkTarget.Name = "txtLinkTarget";
			this.txtLinkTarget.Size = new System.Drawing.Size(348, 20);
			this.txtLinkTarget.TabIndex = 0;
			// 
			// gbxLinkType
			// 
			this.gbxLinkType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxLinkType.Controls.Add(this.rbLinkNone);
			this.gbxLinkType.Controls.Add(this.rbLinkRedirect);
			this.gbxLinkType.Location = new System.Drawing.Point(6, 6);
			this.gbxLinkType.Name = "gbxLinkType";
			this.gbxLinkType.Size = new System.Drawing.Size(440, 86);
			this.gbxLinkType.TabIndex = 1;
			this.gbxLinkType.TabStop = false;
			this.gbxLinkType.Text = "[Type]";
			// 
			// rbLinkNone
			// 
			this.rbLinkNone.AutoSize = true;
			this.rbLinkNone.Location = new System.Drawing.Point(19, 28);
			this.rbLinkNone.Name = "rbLinkNone";
			this.rbLinkNone.Size = new System.Drawing.Size(57, 17);
			this.rbLinkNone.TabIndex = 2;
			this.rbLinkNone.TabStop = true;
			this.rbLinkNone.Text = "[None]";
			this.rbLinkNone.UseVisualStyleBackColor = true;
			// 
			// rbLinkRedirect
			// 
			this.rbLinkRedirect.AutoSize = true;
			this.rbLinkRedirect.Location = new System.Drawing.Point(19, 51);
			this.rbLinkRedirect.Name = "rbLinkRedirect";
			this.rbLinkRedirect.Size = new System.Drawing.Size(71, 17);
			this.rbLinkRedirect.TabIndex = 1;
			this.rbLinkRedirect.TabStop = true;
			this.rbLinkRedirect.Text = "[Redirect]";
			this.rbLinkRedirect.UseVisualStyleBackColor = true;
			// 
			// tabSecurity
			// 
			this.tabSecurity.Controls.Add(this.lvwSecurity);
			this.tabSecurity.Location = new System.Drawing.Point(4, 22);
			this.tabSecurity.Name = "tabSecurity";
			this.tabSecurity.Size = new System.Drawing.Size(452, 239);
			this.tabSecurity.TabIndex = 5;
			this.tabSecurity.Text = "[Security]";
			this.tabSecurity.UseVisualStyleBackColor = true;
			// 
			// lvwSecurity
			// 
			this.lvwSecurity.CheckBoxes = true;
			this.lvwSecurity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnGroup});
			this.lvwSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwSecurity.GridLines = true;
			this.lvwSecurity.Location = new System.Drawing.Point(0, 0);
			this.lvwSecurity.Name = "lvwSecurity";
			this.lvwSecurity.Size = new System.Drawing.Size(452, 239);
			this.lvwSecurity.TabIndex = 0;
			this.lvwSecurity.UseCompatibleStateImageBehavior = false;
			this.lvwSecurity.View = System.Windows.Forms.View.Details;
			// 
			// clnGroup
			// 
			this.clnGroup.Text = "[Group]";
			this.clnGroup.Width = 200;
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
			this.ClientSize = new System.Drawing.Size(484, 322);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.tabMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 360);
			this.Name = "PagePropertiesForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Page]";
			this.tabMain.ResumeLayout(false);
			this.tabDetails.ResumeLayout(false);
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.tabTitle.ResumeLayout(false);
			this.tabMeta.ResumeLayout(false);
			this.tabRobots.ResumeLayout(false);
			this.tabRobots.PerformLayout();
			this.tabLink.ResumeLayout(false);
			this.gbxLinkTarget.ResumeLayout(false);
			this.gbxLinkTarget.PerformLayout();
			this.gbxLinkType.ResumeLayout(false);
			this.gbxLinkType.PerformLayout();
			this.tabSecurity.ResumeLayout(false);
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
		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.ComboBox cbxChangeFrequency;
		private System.Windows.Forms.Label lblChangeFrequency;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblDisable;
		private System.Windows.Forms.Label lblIncludeInMenu;
		private System.Windows.Forms.TabPage tabLink;
		private System.Windows.Forms.GroupBox gbxLinkTarget;
		private System.Windows.Forms.GroupBox gbxLinkType;
		private System.Windows.Forms.RadioButton rbLinkNone;
		private System.Windows.Forms.RadioButton rbLinkRedirect;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox txtLinkTarget;
		private System.Windows.Forms.TabPage tabSecurity;
		private System.Windows.Forms.ListView lvwSecurity;
		private System.Windows.Forms.ColumnHeader clnGroup;
	}
}