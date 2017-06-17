using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WebsiteBuilder.Core.Plugins;

namespace WebsiteBuilder.UI.Plugins {
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
			control.Items.Clear();

			foreach (var item in items) {
				control.Items.Add(item.Value);
			}
		}

		private static void SelectPlugin(ComboBox control, Type[] types, Type type) {
			int index = type != null ? Array.IndexOf(types, type) : -1;
			if (index == -1 && control.Items.Count > 0) {
				index = 0;
			}
			control.SelectedIndex = index;
		}

		private static Type GetPlugin(ComboBox control, Type[] types) {
			if (control.SelectedIndex == -1) {
				return null;
			}

			return types[control.SelectedIndex];
		}

		#endregion
	}
}
