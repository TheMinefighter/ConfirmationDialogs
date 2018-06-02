using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public static class Confirmation {
		[MethodImpl((MethodImplOptions)256)]
		internal static bool ShouldSkip() {
			if (_setting.SkipAlways) {
				return true;
			}

			if (_setting.AllowSkip) {
				ModifierKeys toUse = // ModifierKeys.Shift;
					Keyboard.Modifiers;
				if (KeyAllowsSkip(toUse, ModifierKeys.Alt, _setting.Alt) && KeyAllowsSkip(toUse, ModifierKeys.Control, _setting.Control) &&
				    KeyAllowsSkip(toUse, ModifierKeys.Shift, _setting.Shift) && KeyAllowsSkip(toUse, ModifierKeys.Windows, _setting.Windows)) {
					return true;
				}
			}

			return false;
		}
		[MethodImpl((MethodImplOptions)256)]
		internal static bool ShouldSkip(SkipConfirmationSetting stg) {
			if (stg.SkipAlways) {
				return true;
			}

			if (stg.AllowSkip) {
				ModifierKeys toUse = // ModifierKeys.Shift;
					Keyboard.Modifiers;
				if (KeyAllowsSkip(toUse, ModifierKeys.Alt, _setting.Alt) && KeyAllowsSkip(toUse, ModifierKeys.Control, _setting.Control) &&
				    KeyAllowsSkip(toUse, ModifierKeys.Shift, _setting.Shift) && KeyAllowsSkip(toUse, ModifierKeys.Windows, _setting.Windows)) {
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

		internal static SkipConfirmationSetting _setting;

	

		/// <summary>
		/// Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The warning text to Display, null for default</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, null for default</param>
		/// <param name="continueBtn">The text to display on the continue button, null for default</param>
		/// <param name="cancleBtn">The text to display on the cancel button, null for default</param>
		/// <param name="requirements">Overrides the default skip requiremnts</param>
		/// <returns>Whether the user confirmed the action</returns>
		public static bool Confirm(string text = null, string confirmationText = null, string continueBtn = null, string cancleBtn = null)  {
			if (ShouldSkip()) {
				return true;
			}

			return ConfirmWindow(text, confirmationText, cancleBtn, continueBtn);
		}

		/// <summary>
		/// Runs the internal confirmation dialog
		/// </summary>
		/// <param name="text">The text to display</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action</param>
		/// <param name="continueBtn"></param>
		/// <param name="cancelBtn"></param>
		/// <returns></returns>
		internal static bool ConfirmWindow(string text, string confirmationText, string continueBtn, string cancelBtn,bool fast=false) {
			ConfirmationWindow window = new ConfirmationWindow(new ConfirmationTag(text,
				confirmationText, continueBtn, cancelBtn));
			window.ShowDialog();
			return window.Tag is ConfirmationTag b && b.Confirmed;
		}
	}
}