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
/// 
/// </summary>
		public static bool Skip {
			set => Confirmation.SkipConfiguration.SkipAlways = value;
			get => Confirmation.SkipConfiguration.SkipAlways;
		}
/// <summary>
/// 
/// </summary>
		public static bool AllowSkip {
			set => Confirmation.SkipConfiguration.AllowSkip = value;
			get => Confirmation.SkipConfiguration.AllowSkip;
		}
/// <summary>
/// 
/// </summary>
		public static bool ConfirmByRetyping {
			set => Confirmation.WindowConfiguration.ConfirmByRetyping = value;
			get => Confirmation.WindowConfiguration.ConfirmByRetyping;
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
/// 
/// </summary>
		public static ModifierRequirement Alt {
			set => Confirmation.SkipConfiguration.Alt = value;
			get => Confirmation.SkipConfiguration.Alt;
		}
/// <summary>
/// 
/// </summary>
		public static ModifierRequirement Shift {
			set => Confirmation.SkipConfiguration.Shift = value;
			get => Confirmation.SkipConfiguration.Shift;
		}

		public static ModifierRequirement Control {
			set => Confirmation.SkipConfiguration.Control = value;
			get => Confirmation.SkipConfiguration.Control;
		}
/// <summary>
/// 
/// </summary>
		public static ModifierRequirement Windows {
			set => Confirmation.SkipConfiguration.Windows = value;
			get => Confirmation.SkipConfiguration.Windows;
		}
/// <summary>
/// 
/// </summary>
		public static string AbortButtonText {
			set => Confirmation.WindowConfiguration.AbortButtonText = value;
			get => Confirmation.WindowConfiguration.AbortButtonText;
		}
/// <summary>
/// 
/// </summary>
		public static string ConfirmationText {
			set => Confirmation.WindowConfiguration.ConfirmationText = value;
			get => Confirmation.WindowConfiguration.ConfirmationText;
		}
/// <summary>
/// 
/// </summary>
		public static string DescriptionText {
			set => Confirmation.WindowConfiguration.DescriptionText = value;
			get => Confirmation.WindowConfiguration.DescriptionText;
		}
/// <summary>
/// 
/// </summary>
		public static string Title {
			set => Confirmation.WindowConfiguration.Title = value;
			get => Confirmation.WindowConfiguration.Title;
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