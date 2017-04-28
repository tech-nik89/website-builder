using System;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using WebsiteBuilder.Core.Validation;
using WebsiteBuilder.UI.Localization;

namespace WebsiteBuilder.UI.Resources {
    class ValidationHelper<T> {
        
        private static readonly ResourceManager _ResourceManager = new ResourceManager(typeof(ValidationStrings));

        private readonly ValidatorBase<T> _Validator;

        private readonly String _BaseTypeName;

        public bool Valid => _Validator.Valid;

        public ValidationHelper(ValidatorBase<T> validator) {
            _Validator = validator;
            _BaseTypeName = typeof(T).Name;
        }

        public void ShowMessage() {
            if (_Validator.Valid) {
                return;
            }

            StringBuilder builder = new StringBuilder();
            builder.Append(GetGeneralMessage());
            builder.AppendLine();

            PropertyInfo[] properties = _Validator.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo property in properties) {
                if (property.Name == "Valid" || property.PropertyType != typeof(bool)) {
                    continue;
                }

                if ((bool)property.GetValue(_Validator) == false) {
                    String message = GetPropertyMessage(property.Name);
                    if (!String.IsNullOrWhiteSpace(message)) {
                        builder.AppendLine();
                        builder.Append("- ");
                        builder.Append(message);
                    }
                }
            }

            MessageBox.Show(builder.ToString(), Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private String GetPropertyMessage(String propertyName) {
            return _ResourceManager.GetString(String.Concat(_BaseTypeName, propertyName));
        }

        private String GetGeneralMessage() {
            return _ResourceManager.GetString(_BaseTypeName);
        }
    }
}
