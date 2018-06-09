using System;
using System.Windows.Input;
using System.Windows.Media;
using Optional;

namespace ConfirmationDialogs {
	public static class Confirmation {
		internal static SkipConfirmationConfiguration SkipConfiguration = SkipConfirmationConfiguration.Presets.ShiftForSKip;
		internal static ConfirmationWindowConfiguration WindowConfiguration = new ConfirmationWindowConfiguration();

		internal static bool ShouldSkip(SkipConfirmationConfiguration stg) {
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
		/// </summary>
		/// <param name="windowOverride"></param>
		/// <param name="skipOverride"></param>
		/// <returns></returns>
		public static bool
			// ReSharper disable once MethodOverloadWithOptionalParameter
			Confirm(ConfirmationWindowConfiguration windowOverride = null, SkipConfirmationConfiguration skipOverride = null) =>
			ShouldSkip(skipOverride ?? SkipConfiguration) || (windowOverride ?? WindowConfiguration).Confirm();

		/// <summary>
		///  Starts a confirmation dialog
		/// </summary>
		/// <param name="text">The warning text to Display, null for default</param>
		/// <param name="title"></param>
		/// <param name="fast"></param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, null for default</param>
		/// <param name="continueBtn">The text to display on the continue button, null for default</param>
		/// <param name="cancleBtn">The text to display on the cancel button, null for default</param>
		/// <param name="configurationOverride"></param>
		/// <returns>Whether the user confirmed the action</returns>
		// ReSharper disable once MethodOverloadWithOptionalParameter
		public static bool Confirm(string text = null, string title = null, bool? fast = null, string confirmationText = null,
			string continueBtn = null, string cancleBtn = null) =>
			ShouldSkip(SkipConfiguration) ||
			WindowConfiguration.CreateFromDefaults(text, title, fast, confirmationText, continueBtn, cancleBtn, default(Option<ImageSource>))
				.Confirm();

//		/// <summary>
//		///  Runs the internal confirmation dialog
//		/// </summary>
//		/// <param name="text">The text to display</param>
//		/// <param name="confirmationText">The text the user has to type to confirm the Action</param>
//		/// <param name="continueBtn"></param>
//		/// <param name="cancelBtn"></param>
//		/// <returns></returns>
//		internal static bool ConfirmWindow(string text, string confirmationText, string continueBtn, string cancelBtn, bool fast = false) {
//			if (!fast) {
//				ConfirmationWindow window = new ConfirmationWindow(new ConfirmationTag(text,
//					confirmationText, continueBtn, cancelBtn));
//				window.ShowDialog();
//				return window.Tag is ConfirmationTag b && b.Confirmed;
//			}
//			else {
//				FastConfirmationWindow window = new FastConfirmationWindow(new ConfirmationTag(text,
//					confirmationText, continueBtn, cancelBtn));
//				window.ShowDialog();
//				return window.Tag is ConfirmationTag b && b.Confirmed;
//			}
//		}
		public static bool Confirm() => ShouldSkip(SkipConfiguration) || WindowConfiguration.Confirm();
	}
}