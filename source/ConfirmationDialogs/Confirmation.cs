using System;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public static class Confirmation {
		internal static ConfirmationConfiguration _configuration;

		internal static bool ShouldSkip(ConfirmationConfiguration stg) {
			if (stg.SkipAlways) {
				return true;
			}

			if (stg.AllowSkip) {
				ModifierKeys toUse = // ModifierKeys.Shift;
					Keyboard.Modifiers;
				if (KeyAllowsSkip(toUse, ModifierKeys.Alt, stg.Alt) && KeyAllowsSkip(toUse, ModifierKeys.Control, stg.Control) &&
				    KeyAllowsSkip(toUse, ModifierKeys.Shift, stg.Shift) && KeyAllowsSkip(toUse, ModifierKeys.Windows, stg.Windows)) {
					return true;
				}
			}

			return false;
		}

		private static bool KeyAllowsSkip(ModifierKeys toUse, ModifierKeys modifierKeys, ModifierRequirement modifierRequirement) {
			switch (modifierRequirement) {
				case ModifierRequirement.Ignored:
					break;
				case ModifierRequirement.Required:
					if ((toUse & modifierKeys) != modifierKeys) {
						return false;
					}

					break;
				case ModifierRequirement.MustNot:
					if ((toUse & modifierKeys) == modifierKeys) {
						return false;
					}

					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return true;
		}


		/// <summary>
		///  Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The warning text to Display, null for default</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, null for default</param>
		/// <param name="continueBtn">The text to display on the continue button, null for default</param>
		/// <param name="cancleBtn">The text to display on the cancel button, null for default</param>
		/// <param name="fast"></param>
		/// <param name="allowSkip"></param>
		/// <param name="configurationOverride"></param>
		/// <returns>Whether the user confirmed the action</returns>
		public static bool Confirm(string text = null, string confirmationText = null, string continueBtn = null,
			string cancleBtn = null, bool? fast = null, bool? allowSkip = null, ConfirmationConfiguration configurationOverride = null) {
			if (configurationOverride == null) {
				throw new ArgumentNullException(nameof(configurationOverride));
			}

			ConfirmationConfiguration localConfiguration = configurationOverride ?? _configuration;
			if (ShouldSkip((ConfirmationConfiguration) _configuration.Clone())) {
				return true;
			}

			return ConfirmWindow(text, confirmationText, cancleBtn, continueBtn, fast);
		}

		/// <summary>
		///  Runs the internal confirmation dialog
		/// </summary>
		/// <param name="text">The text to display</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action</param>
		/// <param name="continueBtn"></param>
		/// <param name="cancelBtn"></param>
		/// <returns></returns>
		internal static bool ConfirmWindow(string text, string confirmationText, string continueBtn, string cancelBtn, bool fast = false) {
			if (!fast) {
				ConfirmationWindow window = new ConfirmationWindow(new ConfirmationTag(text,
					confirmationText, continueBtn, cancelBtn));
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
			else {
				FastConfirmationWindow window = new FastConfirmationWindow(new ConfirmationTag(text,
					confirmationText, continueBtn, cancelBtn));
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
		}
	}
}