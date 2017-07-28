using System;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class RadioButtonItem : InputItem {
		
		public override String Type => Strings.RadioButton;
		
		public RadioButtonItem()
			: base("radio") {
		}

	}
}
