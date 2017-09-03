namespace WebsiteStudio.UI.Forms
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
			this.mnuProjectRecents = new System.Windows.Forms.ToolStripMenuItem();
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
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuBuildPublish = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsPlugins = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.sfdProject = new System.Windows.Forms.SaveFileDialog();
			this.ofdProject = new System.Windows.Forms.OpenFileDialog();
			this.sstMain = new System.Windows.Forms.StatusStrip();
			this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.tspProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.tscMain = new System.Windows.Forms.ToolStripContainer();
			this.mnuHelpUpdateCheck = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMain.SuspendLayout();
			this.sstMain.SuspendLayout();
			this.tscMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProject,
            this.mnuContent,
            this.mnuBuild,
            this.mnuTools,
            this.mnuHelp});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(1044, 24);
			this.mnuMain.TabIndex = 1;
			this.mnuMain.Text = "menuStrip1";
			// 
			// mnuProject
			// 
			this.mnuProject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuProjectNew,
            this.mnuProjectOpen,
            this.mnuProjectRecents,
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
			// mnuProjectRecents
			// 
			this.mnuProjectRecents.Name = "mnuProjectRecents";
			this.mnuProjectRecents.Size = new System.Drawing.Size(163, 22);
			this.mnuProjectRecents.Text = "[Recents]";
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
            this.mnuBuildCleanOutput,
            this.toolStripSeparator8,
            this.mnuBuildPublish});
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
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(218, 6);
			// 
			// mnuBuildPublish
			// 
			this.mnuBuildPublish.Name = "mnuBuildPublish";
			this.mnuBuildPublish.Size = new System.Drawing.Size(221, 22);
			this.mnuBuildPublish.Text = "[Publish]";
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsPlugins});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(55, 20);
			this.mnuTools.Text = "[Tools]";
			// 
			// mnuToolsPlugins
			// 
			this.mnuToolsPlugins.Name = "mnuToolsPlugins";
			this.mnuToolsPlugins.Size = new System.Drawing.Size(121, 22);
			this.mnuToolsPlugins.Text = "[Plugins]";
			this.mnuToolsPlugins.Click += new System.EventHandler(this.mnuToolsPlugins_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpUpdateCheck,
            this.toolStripSeparator4,
            this.mnuHelpAbout});
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(24, 20);
			this.mnuHelp.Text = "?";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Name = "mnuHelpAbout";
			this.mnuHelpAbout.Size = new System.Drawing.Size(170, 22);
			this.mnuHelpAbout.Text = "[About]";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// sstMain
			// 
			this.sstMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus,
            this.tspProgress});
			this.sstMain.Location = new System.Drawing.Point(0, 469);
			this.sstMain.Name = "sstMain";
			this.sstMain.Size = new System.Drawing.Size(1044, 22);
			this.sstMain.TabIndex = 2;
			this.sstMain.Text = "statusStrip1";
			// 
			// tslStatus
			// 
			this.tslStatus.Name = "tslStatus";
			this.tslStatus.Size = new System.Drawing.Size(878, 17);
			this.tslStatus.Spring = true;
			this.tslStatus.Text = "[...]";
			this.tslStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tspProgress
			// 
			this.tspProgress.Margin = new System.Windows.Forms.Padding(1, 3, 10, 3);
			this.tspProgress.Name = "tspProgress";
			this.tspProgress.Size = new System.Drawing.Size(140, 16);
			// 
			// tscMain
			// 
			// 
			// tscMain.ContentPanel
			// 
			this.tscMain.ContentPanel.Size = new System.Drawing.Size(1044, 420);
			this.tscMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tscMain.Location = new System.Drawing.Point(0, 24);
			this.tscMain.Name = "tscMain";
			this.tscMain.Size = new System.Drawing.Size(1044, 445);
			this.tscMain.TabIndex = 4;
			// 
			// mnuHelpUpdateCheck
			// 
			this.mnuHelpUpdateCheck.Name = "mnuHelpUpdateCheck";
			this.mnuHelpUpdateCheck.Size = new System.Drawing.Size(170, 22);
			this.mnuHelpUpdateCheck.Text = "[CheckForUpdate]";
			this.mnuHelpUpdateCheck.Click += new System.EventHandler(this.mnuHelpUpdateCheck_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(167, 6);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1044, 491);
			this.Controls.Add(this.tscMain);
			this.Controls.Add(this.sstMain);
			this.Controls.Add(this.mnuMain);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMain;
			this.MinimumSize = new System.Drawing.Size(580, 300);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "[NiksWebsiteStudio]";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.sstMain.ResumeLayout(false);
			this.sstMain.PerformLayout();
			this.tscMain.ResumeLayout(false);
			this.tscMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuProject;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectExit;
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
        private System.Windows.Forms.ToolStripMenuItem mnuContent;
        private System.Windows.Forms.ToolStripMenuItem mnuContentFooter;
        private System.Windows.Forms.ToolStripMenuItem mnuContentMedia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildCleanOutput;
        private System.Windows.Forms.ToolStripMenuItem mnuBuildPage;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuProjectRecents;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem mnuBuildPublish;
		private System.Windows.Forms.ToolStripMenuItem mnuTools;
		private System.Windows.Forms.ToolStripMenuItem mnuToolsPlugins;
		private System.Windows.Forms.ToolStripContainer tscMain;
		private System.Windows.Forms.ToolStripMenuItem mnuHelpUpdateCheck;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
	}
}

