using System.Collections.Generic;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public static class Confirmation {
		/// <summary>
		/// Whether to skip all confirmations
		/// </summary>
		internal static bool Skip = false;

		/// <summary>
		/// Specifies the need of the modifier keys to skip a confirmation
		/// </summary>
		internal static readonly Dictionary<ModifierKeys, ModifierRequirement> Requirements = new Dictionary<ModifierKeys, ModifierRequirement> {
			{ModifierKeys.Alt, ModifierRequirement.Ignored},
			{ModifierKeys.Control, ModifierRequirement.Required},
			{ModifierKeys.Shift, ModifierRequirement.Required},
			{ModifierKeys.Windows, ModifierRequirement.Ignored}
		};

		/// <summary>
		/// Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The text to Display</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action</param>
		/// <param name="requirements">Overrides the default skip requiremnts</param>
		/// <returns>Whether the user confirmed the action</returns>
		public static bool Confirm(string text = null, string confirmationText = null,
			Dictionary<ModifierKeys, ModifierRequirement> requirements = null) {
			if (Skip) {
				return true;
			}

			ModifierKeys toUse = Keyboard.Modifiers;
			foreach (KeyValuePair<ModifierKeys, ModifierRequirement> modifierRequirement in requirements ?? Requirements) {
				switch (modifierRequirement.Value) {
					case ModifierRequirement.Required:
						if ((toUse & modifierRequirement.Key) != modifierRequirement.Key) {
							return InternalConfirm(text, confirmationText);
						}

						break;
					case ModifierRequirement.MustNot:
						if ((toUse & modifierRequirement.Key) == modifierRequirement.Key) {
							return InternalConfirm(text, confirmationText);
						}

						break;
				}
			}

			return true;
		}

		/// <summary>
		/// Runs the internal confirmation dialog
		/// </summary>
		/// <param name="text">The text to display</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action</param>
		/// <returns></returns>
		internal static bool InternalConfirm(string text = null, string confirmationText = null) {
			ConfirmationWindow window = new ConfirmationWindow(new ConfirmationTag(text ?? ConfirmationStrings.DefaultText,
				confirmationText ?? ConfirmationStrings.DefaultConfirm));
			window.ShowDialog();
			return window.Tag is ConfirmationTag b && b.Confirmed;
		}
	}
}