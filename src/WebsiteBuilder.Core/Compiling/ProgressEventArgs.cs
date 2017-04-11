using System;

namespace WebsiteBuilder.Core.Compiling {
    public class ProgressEventArgs : EventArgs {

        public int Percentage { get; private set; }
        
        public String Message { get; private set; }

        public ProgressEventArgs(int percentage, String message) {
            Percentage = percentage;
            Message = message;
        }
    }
    
}
