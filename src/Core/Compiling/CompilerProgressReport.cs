using System;

namespace WebsiteStudio.Core.Compiling {
	public class CompilerProgressReport : EventArgs {

		public int Percentage { get; private set; }
		
		public String Message { get; private set; }

		public CompilerProgressReport(int percentage, String message, String[] args) {
			Percentage = percentage;
			Message = String.Format(message, args);
		}
	}
	
}
