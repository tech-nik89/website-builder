namespace WebsiteBuilder.UI.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProjectSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProjectSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProjectSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuProjectExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContentMedia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContentFooter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuild = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuildProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuildAndRunProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBuildPage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBuildCleanOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.ptvwPages = new WebsiteBuilder.UI.Controls.PagesTreeView();
            this.sfdProject = new System.Windows.Forms.SaveFileDialog();
            this.ofdProject = new System.Windows.Forms.OpenFileDialog();
            this.sstMain = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbProjectNew = new System.Windows.Forms.ToolStripButton();
            this.tsbProjectOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbProjectSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbContentMedia = new System.Windows.Forms.ToolStripButton();
            this.tsbContentFooter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBuildProject = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tscLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.mnuMain.SuspendLayout();
            this.sstMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProject,
            this.mnuContent,
            this.mnuBuild,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(833, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuProject
            // 
            this.mnuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProjectNew,
            this.mnuProjectOpen,
            this.toolStripSeparator3,
            this.mnuProjectSave,
            this.mnuProjectSaveAs,
            this.toolStripSeparator2,
            this.mnuProjectSettings,
            this.toolStripSeparator1,
            this.mnuProjectExit});
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Size = new System.Drawing.Size(64, 20);
            this.mnuProject.Text = "[Project]";
            // 
            // mnuProjectNew
            // 
            this.mnuProjectNew.Name = "mnuProjectNew";
            this.mnuProjectNew.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectNew.Text = "[New]";
            this.mnuProjectNew.Click += new System.EventHandler(this.mnuProjectNew_Click);
            // 
            // mnuProjectOpen
            // 
            this.mnuProjectOpen.Name = "mnuProjectOpen";
            this.mnuProjectOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuProjectOpen.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectOpen.Text = "[Open]";
            this.mnuProjectOpen.Click += new System.EventHandler(this.mnuProjectOpen_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuProjectSave
            // 
            this.mnuProjectSave.Name = "mnuProjectSave";
            this.mnuProjectSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuProjectSave.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectSave.Text = "[Save]";
            this.mnuProjectSave.Click += new System.EventHandler(this.mnuProjectSave_Click);
            // 
            // mnuProjectSaveAs
            // 
            this.mnuProjectSaveAs.Name = "mnuProjectSaveAs";
            this.mnuProjectSaveAs.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectSaveAs.Text = "[Save as ...]";
            this.mnuProjectSaveAs.Click += new System.EventHandler(this.mnuProjectSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuProjectSettings
            // 
            this.mnuProjectSettings.Name = "mnuProjectSettings";
            this.mnuProjectSettings.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectSettings.Text = "[Project settings]";
            this.mnuProjectSettings.Click += new System.EventHandler(this.mnuProjectSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // mnuProjectExit
            // 
            this.mnuProjectExit.Name = "mnuProjectExit";
            this.mnuProjectExit.Size = new System.Drawing.Size(163, 22);
            this.mnuProjectExit.Text = "[Exit]";
            this.mnuProjectExit.Click += new System.EventHandler(this.mnuProjectExit_Click);
            // 
            // mnuContent
            // 
            this.mnuContent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContentMedia,
            this.mnuContentFooter});
            this.mnuContent.Name = "mnuContent";
            this.mnuContent.Size = new System.Drawing.Size(70, 20);
            this.mnuContent.Text = "[Content]";
            // 
            // mnuContentMedia
            // 
            this.mnuContentMedia.Name = "mnuContentMedia";
            this.mnuContentMedia.Size = new System.Drawing.Size(116, 22);
            this.mnuContentMedia.Text = "[Media]";
            this.mnuContentMedia.Click += new System.EventHandler(this.mnuContentMedia_Click);
            // 
            // mnuContentFooter
            // 
            this.mnuContentFooter.Name = "mnuContentFooter";
            this.mnuContentFooter.Size = new System.Drawing.Size(116, 22);
            this.mnuContentFooter.Text = "[Footer]";
            this.mnuContentFooter.Click += new System.EventHandler(this.mnuContentFooter_Click);
            // 
            // mnuBuild
            // 
            this.mnuBuild.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBuildProject,
            this.mnuBuildAndRunProject,
            this.mnuBuildPage,
            this.toolStripSeparator6,
            this.mnuBuildCleanOutput});
            this.mnuBuild.Name = "mnuBuild";
            this.mnuBuild.Size = new System.Drawing.Size(54, 20);
            this.mnuBuild.Text = "[Build]";
            // 
            // mnuBuildProject
            // 
            this.mnuBuildProject.Name = "mnuBuildProject";
            this.mnuBuildProject.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.mnuBuildProject.Size = new System.Drawing.Size(221, 22);
            this.mnuBuildProject.Text = "[Build project]";
            this.mnuBuildProject.Click += new System.EventHandler(this.mnuBuildProject_Click);
            // 
            // mnuBuildAndRunProject
            // 
            this.mnuBuildAndRunProject.Name = "mnuBuildAndRunProject";
            this.mnuBuildAndRunProject.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuBuildAndRunProject.Size = new System.Drawing.Size(221, 22);
            this.mnuBuildAndRunProject.Text = "[Build and open project]";
            this.mnuBuildAndRunProject.Click += new System.EventHandler(this.mnuBuildAndRunProject_Click);
            // 
            // mnuBuildPage
            // 
            this.mnuBuildPage.Name = "mnuBuildPage";
            this.mnuBuildPage.Size = new System.Drawing.Size(221, 22);
            this.mnuBuildPage.Text = "[Build page]";
            this.mnuBuildPage.Click += new System.EventHandler(this.mnuBuildPage_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(218, 6);
            // 
            // mnuBuildCleanOutput
            // 
            this.mnuBuildCleanOutput.Name = "mnuBuildCleanOutput";
            this.mnuBuildCleanOutput.Size = new System.Drawing.Size(221, 22);
            this.mnuBuildCleanOutput.Text = "[Clear output directory]";
            this.mnuBuildCleanOutput.Click += new System.EventHandler(this.mnuBuildCleanOutput_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(24, 20);
            this.mnuHelp.Text = "?";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(115, 22);
            this.mnuHelpAbout.Text = "[About]";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // ptvwPages
            // 
            this.ptvwPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptvwPages.Location = new System.Drawing.Point(0, 49);
            this.ptvwPages.Name = "ptvwPages";
            this.ptvwPages.Project = null;
            this.ptvwPages.SelectedLanguage = null;
            this.ptvwPages.Size = new System.Drawing.Size(833, 420);
            this.ptvwPages.TabIndex = 0;
            this.ptvwPages.ContentUpdated += new System.EventHandler(this.ptvwPages_ContentUpdated);
            this.ptvwPages.BuildPageRequested += new System.EventHandler<WebsiteBuilder.UI.Controls.BuildPageEventArgs>(this.ptvwPages_BuildPageRequested);
            // 
            // sstMain
            // 
            this.sstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tspProgress});
            this.sstMain.Location = new System.Drawing.Point(0, 469);
            this.sstMain.Name = "sstMain";
            this.sstMain.Size = new System.Drawing.Size(833, 22);
            this.sstMain.TabIndex = 2;
            this.sstMain.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(676, 17);
            this.tslStatus.Spring = true;
            this.tslStatus.Text = "[...]";
            this.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tspProgress
            // 
            this.tspProgress.Name = "tspProgress";
            this.tspProgress.Size = new System.Drawing.Size(140, 16);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbProjectNew,
            this.tsbProjectOpen,
            this.tsbProjectSave,
            this.toolStripSeparator4,
            this.tsbContentMedia,
            this.tsbContentFooter,
            this.toolStripSeparator5,
            this.tsbBuildProject,
            this.toolStripSeparator7,
            this.tscLanguage});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(833, 25);
            this.tsMain.TabIndex = 3;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbProjectNew
            // 
            this.tsbProjectNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProjectNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbProjectNew.Image")));
            this.tsbProjectNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProjectNew.Name = "tsbProjectNew";
            this.tsbProjectNew.Size = new System.Drawing.Size(23, 22);
            this.tsbProjectNew.Text = "[New]";
            this.tsbProjectNew.Click += new System.EventHandler(this.mnuProjectNew_Click);
            // 
            // tsbProjectOpen
            // 
            this.tsbProjectOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProjectOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbProjectOpen.Image")));
            this.tsbProjectOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProjectOpen.Name = "tsbProjectOpen";
            this.tsbProjectOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbProjectOpen.Text = "[Open]";
            this.tsbProjectOpen.Click += new System.EventHandler(this.mnuProjectOpen_Click);
            // 
            // tsbProjectSave
            // 
            this.tsbProjectSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProjectSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbProjectSave.Image")));
            this.tsbProjectSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProjectSave.Name = "tsbProjectSave";
            this.tsbProjectSave.Size = new System.Drawing.Size(23, 22);
            this.tsbProjectSave.Text = "[Save]";
            this.tsbProjectSave.Click += new System.EventHandler(this.mnuProjectSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbContentMedia
            // 
            this.tsbContentMedia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbContentMedia.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentMedia.Image")));
            this.tsbContentMedia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentMedia.Name = "tsbContentMedia";
            this.tsbContentMedia.Size = new System.Drawing.Size(23, 22);
            this.tsbContentMedia.Text = "[Media]";
            this.tsbContentMedia.Click += new System.EventHandler(this.mnuContentMedia_Click);
            // 
            // tsbContentFooter
            // 
            this.tsbContentFooter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbContentFooter.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentFooter.Image")));
            this.tsbContentFooter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentFooter.Name = "tsbContentFooter";
            this.tsbContentFooter.Size = new System.Drawing.Size(23, 22);
            this.tsbContentFooter.Text = "[Footer]";
            this.tsbContentFooter.Click += new System.EventHandler(this.mnuContentFooter_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBuildProject
            // 
            this.tsbBuildProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBuildProject.Image = ((System.Drawing.Image)(resources.GetObject("tsbBuildProject.Image")));
            this.tsbBuildProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBuildProject.Name = "tsbBuildProject";
            this.tsbBuildProject.Size = new System.Drawing.Size(23, 22);
            this.tsbBuildProject.Text = "toolStripButton1";
            this.tsbBuildProject.Click += new System.EventHandler(this.mnuBuildProject_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tscLanguage
            // 
            this.tscLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscLanguage.Name = "tscLanguage";
            this.tscLanguage.Size = new System.Drawing.Size(121, 25);
            this.tscLanguage.SelectedIndexChanged += new System.EventHandler(this.tscLanguage_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 491);
            this.Controls.Add(this.ptvwPages);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.sstMain);
            this.Controls.Add(this.mnuMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(580, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "[Open Website Builder]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.sstMain.ResumeLayout(false);
            this.sstMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectExit;
        private Controls.PagesTreeView ptvwPages;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectNew;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectSave;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SaveFileDialog sfdProject;
        private System.Windows.Forms.OpenFileDialog ofdProject;
        private System.Windows.Forms.ToolStripMenuItem mnuBuild;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildProject;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildAndRunProject;
        private System.Windows.Forms.StatusStrip sstMain;
        private System.Windows.Forms.ToolStripProgressBar tspProgress;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbProjectNew;
        private System.Windows.Forms.ToolStripButton tsbProjectOpen;
        private System.Windows.Forms.ToolStripButton tsbProjectSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbBuildProject;
        private System.Windows.Forms.ToolStripMenuItem mnuContent;
        private System.Windows.Forms.ToolStripMenuItem mnuContentFooter;
        private System.Windows.Forms.ToolStripMenuItem mnuContentMedia;
        private System.Windows.Forms.ToolStripButton tsbContentMedia;
        private System.Windows.Forms.ToolStripButton tsbContentFooter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildCleanOutput;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildPage;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripComboBox tscLanguage;
    }
}

