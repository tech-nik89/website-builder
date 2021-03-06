﻿using System;
using System.Collections.Generic;
using WebsiteStudio.Interface.Compiling;

namespace WebsiteStudio.Core.Compiling {
	abstract class CompilerStep {

		public abstract void Run();

		public String Output { get; protected set; }

		public IEnumerable<CompilerMessage> Messages => _Messages;

		protected readonly List<CompilerMessage> _Messages;

		public CompilerStep() : this(String.Empty) {
		}

		public CompilerStep(String output) {
			_Messages = new List<CompilerMessage>();
			Output = output;
		}

	}
}
