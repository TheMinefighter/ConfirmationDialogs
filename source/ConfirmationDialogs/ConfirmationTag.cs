using JetBrains.Annotations;

namespace ConfirmationDialogs {
	internal class ConfirmationTag {
		[NotNull]
		public string Text { get; set; }
      [NotNull]
      public string Confirmation { get; set; }
      [NotNull]
      public string ContinueButton { get; set; }
      [NotNull]
      public string CancelButton { get; set; }
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