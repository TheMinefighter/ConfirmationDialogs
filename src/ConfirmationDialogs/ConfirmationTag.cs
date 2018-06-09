using System.Windows.Media;
using JetBrains.Annotations;

namespace ConfirmationDialogs {
	internal class ConfirmationTag {
		public bool Confirmed;

		[NotNull]
		public string DescriptionText { get; set; }

		[CanBeNull]
		public ImageSource Icon { get; set; }

		[NotNull]
		public string Confirmation { get; set; }

		[NotNull]
		public string ContinueButton { get; set; }

		[NotNull]
		public string CancelButton { get; set; }

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