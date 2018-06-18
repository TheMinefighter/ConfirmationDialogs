using System;

namespace ConfirmationDialogs {
	/// <summary>
	/// Represents a double <see cref="Nullable"/> Optional type
	/// </summary>
	/// <typeparam name="T">The type of the value stored inside this Container </typeparam>
	public class OptionalContent<T> where T : class {
		private T _value;

		/// <summary>
		/// Creates a new <see cref="OptionalContent{T}"/> from a given value
		/// </summary>
		/// <param name="val">The value to use for the container</param>
		/// <returns>The new Container containing the given value</returns>
		public static implicit operator OptionalContent<T>(T val) => new OptionalContent<T> {_value = val};

		/// <summary>
		/// Creates a new <see cref="OptionalContent{T}"/> with the explicit value <see langword="null"/>
		/// </summary>
		/// <param name="nl">The <see cref="DBNull"/> to use, can be obtained from <see cref="DBNull"/>.<see cref="DBNull.Value"/> </param>
		/// <returns>An <see cref="OptionalContent{T}"/> with an explicit <see langword="null"/> in it</returns>
		// ReSharper disable once UnusedParameter.Global
		public static implicit operator OptionalContent<T>(DBNull nl) => new OptionalContent<T> {_value = null};
		/// <summary>
		/// Converts an <see cref="OptionalContent{T}"/> to it's value
		/// </summary>
		/// <param name="d">The object, to extract the value from</param>
		/// <returns>The extracted value</returns>
		public static implicit operator T(OptionalContent<T> d) => d._value;
	}
}