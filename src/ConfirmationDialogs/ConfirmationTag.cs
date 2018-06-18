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
	}
}