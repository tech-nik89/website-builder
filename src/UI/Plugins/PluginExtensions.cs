using System;
using System.Windows.Forms;
using WebsiteBuilder.Core.Plugins;

namespace WebsiteBuilder.UI.Plugins {
	public static class PluginExtensions {

		public static void FillWithEditorPlugins(this ComboBox control) {
			control.Items.Clear();

			foreach(var item in PluginManager.Editors) {
				control.Items.Add(item.Value);
			}
		}

		public static void SelectEditorPlugin(this ComboBox control, Type editorType) {
			int index = Array.IndexOf(PluginManager.EditorTypes, editorType);
			control.SelectedIndex = index > -1 ? index : 0;
		}

		public static Type GetEditorPlugin(this ComboBox control) {
			if (control.SelectedIndex == -1) {
				return null;
			}

			return PluginManager.EditorTypes[control.SelectedIndex];
		}

		public static void FillWithModulePlugins(this ComboBox control) {
			control.Items.Clear();

			foreach (var item in PluginManager.Modules) {
				control.Items.Add(item.Value);
			}
		}

		public static void SelectModulePlugin(this ComboBox control, Type moduleType) {
			int index = Array.IndexOf(PluginManager.ModuleTypes, moduleType);
			control.SelectedIndex = index > -1 ? index : 0;
		}

		public static Type GetModulePlugin(this ComboBox control) {
			if (control.SelectedIndex == -1) {
				return null;
			}

			return PluginManager.ModuleTypes[control.SelectedIndex];
		}
	}
}
