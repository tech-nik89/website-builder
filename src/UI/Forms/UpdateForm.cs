using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.UI.Localization;
using WebsiteStudio.UI.Resources;
using WebsiteStudio.Updater;

namespace WebsiteStudio.UI.Forms {
	public partial class UpdateForm : Form {

		private Version CurrentVersion {
			get => Assembly.GetExecutingAssembly().GetName().Version;
		}

		private readonly Update _Update;

		public UpdateForm(Update update) {
			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();

			_Update = update ?? throw new NullReferenceException("Update is required to display this form.");
			ApplyUpdateInformation();
		}

		private void ApplyIcons() {
			IIconPack iconPack = IconPack.Current;
			if (iconPack == null) {
				return;
			}

			Icon = iconPack.GetIcon(IconPackIcon.Update);
		}

		private void ApplyUpdateInformation() {
			lblVersionAvailable.Text = _Update.Version.ToString();
			lblVersionCurrent.Text = CurrentVersion.ToString();

			txtReleaseNotes.Text = _Update.ReleaseNotes;
			txtReleaseNotes.Select(0, 0);
		}

		private void LocalizeComponent() {
			Text = Strings.Update;

			gbxGeneral.Text = Strings.General;
			gbxReleaseNotes.Text = Strings.ReleaseNotes;

			lblMessage.Text = Strings.UpdateAvailableMessage;
			lblVersionAvailableCaption.Text = Strings.VersionAvailable + ":";
			lblVersionCurrentCaption.Text = Strings.VersionCurrent + ":";

			btnClose.Text = Strings.Close;
			btnDownload.Text = Strings.DownloadNow;
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private async void btnDownload_Click(object sender, EventArgs e) {
			btnDownload.Enabled = false;
			btnClose.Enabled = false;
			
			String fileName = await _Update.Download(new Progress<int>(p => pgDownload.Value = p));

			btnDownload.Enabled = true;
			btnClose.Enabled = true;

			if (MessageBox.Show(Strings.DownloadCompleteAskRun, Strings.Update, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			ProcessStartInfo process = new ProcessStartInfo();
			process.FileName = fileName;
			Process.Start(process);
		}
	}
}
