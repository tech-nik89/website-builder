using System;

namespace WebsiteBuilder.Core.Compiling {
	public class CompilerProgressReport : EventArgs {

		public int Percentage { get; private set; }
		
		public String Message { get; private set; }

		public CompilerProgressReport(int percentage, String message) {
			Percentage = percentage;
			Message = message;
		}
	}
	
}
