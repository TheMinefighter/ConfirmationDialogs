using System.Windows.Input;
using JetBrains.Annotations;
//using Functional.Option;

namespace ConfirmationDialogs {
	/// <summary>
	///  Contains all settings for this library, and defines the default behaviours of confirmation dialogs
	/// </summary>
	public static class ConfirmationSettings {
		/// <summary>
		///  The <see cref="SkipConfirmationConfiguration" /> used by default
		/// </summary>
		[NotNull]
		public static SkipConfirmationConfiguration SkipConfiguration {
			set => Confirmation.SkipConfiguration = value;
			get => Confirmation.SkipConfiguration;
		}

		/// <summary>
		///  The <see cref="ConfirmationWindowConfiguration" /> used by default
		/// </summary>
		[NotNull]
		public static ConfirmationWindowConfiguration WindowConfiguration {
			set => Confirmation.WindowConfiguration = value;
			get => Confirmation.WindowConfiguration;
		}

		/// <summary>
		///  The warning text to Display
		/// </summary>
		[NotNull]
		public static string DescriptionText {
			set => Confirmation.WindowConfiguration.DescriptionText = value;
			get => Confirmation.WindowConfiguration.DescriptionText;
		}

		/// <summary>
		///  The content of the title bar of the confirmation window
		/// </summary>
		[NotNull]
		public static string Title {
			set => Confirmation.WindowConfiguration.Title = value;
			get => Confirmation.WindowConfiguration.Title;
		}

		/// <summary>
		///  Whether the user has to retype a phrase, null for default
		/// </summary>
		public static bool ConfirmByRetyping {
			set => Confirmation.WindowConfiguration.ConfirmByRetyping = value;
			get => Confirmation.WindowConfiguration.ConfirmByRetyping;
		}

		/// <summary>
		///  The text the user has to type to confirm the Action
		/// </summary>
		[NotNull]
		public static string ConfirmationText {
			set => Confirmation.WindowConfiguration.ConfirmationText = value;
			get => Confirmation.WindowConfiguration.ConfirmationText;
		}

		/// <summary>
		///  The text to display on the cancel button
		/// </summary>
		[NotNull]
		public static string CancelButtonText {
			set => Confirmation.WindowConfiguration.CancelButtonText = value;
			get => Confirmation.WindowConfiguration.CancelButtonText;
		}

		/// <summary>
		///  The text to display on the continue button
		/// </summary>
		[NotNull]
		public static string ConfirmButtonText {
			set => Confirmation.WindowConfiguration.ConfirmButtonText = value;
			get => Confirmation.WindowConfiguration.ConfirmButtonText;
		}

//		/// <summary>
//		/// The icon to display in the windows, <see langword="null"/> for not changing it
//		/// </summary>
//		[CanBeNull]
//		public static ImageSource Icon {
//			set => Confirmation.WindowConfiguration.Icon = value;
//			get => Confirmation.WindowConfiguration.Icon;
//		}

		/// <summary>
		///  Whether to skip all confirmation dialog (overrides <see cref="AllowSkip" /> if true)
		/// </summary>
		public static bool SkipAlways {
			set => Confirmation.SkipConfiguration.SkipAlways = value;
			get => Confirmation.SkipConfiguration.SkipAlways;
		}

		/// <summary>
		///  Whether to allow skipping confirmation dialogs at all (overriden by <see cref="SkipAlways" />)
		/// </summary>
		public static bool AllowSkip {
			set => Confirmation.SkipConfiguration.AllowSkip = value;
			get => Confirmation.SkipConfiguration.AllowSkip;
		}

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Alt" /> key
		/// </summary>
		public static ModifierRequirement Alt {
			set => Confirmation.SkipConfiguration.Alt = value;
			get => Confirmation.SkipConfiguration.Alt;
		}

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Shift" /> key
		/// </summary>
		public static ModifierRequirement Shift {
			set => Confirmation.SkipConfiguration.Shift = value;
			get => Confirmation.SkipConfiguration.Shift;
		}

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Control" /> key
		/// </summary>
		public static ModifierRequirement Control {
			set => Confirmation.SkipConfiguration.Control = value;
			get => Confirmation.SkipConfiguration.Control;
		}

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Windows" /> key
		/// </summary>
		public static ModifierRequirement Windows {
			set => Confirmation.SkipConfiguration.Windows = value;
			get => Confirmation.SkipConfiguration.Windows;
		}

		/// <summary>
		///  Changes certain parts of the default <see cref="ConfirmationWindowConfiguration" />
		/// </summary>
		/// <param name="descriptionText">The warning text to display, <see langword="null" /> for not changing it</param>
		/// <param name="title">The content of the title bar of the confirmation window, <see langword="null" /> for not changing it</param>
		/// <param name="confirmByRetyping">Whether the user has to retype a phrase, <see langword="null" /> for not changing it</param>
		/// <param name="confirmationText">The text the user has to type to confirm the Action, <see langword="null" /> for not changing itt</param>
		/// <param name="confirmButtonText">The text to display on the continue button, <see langword="null" /> for not changing it</param>
		/// <param name="abortButtonText">The text to display on the cancel button, <see langword="null" /> for not changing it</param>
		public static void SetDefaultWindowConfiguration(string descriptionText = null, //	/// <param name="icon"></param>
			string title = null, bool? confirmByRetyping = null, string confirmationText = null,
			string confirmButtonText = null, string abortButtonText = null) {
			//Option<ImageSource> icon = default(Option<ImageSource>),
			Confirmation.WindowConfiguration =
				Confirmation.WindowConfiguration.CreateFromDefaults(descriptionText,
					title,
					confirmByRetyping, confirmationText, confirmationText, abortButtonText
					//, icon
				);
		}

		/// <summary>
		///  Changes certain parts of the default <see cref="SkipConfirmationConfiguration" />
		/// </summary>
		/// <param name="shift">
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Shift" /> key, <see langword="null" />
		///  for not changing it
		/// </param>
		/// <param name="alt">
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Alt" /> key, <see langword="null" /> for
		///  not changing it
		/// </param>
		/// <param name="control">
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Control" /> key,
		///  <see langword="null" /> for not changing it
		/// </param>
		/// <param name="windows">
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Windows" /> key,
		///  <see langword="null" /> for not changing it
		/// </param>
		/// <param name="allowSkip">
		///  Whether to allow skipping confirmation dialogs at all (overriden by <see cref="skipAlways" />),
		///  <see langword="null" /> for not changing it
		/// </param>
		/// <param name="skipAlways">
		///  Whether to skip all confirmation dialog (overrides <see cref="allowSkip" /> if true), <see langword="null" /> for
		///  not changing it
		/// </param>
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