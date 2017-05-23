using System;

namespace WebsiteBuilder.Modules.Toolbox.Timeline {
    class TimelineItem : IItem {

        [GenericField(CaptionResourceKey = "Time", Type = GenericFieldType.TextBox, ColumnWidth = 160)]
        public String Time { get; set; }

        [GenericField(CaptionResourceKey = "Title", Type = GenericFieldType.TextBox, ColumnWidth = 160)]
        public String Title { get; set; }

        [GenericField(CaptionResourceKey = "Text", Type = GenericFieldType.Editor)]
        public String Text { get; set; }

        public String[] Columns => new String[] { Time, Title };

    }
}
