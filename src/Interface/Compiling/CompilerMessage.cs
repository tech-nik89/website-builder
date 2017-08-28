using System;

namespace WebsiteStudio.Interface.Compiling {
	public class CompilerMessage {

		public CompilerMessageType MessageType { get; private set; }

		public String Message { get; private set; }

		public CompilerMessage(Exception ex) {
			MessageType = CompilerMessageType.Error;
			Message = ex.Message;
		}

		public CompilerMessage(String message, CompilerMessageType type) {
			Message = message;
			MessageType = type;
		}

	}
}
