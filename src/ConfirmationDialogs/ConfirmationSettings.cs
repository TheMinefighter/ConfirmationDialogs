using System.Windows.Media;
using JetBrains.Annotations;
using OptionalSharp;

namespace ConfirmationDialogs {
	public static class ConfirmationSettings {
		[NotNull]
		public static SkipConfirmationConfiguration SkipConfiguration {
			set => Confirmation.SkipConfiguration = value;
			get => Confirmation.SkipConfiguration;
		}

		[NotNull]
		public static ConfirmationWindowConfiguration WindowConfiguration {
			set => Confirmation.WindowConfiguration = value;
			get => Confirmation.WindowConfiguration;
		}

		public static bool Skip {
			set => Confirmation.SkipConfiguration.SkipAlways = value;
			get => Confirmation.SkipConfiguration.SkipAlways;
		}

		public static bool AllowSkip {
			set => Confirmation.SkipConfiguration.AllowSkip = value;
			get => Confirmation.SkipConfiguration.AllowSkip;
		}

		public static bool ConfirmByRetyping {
			set => Confirmation.WindowConfiguration.ConfirmByRetyping = value;
			get => Confirmation.WindowConfiguration.ConfirmByRetyping;
		}

		[CanBeNull]
		public static ImageSource Icon {
			set => Confirmation.WindowConfiguration.Icon = value;
			get => Confirmation.WindowConfiguration.Icon;
		}

		public static ModifierRequirement Alt {
			set => Confirmation.SkipConfiguration.Alt = value;
			get => Confirmation.SkipConfiguration.Alt;
		}

		public static ModifierRequirement Shift {
			set => Confirmation.SkipConfiguration.Shift = value;
			get => Confirmation.SkipConfiguration.Shift;
		}

		public static ModifierRequirement Control {
			set => Confirmation.SkipConfiguration.Control = value;
			get => Confirmation.SkipConfiguration.Control;
		}

		public static ModifierRequirement Windows {
			set => Confirmation.SkipConfiguration.Windows = value;
			get => Confirmation.SkipConfiguration.Windows;
		}

		public static string AbortButtonText {
			set => Confirmation.WindowConfiguration.AbortButtonText = value;
			get => Confirmation.WindowConfiguration.AbortButtonText;
		}

		public static string ConfirmationText {
			set => Confirmation.WindowConfiguration.ConfirmationText = value;
			get => Confirmation.WindowConfiguration.ConfirmationText;
		}

		public static string DescriptionText {
			set => Confirmation.WindowConfiguration.DescriptionText = value;
			get => Confirmation.WindowConfiguration.DescriptionText;
		}

		public static string Title {
			set => Confirmation.WindowConfiguration.Title = value;
			get => Confirmation.WindowConfiguration.Title;
		}

		public static void SetDefaultWindowConfiguration(bool? confirmByRetyping = null, string title = null, string confirmationText = null,
			string descriptionText = null,
			Optional<ImageSource> icon = default(Optional<ImageSource>), string confirmButtonText = null, string abortButtonText = null) {
			Confirmation.WindowConfiguration =
				Confirmation.WindowConfiguration.CreateFromDefaults(descriptionText,
					title,
					confirmByRetyping, confirmationText, confirmationText, abortButtonText, icon);
		}

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