using System;

namespace ConfirmationDialogs {
	/// <summary>
	/// Reprensents a double <see cref="Nullable"/> Optional type
	/// </summary>
	/// <typeparam name="T">The type of the value stored inside this Container </typeparam>
	public class OptionalContent<T> where T : class {
		private T _value;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="nl"></param>
		/// <returns></returns>
		public static implicit operator OptionalContent<T>(T nl) => new OptionalContent<T> {_value = nl};

		/// <summary>
		/// Creates a new <see cref="OptionalContent{T}"/> with the explicit value <see langword="null"/>
		/// </summary>
		/// <param name="nl">The <see cref="DBNull"/> to use </param>
		/// <returns>An <see cref="OptionalContent{T}"/> with an explicit <see langword="null"/> in it</returns>
		public static implicit operator OptionalContent<T>(DBNull nl) => new OptionalContent<T> {_value = null};
		/// <summary>
		/// Converts an <see cref="OptionalContent{T}"/> to it's value
		/// </summary>
		/// <param name="d">The object, to extract the value from</param>
		/// <returns>The extracted value</returns>
		public static implicit operator T(OptionalContent<T> d) => d._value;
	}
}