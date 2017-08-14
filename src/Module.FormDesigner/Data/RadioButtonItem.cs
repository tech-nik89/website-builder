using System;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class RadioButtonItem : InputItem {
		
		public override String Type => Strings.RadioButton;

		protected override string Value => Label;

		public RadioButtonItem()
			: base("radio") {
		}

	}
}
