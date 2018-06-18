using System.Media;
using System.Windows.Media;
using JetBrains.Annotations;

namespace ConfirmationDialogs {
	internal class ConfirmationTag {
		public bool Confirmed;

		[NotNull]
		public string Title;

		[NotNull]
		public string DescriptionText;

		[CanBeNull]
		public ImageSource Icon;

		[NotNull]
		public string Confirmation;

		[NotNull]
		public string ContinueButton;

		[NotNull]
		public string CancelButton;

		[CanBeNull]
		public SystemSound Sound;

		// ReSharper disable once NotNullMemberIsNotInitialized
		// Only done internal
		//		public ConfirmationTag(string text = null, string confirmation = null, string continueButton = null, string cancelButton = null) {
//			CancelButton = cancelButton ?? ConfirmationStrings.DefaultCancelButton;
//			ContinueButton = continueButton ?? ConfirmationStrings.DefaultContinueButton;
//			DescriptionText = text ?? ConfirmationStrings.DefaultText;
//			Confirmation = confirmation ?? ConfirmationStrings.DefaultConfirmationText;
//			Confirmed = false;
//		}

//		public static  implicit operator ConfirmationTag((string, string) source) => new ConfirmationTag(source.Item1,source.Item2);
//		public static  implicit operator ConfirmationTag(string source) => new ConfirmationTag(source);
	}
}