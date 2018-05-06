using JetBrains.Annotations;

namespace ConfirmationDialogs {
	internal class ConfirmationTag {
		[NotNull]
		public string Text { get; }
      [NotNull]
      public string Confirmation { get; }
      [NotNull]
      public string ContinueButton { get; }
      [NotNull]
      public string CancelButton { get; }
      public bool Confirmed;
		public ConfirmationTag(string text=null, string confirmation=null,string continueButton= null,string cancelButton=null)
		{
			CancelButton = cancelButton ?? ConfirmationStrings.DefaultCancelButton;
			ContinueButton = continueButton ?? ConfirmationStrings.DefaultContinueButton;
			Text = text??ConfirmationStrings.DefaultText;
			Confirmation = confirmation??ConfirmationStrings.DefaultConfirmationText ;
			Confirmed = false;
		}
//		public static  implicit operator ConfirmationTag((string, string) source) => new ConfirmationTag(source.Item1,source.Item2);
//		public static  implicit operator ConfirmationTag(string source) => new ConfirmationTag(source);
	}
}