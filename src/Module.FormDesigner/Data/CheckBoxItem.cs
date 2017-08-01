using System;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class CheckBoxItem : InputItem {
		
		public override String Type => Strings.CheckBox;

		protected override string Value => true.ToString().ToLower();

		public CheckBoxItem()
			: base("checkbox") {
		}

	}
}
