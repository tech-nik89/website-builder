using System;

namespace WebsiteStudio.Interface.Compiling {
	public class CompilerMessage : IEquatable<CompilerMessage> {

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

		public override bool Equals(object obj) {
			CompilerMessage other = (CompilerMessage)obj;
			return Equals(other);
		}

		public bool Equals(CompilerMessage other) {
			return other.MessageType == MessageType && other.Message == Message;
		}

		public override int GetHashCode() {
			return Message.GetHashCode() + MessageType.GetHashCode();
		}
	}
}
