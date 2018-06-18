using System.Media;
using System.Windows.Media;
using JetBrains.Annotations;

namespace ConfirmationDialogs {
	internal class ConfirmationTag {
		public bool Confirmed;

		[NotNull]
		internal string Title;

		[NotNull]
		internal string DescriptionText;

		[CanBeNull]
		internal ImageSource Icon;

		[NotNull]
		internal string Confirmation;

		[NotNull]
		internal string ContinueButton;

		[NotNull]
		internal string CancelButton;

		[CanBeNull]
		internal SystemSound Sound;

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