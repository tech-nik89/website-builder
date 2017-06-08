using System;
using System.Windows.Forms;
using WebsiteBuilder.Core.Plugins;
using WebsiteBuilder.UI.Resources;

namespace WebsiteBuilder.UI {
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

			Application.Run(new Forms.MainForm());
		}
	}
}
