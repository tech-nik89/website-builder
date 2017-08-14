using System;
using System.Windows.Forms;
using WebsiteStudio.Core.Plugins;
using WebsiteStudio.UI.Forms;
using WebsiteStudio.UI.Resources;

namespace WebsiteStudio.UI {
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			PluginManager.Init();
			IconPack.LoadDefault();

			Application.Run(new MainForm());
		}
	}
}
