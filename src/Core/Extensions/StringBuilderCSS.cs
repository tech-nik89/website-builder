using System;
using System.Text;

namespace WebsiteStudio.Core.Extensions {
	public static class StringBuilderCSS {

		public static void AppendProperty(this StringBuilder sb, String property, String valueFormat, params object[] values) {
			AppendProperty(sb, property, String.Format(valueFormat, values));
		}

		public static void AppendProperty(this StringBuilder sb, String property, String value) {
			sb.Append(property);
			sb.Append(":");
			sb.Append(value);
			sb.Append(";");
		}

		public static void StartSelector(this StringBuilder sb, String selectorFormat, params object[] values) {
			StartSelector(sb, String.Format(selectorFormat, values));
		}

		public static void StartSelector(this StringBuilder sb, String selector) {
			sb.Append(selector);
			sb.Append("{");
		}

		public static void EndSelector(this StringBuilder sb) {
			sb.AppendLine("}");
		}

	}
}
