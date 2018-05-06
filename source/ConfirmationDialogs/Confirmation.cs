using System.Collections.Generic;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public static class Confirmation {
		/// <summary>
		/// Whether to skip all confirmations
		/// </summary>
		internal static bool Skip = false;
		/// <summary>
		/// Whether to skip all confirmations
		/// </summary>
		internal static bool AllowSkip = true;

		/// <summary>
		/// Specifies the need of the modifier keys to skip a confirmation
		/// </summary>
		internal static readonly Dictionary<ModifierKeys, ModifierRequirement> Requirements = new Dictionary<ModifierKeys, ModifierRequirement> {
			{ModifierKeys.Alt, ModifierRequirement.Ignored},
			{ModifierKeys.Control, ModifierRequirement.Ignored},
			{ModifierKeys.Shift, ModifierRequirement.Required},
			{ModifierKeys.Windows, ModifierRequirement.Ignored}
		};

		/// <summary>
		/// Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The warning text to Display, null for default</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, null for default</param>
		/// <param name="continueBtn">The text to display on the continue button, null for default</param>
		/// <param name="cancleBtn">The text to display on the cancel button</param>
		/// <returns>Whether the user confirmed the action</returns>
		public static bool Confirm(string text = null, string confirmationText = null, string continueBtn=null, string cancleBtn=null) => Confirm(text, confirmationText,continueBtn,cancleBtn, Requirements);

		/// <summary>
		/// Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The warning text to Display, null for default</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, null for default</param>
		/// <param name="continueBtn">The text to display on the continue button, null for default</param>
		/// <param name="cancleBtn">The text to display on the cancel button, null for default</param>
		/// <param name="requirements">Overrides the default skip requiremnts</param>
		/// <returns>Whether the user confirmed the action</returns>
		public static bool Confirm(string text, string confirmationText, string continueBtn , string cancleBtn,
			Dictionary<ModifierKeys, ModifierRequirement> requirements) {
			if (Skip) {
				return true;
			}
			
			if (!AllowSkip) {
				return ConfirmWindow(text, confirmationText, cancleBtn, continueBtn);
			}
			
			ModifierKeys toUse = // ModifierKeys.Shift;
				Keyboard.Modifiers;
			foreach (KeyValuePair<ModifierKeys, ModifierRequirement> modifierRequirement in requirements) {
				switch (modifierRequirement.Value) {
					case ModifierRequirement.Required:
						if ((toUse & modifierRequirement.Key) != modifierRequirement.Key) {
							return ConfirmWindow(text, confirmationText,cancleBtn, continueBtn);
						}

						break;
					case ModifierRequirement.MustNot:
						if ((toUse & modifierRequirement.Key) == modifierRequirement.Key) {
							return ConfirmWindow(text, confirmationText,cancleBtn, continueBtn);
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
		/// <param name="continueBtn"></param>
		/// <param name="cancelBtn"></param>
		/// <returns></returns>
		internal static bool ConfirmWindow(string text, string confirmationText, string continueBtn, string cancelBtn) {
			ConfirmationWindow window = new ConfirmationWindow(new ConfirmationTag(text,
				confirmationText,continueBtn,cancelBtn));
			window.ShowDialog();
			return window.Tag is ConfirmationTag b && b.Confirmed;
		}
	}
}