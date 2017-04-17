using dotless.Core;
using dotless.Core.configuration;
using dotless.Core.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBuilder.Interface.Compiling;

namespace WebsiteBuilder.Core.Tools {
    class DotLessCompiler : ICompiler {
        
		private static readonly DotlessConfiguration _Config = new DotlessConfiguration() {
			MinifyOutput = false,
			Web = false,
			CacheEnabled = false,
			SessionMode = DotlessSessionStateMode.Disabled,
            Logger = typeof(DotLessCompilerLogger),
			LogLevel = LogLevel.Warn
		};

        public String Compile(String source) {
            String[] error;
            String css = Compile(source, out error);

            if (error.Length > 0) {
                StringBuilder message = new StringBuilder();
                message.AppendLine("Error parsing less file.");

                foreach (String str in error) {
                    message.AppendLine(str);
                }

                throw new Exception(message.ToString());
            }

            return css;
        }
        
        public String Compile(String source, out String[] error) {
            lock (_Config) {
                DotLessCompilerLogger.Clear();
                String css = LessWeb.Parse(source, _Config);
                error = DotLessCompilerLogger.Messages;
                return css;
            }
		}

	}

    class DotLessCompilerLogger : ILogger {

        private static readonly List<String> _Messages = new List<String>();

        public static String[] Messages => _Messages.ToArray();

        public static void Clear() {
            _Messages.Clear();
        }

        public void Debug(string message) {
            _Messages.Add(message);
        }

        public void Debug(string message, params object[] args) {
            _Messages.Add(String.Format(message, args));
        }

        public void Error(string message) {
            _Messages.Add(message);
        }

        public void Error(string message, params object[] args) {
            _Messages.Add(String.Format(message, args));
        }

        public void Info(string message) {
            _Messages.Add(message);
        }

        public void Info(string message, params object[] args) {
            _Messages.Add(String.Format(message, args));
        }

        public void Log(LogLevel level, string message) {
            _Messages.Add(message);
        }

        public void Warn(string message) {
            _Messages.Add(message);
        }

        public void Warn(string message, params object[] args) {
            _Messages.Add(String.Format(message, args));
        }
    }
}
