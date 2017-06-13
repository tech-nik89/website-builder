namespace WebsiteBuilder.Core.Validation {
	public abstract class ValidatorBase<T> {

		private readonly T _Object;

		protected T Object => _Object;

		public abstract bool Valid { get; }

		public ValidatorBase(T obj) {
			_Object = obj;
		}

	}
}
