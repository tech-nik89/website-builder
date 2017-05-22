using System;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using WebsiteBuilder.Interface.Plugins;

namespace WebsiteBuilder.Modules.Toolbox {
    class GenericField<T> {

        private readonly GenericFieldAttribute _Attribute;

        private readonly PropertyInfo _Property;

        private readonly IEditor _Editor;

        public String Text => _ResourceManager.GetString(_Attribute.CaptionResourceKey);

        public Boolean ShowColumn => ColumnWidth > 0;

        public int ColumnWidth => _Attribute.ColumnWidth;

        private static readonly ResourceManager _ResourceManager = new ResourceManager("WebsiteBuilder.Modules.Toolbox.Localization.Strings", typeof(GenericField<T>).Assembly);
        
        private GenericField(PropertyInfo property, IEditor editor) {
            _Property = property;
            _Editor = editor;
            _Attribute = _Property.GetCustomAttribute<GenericFieldAttribute>();
        }

        public Control CreateControl() {
            if (_Editor == null) {
                return null;
            }

            switch (_Attribute.Type) {
                default:
                case GenericFieldType.TextBox:
                    return new TextBox();
                case GenericFieldType.CheckBox:
                    return new CheckBox();
                case GenericFieldType.NumericTextBox:
                    return new NumericUpDown();
                case GenericFieldType.Editor:
                    Control editor = (Control)_Editor.GetUserInterface();
                    editor.Height = 170;
                    return editor;
            }
        }

        public void GetValue(T instance, Control control) {
            Object value = _Property.GetValue(instance);

            switch(_Attribute.Type) {
                case GenericFieldType.TextBox:
                    ((TextBox)control).Text = Convert.ToString(value);
                    break;
                case GenericFieldType.CheckBox:
                    ((CheckBox)control).Checked = Convert.ToBoolean(value);
                    break;
                case GenericFieldType.NumericTextBox:
                    ((NumericUpDown)control).Value = Convert.ToDecimal(value);
                    break;
                case GenericFieldType.Editor:
                    ((IUserInterface)control).Data = Convert.ToString(value);
                    break;
            }
        }

        public void SetValue(T instance, Control control) {
            Object value = null;

            switch (_Attribute.Type) {
                case GenericFieldType.TextBox:
                    value = ((TextBox)control).Text;
                    break;
                case GenericFieldType.CheckBox:
                    value = ((CheckBox)control).Checked;
                    break;
                case GenericFieldType.NumericTextBox:
                    value = ((NumericUpDown)control).Value;
                    break;
                case GenericFieldType.Editor:
                    value = ((IUserInterface)control).Data;
                    break;
            }

            _Property.SetValue(instance, value);
        }

        public static GenericField<T>[] GetItemFields(IEditor editor) {
            return typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => Attribute.IsDefined(p, typeof(GenericFieldAttribute), false))
                .Select(p => new GenericField<T>(p, editor))
                .ToArray()
                ;
        }
    }
}
