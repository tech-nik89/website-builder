using System;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class CheckBoxItem : InputItem {
		
		public override String Type => Strings.CheckBox;

		public CheckBoxItem()
			: base("checkbox") {

			Value = true.ToString();
		}

	}
}
