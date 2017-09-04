using System;
using System.Text.RegularExpressions;

namespace WebsiteStudio.Core.Compiling {
	public class CompilerConstants {
		
		private const String GuidRegexPattern = @"[\d\w\-_]{1,36}";
		
		public static readonly Regex MediaLinkRegex = new Regex(String.Format(@"@Media\(({0})\)", GuidRegexPattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public const String MediaLinkFormat = "@Media({0})";

		public static readonly Regex PageLinkRegex = new Regex(String.Format(@"@Page\(({0})\)", GuidRegexPattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public const String PageLinkFormat = "@Page({0})";

	}
}
