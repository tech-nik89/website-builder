using System;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class RadioButtonItem : InputItem {
		
		public override String Type => Strings.RadioButton;

		protected override string Value => Label;

		public RadioButtonItem()
			: base("radio") {
		}

	}
}
