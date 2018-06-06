using System.Windows;

namespace ConfirmationDialogs {
	/// <summary>
	///  Interaction logic for FastConfirmationWindow.xaml
	/// </summary>
	public partial class FastConfirmationWindow : Window {
		internal FastConfirmationWindow(ConfirmationTag tag) {
			InitializeComponent();
			Tag = tag;
		}

		private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e) {
			((ConfirmationTag) Tag).Confirmed = true;
			Close();
		}


		private void CancelBtn_OnClick(object sender, RoutedEventArgs e) {
			((ConfirmationTag) Tag).Confirmed = false;
			Close();
		}

		private void FastConfirmationWindow_OnLoaded(object sender, RoutedEventArgs e) {
			ConfirmationTag confirmationTag = (ConfirmationTag) Tag;
			CancelBtn.Content = confirmationTag.CancelButton;
			ConfirmBtn.Content = confirmationTag.ContinueButton;
			DescriptionTb.Text = confirmationTag.DescriptionText;
			if (confirmationTag.Icon != null) {
				Icon = confirmationTag.Icon;
			}
		}
	}
}