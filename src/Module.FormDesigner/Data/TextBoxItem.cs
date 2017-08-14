using System;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner.Data {
	class TextBoxItem : InputItem {
		
		public override String Type => Strings.TextBox;
		
		public TextBoxItem()
			: base("text") {
		}

	}
}
