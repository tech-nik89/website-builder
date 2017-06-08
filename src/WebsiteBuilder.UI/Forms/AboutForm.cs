using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using WebsiteBuilder.Core;
using WebsiteBuilder.UI.Localization;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI.Forms {
	partial class AboutForm : Form {
		public AboutForm() {
			InitializeComponent();
			ApplyIcons();

			Text = String.Format(Strings.AboutFormat, AssemblyProduct);
			lblProductName.Text = AssemblyProduct;
			lblVersion.Text = String.Format(Strings.VersionFormat, AssemblyVersion);
			lblCopyright.Text = AssemblyCopyright;
			lblCompanyName.Text = String.Format(Strings.WrittenByFormat, AssemblyCompany);
			txtLicenses.Text = StaticResources.ThirdpartyLicenses;

			llbProject.Text = StaticResources.ProjectURL;
		}

		private void ApplyIcons() {
			if (IconPack.Current == null) {
				return;
			}

			Icon = IconPack.Current.GetIcon(Interface.Icons.IconPackIcon.About);
		}

		#region Assembly Attribute Accessors

		public String AssemblyTitle {
			get {
				Object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "") {
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public String AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		public String AssemblyDescription {
			get {
				Object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public String AssemblyProduct {
			get {
				Object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public String AssemblyCopyright {
			get {
				Object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public String AssemblyCompany {
			get {
				Object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		private void llbProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Process.Start(llbProject.Text);
		}
	}
}
