using System;

namespace WebsiteBuilder.Modules.Toolbox.Accordion {
	public class AccordionItem : IItem {

		[GenericField(CaptionResourceKey = "Title", Type = GenericFieldType.TextBox, ColumnWidth = 120)]
		public String Title { get; set; }

		[GenericField(CaptionResourceKey = "Text", Type = GenericFieldType.Editor)]
		public String Text { get; set; }

		public String[] Columns => new String[] { Title };

	}
}
