using JetBrains.Annotations;
//using Functional.Option;

namespace ConfirmationDialogs {
	/// <summary>
	///  A configuration defining the behaviour of a confirmation window
	/// </summary>
	public class ConfirmationWindowConfiguration {
//		[NotNull]
//		internal static ConfirmationWindowConfiguration NormalWindowConfiguration = new ConfirmationWindowConfiguration();

		/// <summary>
		///  The Text displayed on the abort button
		/// </summary>
		[NotNull]
		public string CancelButtonText;

		/// <summary>
		///  The text the user has to type
		/// </summary>
		[NotNull]
		public string ConfirmationText;

		/// <summary>
		///  The Text displayed on the confirm button
		/// </summary>
		[NotNull]
		public string ConfirmButtonText;

		/// <summary>
		///  Whether to use
		/// </summary>
		public bool ConfirmByRetyping;

		/// <summary>
		///  The text describing why the action might be dangerous
		/// </summary>
		[NotNull]
		public string DescriptionText;

//		/// <summary>
//		///  The <see cref="ImageSource" /> providing the icon of the confirmation windows, use <see langword="null" /> for default icon
//		/// </summary>
//		[CanBeNull]
//		public ImageSource Icon;

		/// <summary>
		///  The Window title
		/// </summary>
		[NotNull]
		public string Title;

		internal ConfirmationTag Tag => new ConfirmationTag {
			CancelButton = CancelButtonText,
			Confirmation = ConfirmationText,
			ContinueButton = ConfirmButtonText,
			DescriptionText = DescriptionText,
			//	Icon = Icon,
			Title = Title
		};

		/// <summary>
		///  Creates a new <see cref="ConfirmationWindowConfiguration" /> and initalizes defaults
		/// </summary>
		public ConfirmationWindowConfiguration() {
			ConfirmByRetyping = false;
			Title = ConfirmationStrings.DefaultTitle;
			ConfirmationText = ConfirmationStrings.DefaultConfirmationText;
			DescriptionText = ConfirmationStrings.DefaultDescriptionText;
			ConfirmButtonText = ConfirmationStrings.DefaultContinueButtonText;
			CancelButtonText = ConfirmationStrings.DefaultCancelButton;
		}

//Why is there no hiding in C#?
		// Nulls are ok because it is private
		// ReSharper disable once NotNullMemberIsNotInitialized
		private ConfirmationWindowConfiguration(bool empty) { }

		internal bool Confirm() {
			if (ConfirmByRetyping) {
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
			string title, bool? confirmByRetyping, string confirmationText, string confirmButtonText, string abortButtonText
			//,Option<ImageSource> icon
		) =>
			new ConfirmationWindowConfiguration(true) {
				ConfirmByRetyping = confirmByRetyping ?? ConfirmByRetyping,
				Title = title ?? Title,
				ConfirmationText = confirmationText ?? ConfirmationText,
				DescriptionText = descriptionText ?? DescriptionText,
				//	Icon = icon.ValueOr(Icon),
				ConfirmButtonText = confirmButtonText ?? ConfirmButtonText,
				CancelButtonText = abortButtonText ?? CancelButtonText
			};
	}
}