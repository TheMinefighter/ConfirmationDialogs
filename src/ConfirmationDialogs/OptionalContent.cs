using System;

namespace ConfirmationDialogs {
	public class OptionalContent<T> where T : class {
		private T _value;

		public static implicit operator OptionalContent<T>(T nl) => new OptionalContent<T> {_value = nl};

		public static implicit operator OptionalContent<T>(DBNull nl) => new OptionalContent<T> {_value = null};
		public static implicit operator T(OptionalContent<T> d) => d._value;
	}
}