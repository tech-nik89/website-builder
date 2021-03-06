﻿using System;

namespace WebsiteStudio.Modules.Toolbox {
	class GenericFieldAttribute : Attribute {
		
		public String CaptionResourceKey { get; set; }

		public GenericFieldType Type { get; set; }
		
		public int ColumnWidth { get; set; }

	}
}
