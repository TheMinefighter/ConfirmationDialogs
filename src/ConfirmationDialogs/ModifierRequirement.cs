using System.Windows.Input;

namespace ConfirmationDialogs {
	/// <summary>
	/// 
	/// </summary>
	public enum ModifierRequirement : byte {
		/// <summary>
		/// The program doesn´t check that <see cref="ModifierKeys"/> at all
		/// </summary>
		Ignored = 0,
		/// <summary>
		/// The <see cref="ModifierKeys"/> is required for skipping the dialog
		/// </summary>
		Required = 1,
		/// <summary>
		/// When the <see cref="ModifierKeys"/> is pressed the dialog will not be skipped
		/// </summary>
		MustNot = 2
	}
}