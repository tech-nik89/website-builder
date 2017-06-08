using System;

namespace WebsiteBuilder.Modules.Toolbox {
	class GenericFieldAttribute : Attribute {
		
		public String CaptionResourceKey { get; set; }

		public GenericFieldType Type { get; set; }
		
		public int ColumnWidth { get; set; }

	}
}
