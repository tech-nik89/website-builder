using System;

namespace WebsiteStudio.Core.Compiling {
	public class CompilerMessage {

		public CompilerMessageType MessageType { get; internal set; }

		public String Message { get; internal set; }

		public CompilerMessage(Exception ex) {
			MessageType = CompilerMessageType.Error;
			Message = ex.Message;
		}

	}
}
