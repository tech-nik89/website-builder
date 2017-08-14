using System;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class CheckBoxItem : InputItem {
		
		public override String Type => Strings.CheckBox;

		protected override string Value => true.ToString().ToLower();

		public CheckBoxItem()
			: base("checkbox") {
		}

	}
}
