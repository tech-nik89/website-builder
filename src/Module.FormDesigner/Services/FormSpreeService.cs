using System;

namespace WebsiteBuilder.Modules.FormDesigner.Services {
	class FormSpreeService : Service {

		public FormSpreeService(FormData data)
			: base(data) {
		}

		public override String GetUrl() {
			return String.Format("https://formspree.io/{0}", Data.TargetMailAddress);
		}

	}
}
