using System.Windows.Input;
using System.Windows.Media;
using Functional.Option;
using JetBrains.Annotations;

namespace ConfirmationDialogs {
	public static class ConfirmationSettings {
		/// <summary>
		/// 
		/// </summary>
		[NotNull]
		public static SkipConfirmationConfiguration SkipConfiguration {
			set => Confirmation.SkipConfiguration = value;
			get => Confirmation.SkipConfiguration;
		}

		/// <summary>
		/// 
		/// </summary>
		[NotNull]
		public static ConfirmationWindowConfiguration WindowConfiguration {
			set => Confirmation.WindowConfiguration = value;
			get => Confirmation.WindowConfiguration;
		}

		/// <summary>
		/// The warning text to Display
		/// </summary>
		[NotNull]
		public static string DescriptionText {
			set => Confirmation.WindowConfiguration.DescriptionText = value;
			get => Confirmation.WindowConfiguration.DescriptionText;
		}

		/// <summary>
		/// The content of the title bar of the confirmation window
		/// </summary>
		[NotNull]
		public static string Title {
			set => Confirmation.WindowConfiguration.Title = value;
			get => Confirmation.WindowConfiguration.Title;
		}

		/// <summary>
		/// Whether the user has to retype a phrase, null for default
		/// </summary>
		public static bool ConfirmByRetyping {
			set => Confirmation.WindowConfiguration.ConfirmByRetyping = value;
			get => Confirmation.WindowConfiguration.ConfirmByRetyping;
		}

		/// <summary>
		/// The text the user has to type to confirm the Action
		/// </summary>
		[NotNull]
		public static string ConfirmationText {
			set => Confirmation.WindowConfiguration.ConfirmationText = value;
			get => Confirmation.WindowConfiguration.ConfirmationText;
		}

		/// <summary>
		/// The text to display on the cancel button
		/// </summary>
		[NotNull]
		public static string CancelButtonText {
			set => Confirmation.WindowConfiguration.CancelButtonText = value;
			get => Confirmation.WindowConfiguration.CancelButtonText;
		}
		
		/// <summary>
		/// The text to display on the continue button
		/// </summary>
		[NotNull]
		public static string ConfirmButtonText {
			set => Confirmation.WindowConfiguration.ConfirmButtonText = value;
			get => Confirmation.WindowConfiguration.ConfirmButtonText;
		}

		/// <summary>
		/// 
		/// </summary>
		[CanBeNull]
		public static ImageSource Icon {
			set => Confirmation.WindowConfiguration.Icon = value;
			get => Confirmation.WindowConfiguration.Icon;
		}

		/// <summary>
		/// Whether to skip all confirmation dialog (overrides <see cref="AllowSkip"/> if true)
		/// </summary>
		public static bool SkipAlways {
			set => Confirmation.SkipConfiguration.SkipAlways = value;
			get => Confirmation.SkipConfiguration.SkipAlways;
		}

		/// <summary>
		/// Whether to allow skipping confirmation dialogs at all (overriden by <see cref="SkipAlways"/>)
		/// </summary>
		public static bool AllowSkip {
			set => Confirmation.SkipConfiguration.AllowSkip = value;
			get => Confirmation.SkipConfiguration.AllowSkip;
		}

		/// <summary>
		/// The <see cref="ModifierRequirement"/> for pressing the <see cref="ModifierKeys.Alt"/> key
		/// </summary>
		public static ModifierRequirement Alt {
			set => Confirmation.SkipConfiguration.Alt = value;
			get => Confirmation.SkipConfiguration.Alt;
		}

		/// <summary>
		/// The <see cref="ModifierRequirement"/> for pressing the <see cref="ModifierKeys.Shift"/> key
		/// </summary>
		public static ModifierRequirement Shift {
			set => Confirmation.SkipConfiguration.Shift = value;
			get => Confirmation.SkipConfiguration.Shift;
		}
		/// <summary>
		/// The <see cref="ModifierRequirement"/> for pressing the <see cref="ModifierKeys.Control"/> key
		/// </summary>
		public static ModifierRequirement Control {
			set => Confirmation.SkipConfiguration.Control = value;
			get => Confirmation.SkipConfiguration.Control;
		}

		/// <summary>
		/// The <see cref="ModifierRequirement"/> for pressing the <see cref="ModifierKeys.Windows"/> key
		/// </summary>
		public static ModifierRequirement Windows {
			set => Confirmation.SkipConfiguration.Windows = value;
			get => Confirmation.SkipConfiguration.Windows;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="confirmByRetyping"></param>
		/// <param name="title"></param>
		/// <param name="confirmationText"></param>
		/// <param name="descriptionText"></param>
		/// <param name="icon"></param>
		/// <param name="confirmButtonText"></param>
		/// <param name="abortButtonText"></param>
		public static void SetDefaultWindowConfiguration(bool? confirmByRetyping = null, string title = null, string confirmationText = null,
			string descriptionText = null,
			Option<ImageSource> icon = default(Option<ImageSource>), string confirmButtonText = null, string abortButtonText = null) {
			Confirmation.WindowConfiguration =
				Confirmation.WindowConfiguration.CreateFromDefaults(descriptionText,
					title,
					confirmByRetyping, confirmationText, confirmationText, abortButtonText, icon);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="shift"></param>
		/// <param name="alt"></param>
		/// <param name="control"></param>
		/// <param name="windows"></param>
		/// <param name="allowSkip"></param>
		/// <param name="skipAlways"></param>
		public static void SetDefaultSkipConfiguration(ModifierRequirement? shift = null, ModifierRequirement? alt = null,
			ModifierRequirement? control = null, ModifierRequirement? windows = null,
			bool? allowSkip = null, bool? skipAlways = null) {
			Confirmation.SkipConfiguration =
				Confirmation.SkipConfiguration.CreateFromDefaults(shift, alt, control, windows,
					allowSkip,
					skipAlways);
		}
	}
}