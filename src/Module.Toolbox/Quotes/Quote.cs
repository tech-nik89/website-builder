using Newtonsoft.Json;
using System;

namespace WebsiteStudio.Modules.Toolbox.Quotes {
	
	class Quote : IItem {

		[GenericField(CaptionResourceKey = "Author", Type = GenericFieldType.TextBox, ColumnWidth = 120)]
		public String Author { get; set; }

		[GenericField(CaptionResourceKey = "Text", Type = GenericFieldType.Editor, ColumnWidth = 200)]
		public String Text { get; set; }

		[JsonIgnore]
		public String[] Columns => new String[] { Author, Text };

	}
}
