using System;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.Core.Compiling;
using WebsiteBuilder.Interface.Icons;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
    public partial class CompilingForm : Form {

		private bool _Initialized = false;

        private readonly Project _Project;

        public CompilingForm(Project project) {
            InitializeComponent();
			LocalizeComponent();
            ApplyIcons();

            _Project = project;
			tsbAutoClose.Checked = _Project.AutoCloseCompileDialog;
			_Initialized = true;
        }

        private void ApplyIcons() {
            if (IconPack.Current == null) {
                return;
            }

            Icon = IconPack.Current.GetIcon(IconPackIcon.Build);
            tsbClose.Image = IconPack.Current.GetImage(IconPackIcon.Close);
            tsbAutoClose.Image = IconPack.Current.GetImage(IconPackIcon.AutoClose);
        }

        public void LocalizeComponent() {
            Text = Strings.BuildStarted;
			tsbAutoClose.Text = Strings.AutoCloseCompilingForm;
            tsbClose.Text = Strings.Close;
        }
        
        public void Push(ProgressEventArgs args) {
            txtLog.AppendText(args.Message);
        }

        public void Done(bool error) {
            tsbClose.Enabled = true;

			if (tsbAutoClose.Checked && !error) {
				Close();
			}
        }

		private void tsbAutoClose_CheckedChanged(object sender, EventArgs e) {
			if (!_Initialized) {
				return;
			}

            _Project.AutoCloseCompileDialog = tsbAutoClose.Checked;
		}

        private void tsbClose_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
