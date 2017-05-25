using Newtonsoft.Json;
using System;

namespace WebsiteBuilder.Modules.Table {
    class TableData {

        public String ColumnDelimiter { get; set; }

        public HeaderPosition HeaderPosition { get; set; }

        public String Data { get; set; }

        public TableData() {
            ColumnDelimiter = "|";
            HeaderPosition = HeaderPosition.NoHeader;
            Data = "";
        }

        public static String Serialize(TableData data) {
            return JsonConvert.SerializeObject(data);
        }
        
        public static TableData Derserialize(String str) {
            TableData data = new TableData();

            if (String.IsNullOrWhiteSpace(str)) {
                return data;
            }

            try {
                data = JsonConvert.DeserializeObject<TableData>(str);
            }
            catch {
            }

            return data;
        }

    }
}
