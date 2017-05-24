namespace WebsiteBuilder.UI.Forms {
    partial class ProjectPropertiesForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.pgsGeneral = new WebsiteBuilder.UI.Controls.ProjectGeneralSettings();
            this.tabLanguages = new System.Windows.Forms.TabPage();
            this.plsLanguages = new WebsiteBuilder.UI.Controls.ProjectLanguageSettings();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabMeta = new System.Windows.Forms.TabPage();
            this.lvwMeta = new System.Windows.Forms.ListView();
            this.clnLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabMain.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabLanguages.SuspendLayout();
            this.tabMeta.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabGeneral);
            this.tabMain.Controls.Add(this.tabLanguages);
            this.tabMain.Controls.Add(this.tabMeta);
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(484, 251);
            this.tabMain.TabIndex = 0;
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.pgsGeneral);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(476, 225);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "[General]";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // pgsGeneral
            // 
            this.pgsGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgsGeneral.Location = new System.Drawing.Point(3, 3);
            this.pgsGeneral.Name = "pgsGeneral";
            this.pgsGeneral.Size = new System.Drawing.Size(470, 219);
            this.pgsGeneral.TabIndex = 0;
            // 
            // tabLanguages
            // 
            this.tabLanguages.Controls.Add(this.plsLanguages);
            this.tabLanguages.Location = new System.Drawing.Point(4, 22);
            this.tabLanguages.Name = "tabLanguages";
            this.tabLanguages.Padding = new System.Windows.Forms.Padding(3);
            this.tabLanguages.Size = new System.Drawing.Size(476, 225);
            this.tabLanguages.TabIndex = 1;
            this.tabLanguages.Text = "[Languages]";
            this.tabLanguages.UseVisualStyleBackColor = true;
            // 
            // plsLanguages
            // 
            this.plsLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plsLanguages.Languages = new WebsiteBuilder.Core.Localization.Language[0];
            this.plsLanguages.Location = new System.Drawing.Point(3, 3);
            this.plsLanguages.Name = "plsLanguages";
            this.plsLanguages.Size = new System.Drawing.Size(470, 219);
            this.plsLanguages.TabIndex = 0;
            // 
            // btnAccept
            // 
            this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccept.Location = new System.Drawing.Point(286, 275);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(100, 25);
            this.btnAccept.TabIndex = 1;
            this.btnAccept.Text = "[OK]";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(392, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabMeta
            // 
            this.tabMeta.Controls.Add(this.lvwMeta);
            this.tabMeta.Location = new System.Drawing.Point(4, 22);
            this.tabMeta.Name = "tabMeta";
            this.tabMeta.Padding = new System.Windows.Forms.Padding(3);
            this.tabMeta.Size = new System.Drawing.Size(476, 225);
            this.tabMeta.TabIndex = 2;
            this.tabMeta.Text = "[Meta]";
            this.tabMeta.UseVisualStyleBackColor = true;
            // 
            // lvwMeta
            // 
            this.lvwMeta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnLanguage});
            this.lvwMeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMeta.FullRowSelect = true;
            this.lvwMeta.GridLines = true;
            this.lvwMeta.Location = new System.Drawing.Point(3, 3);
            this.lvwMeta.MultiSelect = false;
            this.lvwMeta.Name = "lvwMeta";
            this.lvwMeta.Size = new System.Drawing.Size(470, 219);
            this.lvwMeta.TabIndex = 0;
            this.lvwMeta.UseCompatibleStateImageBehavior = false;
            this.lvwMeta.View = System.Windows.Forms.View.Details;
            this.lvwMeta.DoubleClick += new System.EventHandler(this.lvwMeta_DoubleClick);
            // 
            // clnLanguage
            // 
            this.clnLanguage.Text = "[Language]";
            this.clnLanguage.Width = 180;
            // 
            // ProjectPropertiesForm
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(508, 312);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.tabMain);
            this.MinimizeBox = false;
            this.Name = "ProjectPropertiesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Project]";
            this.tabMain.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabLanguages.ResumeLayout(false);
            this.tabMeta.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabLanguages;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private Controls.ProjectGeneralSettings pgsGeneral;
        private Controls.ProjectLanguageSettings plsLanguages;
        private System.Windows.Forms.TabPage tabMeta;
        private System.Windows.Forms.ListView lvwMeta;
        private System.Windows.Forms.ColumnHeader clnLanguage;
    }
}