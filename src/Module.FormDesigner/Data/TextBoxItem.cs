using System;
using WebsiteBuilder.Modules.FormDesigner.Localization;

namespace WebsiteBuilder.Modules.FormDesigner.Data {
	class TextBoxItem : InputItem {
		
		public override String Type => Strings.TextBox;
		
		public TextBoxItem()
			: base("text") {
		}

	}
}
