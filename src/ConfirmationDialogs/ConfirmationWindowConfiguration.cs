using System.Media;
using System.Windows.Media;
using JetBrains.Annotations;

namespace ConfirmationDialogs {
	/// <summary>
	///  A configuration defining the behaviour of a confirmation window
	/// </summary>
	public class ConfirmationWindowConfiguration {
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

		/// <summary>
		///  The <see cref="ImageSource" /> providing the icon of the confirmation windows,
		///  use <see langword="null" /> for default icon
		/// </summary>
		[CanBeNull]
		public ImageSource Icon;

		/// <summary>
		///  The <see cref="SystemSound" /> to play, use <see langword="null" /> for no sound,
		///  possible values are obtainable in the <see cref="SystemSounds" /> <see langword="class" />
		/// </summary>
		[CanBeNull]
		public SystemSound Sound;


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
			Icon = Icon,
			Title = Title,
			Sound = Sound
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
			Icon = null;
			Sound = SystemSounds.Asterisk;
		}

//Why is there no hiding in C#?
		// Nulls are ok because it is private
		// ReSharper disable once NotNullMemberIsNotInitialized
		private ConfirmationWindowConfiguration(bool empty) { }

		internal bool Confirm() {
			ConfirmationTag confirmationTag = Tag;
			confirmationTag.Sound?.Play();

			if (ConfirmByRetyping) {
				ConfirmationWindow window = new ConfirmationWindow(confirmationTag);
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
			else {
				FastConfirmationWindow window = new FastConfirmationWindow(confirmationTag);
				window.ShowDialog();
				return window.Tag is ConfirmationTag b && b.Confirmed;
			}
		}

		internal ConfirmationWindowConfiguration CreateFromDefaults(string descriptionText,
			string title, bool? confirmByRetyping, string confirmationText, string confirmButtonText,
			string abortButtonText
			, OptionalContent<ImageSource> icon, OptionalContent<SystemSound> sound
		) =>
			new ConfirmationWindowConfiguration(true) {
				ConfirmByRetyping = confirmByRetyping ?? ConfirmByRetyping,
				Title = title ?? Title,
				ConfirmationText = confirmationText ?? ConfirmationText,
				DescriptionText = descriptionText ?? DescriptionText,
				ConfirmButtonText = confirmButtonText ?? ConfirmButtonText,
				CancelButtonText = abortButtonText ?? CancelButtonText,
				Icon = icon??Icon,
				Sound = sound??Sound
			};
	}
}