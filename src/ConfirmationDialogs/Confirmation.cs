using System;
using System.Windows.Input;
using System.Windows.Media;
//using Functional.Option;

namespace ConfirmationDialogs {
	/// <summary>
	/// A <see langword="class"/> providing dialogs, for the user to confirm actions
	/// </summary>
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

		internal static bool KeyAllowsSkip(ModifierKeys toUse, ModifierKeys expectedModifierKey, ModifierRequirement modifierRequirement) {
			switch (modifierRequirement) {
				case ModifierRequirement.Ignored:
					break;
				case ModifierRequirement.Required:
					if ((toUse & expectedModifierKey) != expectedModifierKey) {
						return false;
					}

					break;
				case ModifierRequirement.MustNot:
					if ((toUse & expectedModifierKey) == expectedModifierKey) {
						return false;
					}

					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return true;
		}

		/// <summary>
		/// Starts a confirmation dialog
		/// </summary>
		/// <param name="windowOverride">The <see cref="ConfirmationWindowConfiguration"/> to use instead of the default</param>
		/// <param name="skipOverride">The <see cref="SkipConfirmationConfiguration"/> to use instead of the default</param>
		/// <returns>Whther the user confirmed that he is is willing to continue</returns>
		public static bool
			// ReSharper disable once MethodOverloadWithOptionalParameter
			Confirm(ConfirmationWindowConfiguration windowOverride = null, SkipConfirmationConfiguration skipOverride = null) =>
			ShouldSkip(skipOverride ?? SkipConfiguration) || (windowOverride ?? WindowConfiguration).Confirm();

		/// <summary>
		///  Starts a simple confirmation dialog
		/// </summary>
		/// <param name="descripionText">The warning text to display, <see langword="null"/> for default</param>
		/// <param name="title">The content of the title bar of the confirmation window, <see langword="null"/> for default</param>
		/// <param name="confirmByRetyping">Whether the user has to retype a phrase, <see langword="null"/> for default</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, <see langword="null"/> for default</param>
		/// <param name="confirmButtonText">The text to display on the continue button, <see langword="null"/> for default</param>
		/// <param name="cancelButtonText">The text to display on the cancel button, <see langword="null"/> for default</param>

		/// <returns>Whther the user confirmed that he is is willing to continue</returns>
		// ReSharper disable once MethodOverloadWithOptionalParameter
		/*		/// <param name="icon">The Icon of the window, use Option.None for default and <see cref="Option"/>&lt;<see cref="ImageSource"/>&gt;.<see cref="Option.Some"/>(<see langword="null"/>) to override it not to change the icon </param> */
		public static bool Confirm(string descripionText = null, string title = null, bool? confirmByRetyping = null, string confirmationText = null,
			string confirmButtonText = null, string cancelButtonText = null
			//, Option<ImageSource> icon = default(Option<ImageSource>)
			) =>
			ShouldSkip(SkipConfiguration) ||
			WindowConfiguration.CreateFromDefaults(descripionText, title, confirmByRetyping, confirmationText, confirmButtonText, cancelButtonText
				//	, icon
					)
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
		/// <summary>
		/// Starts a basic confirmation dialog
		/// </summary>
		/// <returns>Whther the user confirmed that he is is willing to continue</returns>
		public static bool Confirm() => ShouldSkip(SkipConfiguration) || WindowConfiguration.Confirm();
	}
}