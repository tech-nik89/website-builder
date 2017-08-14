using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteStudio.Core.Plugins;

namespace WebsiteStudio.UI.Plugins {
	public static class PluginExtensions {

		#region Publishing

		public static void FillWithPublishPlugins(this ComboBox control) {
			FillWithPlugins(control, PluginManager.Publishers);
		}

		public static void SelectPublishPlugin(this ComboBox control, Type editorType) {
			SelectPlugin(control, PluginManager.PublishTypes, editorType);
		}

		public static Type GetPublishPlugin(this ComboBox control) {
			return GetPlugin(control, PluginManager.PublishTypes);
		}

		#endregion

		#region Webservers
		
		public static void FillWithWebserverPlugins(this ComboBox control, Boolean includeNoneSelection) {
			FillWithPlugins(control, PluginManager.Webservers, includeNoneSelection);
		}
		
		public static void SelectWebserverPlugin(this ComboBox control, Type editorType) {
			SelectPlugin(control, PluginManager.WebserverTypes, editorType);
		}
		
		public static Type GetWebserverPlugin(this ComboBox control) {
			return GetPlugin(control, PluginManager.WebserverTypes);
		}

		#endregion

		#region Editors

		public static void FillWithEditorPlugins(this ComboBox control) {
			FillWithPlugins(control, PluginManager.Editors);
		}

		public static void SelectEditorPlugin(this ComboBox control, Type editorType) {
			SelectPlugin(control, PluginManager.EditorTypes, editorType);
		}

		public static Type GetEditorPlugin(this ComboBox control) {
			return GetPlugin(control, PluginManager.EditorTypes);
		}

		#endregion

		#region Modules

		public static void FillWithModulePlugins(this ComboBox control) {
			FillWithPlugins(control, PluginManager.Modules);
		}

		public static void SelectModulePlugin(this ComboBox control, Type moduleType) {
			SelectPlugin(control, PluginManager.ModuleTypes, moduleType);
		}

		public static Type GetModulePlugin(this ComboBox control) {
			return GetPlugin(control, PluginManager.ModuleTypes);
		}

		#endregion

		#region Generic

		private static void FillWithPlugins(ComboBox control, Dictionary<Type, String> items) {
			FillWithPlugins(control, items, false);
		}

		private static void FillWithPlugins(ComboBox control, Dictionary<Type, String> items, Boolean includeNoneSelection) {
			control.Items.Clear();

			if (items == null) {
				return;
			}

			if (includeNoneSelection) {
				control.Items.Add("-");
			}

			foreach (var item in items) {
				control.Items.Add(item.Value);
			}
		}
		
		private static void SelectPlugin(ComboBox control, Type[] types, Type type) {
			if (types == null) {
				return;
			}

			Boolean includeNoneSelection = control.Items.Count == types.Length + 1;
			int index = type != null ? Array.IndexOf(types, type) : -1;

			if (index == -1 && control.Items.Count > 0) {
				index = 0;
			}
			else if (includeNoneSelection) {
				index++;
			}

			control.SelectedIndex = index;
		}
		
		private static Type GetPlugin(ComboBox control, Type[] types) {
			if (types == null) {
				return null;
			}

			int index = control.SelectedIndex;
			Boolean includeNoneSelection = control.Items.Count == types.Length + 1;

			if (index == -1) {
				return null;
			}
			else if (index == 0 && includeNoneSelection) {
				return null;
			}
			else if (includeNoneSelection) {
				index--;
			}

			return types[index];
		}

		#endregion

	}
}
