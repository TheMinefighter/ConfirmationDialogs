using System.Windows.Media;
using JetBrains.Annotations;
using Optional;

namespace ConfirmationDialogs {
	public class ConfirmationWindowConfiguration {
//		[NotNull]
//		internal static ConfirmationWindowConfiguration NormalWindowConfiguration = new ConfirmationWindowConfiguration();

		/// <summary>
		///  The Text displayed on the abort button
		/// </summary>
		[NotNull]
		public string AbortButtonText;

		/// <summary>
		///  The text the user has to type
		/// </summary>
		[NotNull]
		public string ConfirmationText;

		/// <summary>
		///  The Text displayed on the confirm button
		/// </summary>
		[NotNull]
		public string ContinueButtonText;

		/// <summary>
		///  The text describing why the action might be dangerous
		/// </summary>
		[NotNull]
		public string DescriptionText;

		/// <summary>
		///  Whether to use the dialog without entering a confirmation text
		/// </summary>
		public bool Fast;

		/// <summary>
		///  The Icon of the confirmation windows
		/// </summary>
		[CanBeNull]
		public ImageSource Icon;

		/// <summary>
		///  The Window title
		/// </summary>
		[NotNull]
		public string Title;

		internal ConfirmationTag Tag => new ConfirmationTag {
			CancelButton = AbortButtonText,
			Confirmation = ConfirmationText,
			ContinueButton = ContinueButtonText,
			DescriptionText = DescriptionText,
			Icon = Icon
		};

		/// <summary>
		///  Creates a new <see cref="ConfirmationWindowConfiguration" /> and initalizes defaults
		/// </summary>
		public ConfirmationWindowConfiguration() {
			Fast = true;
			Title = ConfirmationStrings.DefaultTitle;
			ConfirmationText = ConfirmationStrings.DefaultConfirmationText;
			DescriptionText = ConfirmationStrings.DefaultDescriptionText;
			ContinueButtonText = ConfirmationStrings.DefaultContinueButtonText;
			AbortButtonText = ConfirmationStrings.DefaultCancelButton;
		}

//Why is there no hiding in C#?
		// Nulls are ok because it is private
		// ReSharper disable once NotNullMemberIsNotInitialized
		private ConfirmationWindowConfiguration(bool empty) { }

		internal bool Confirm() {
			if (!Fast) {
				ConfirmationWindow window = new ConfirmationWindow(Tag);
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
			else {
				FastConfirmationWindow window = new FastConfirmationWindow(Tag);
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
		}

		internal ConfirmationWindowConfiguration CreateFromDefaults(string descriptionText,
			string title, bool? fast, string confirmationText, string confirmButtonText, string abortButtonText,
			Option<ImageSource> icon) =>
			new ConfirmationWindowConfiguration(true) {
				Fast = fast ?? Fast,
				Title = title ?? Title,
				ConfirmationText = confirmationText ?? ConfirmationText,
				DescriptionText = descriptionText ?? DescriptionText,
				Icon = icon.ValueOr(Icon),
				ContinueButtonText = confirmButtonText ?? ContinueButtonText,
				AbortButtonText = abortButtonText ?? AbortButtonText
			};
	}
}