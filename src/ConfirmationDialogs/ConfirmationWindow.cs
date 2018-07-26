using System.Windows;
using System.Windows.Controls;

namespace ConfirmationDialogs {
	/// <summary>
	///  Interaction logic for ConfirmationWindow.xaml
	/// </summary>
	internal partial class ConfirmationWindow {
		internal static float FontSizeMultiplier =
			(float) (SystemFonts.MessageFontSize * 1.333333333333333333333333333333333333333333333333333333333333333333333333333);

		internal ConfirmationWindow(ConfirmationTag tag) {
			InitializeComponent();
			Tag = tag;
		}

		private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e) {
			if (ConfirmationBoxTb.Text == ((ConfirmationTag) Tag).Confirmation) {
				((ConfirmationTag) Tag).Confirmed = true;
				Close();
			}
		}

		private void ConfirmationBoxTb_OnTextChanged(object sender, TextChangedEventArgs e) {
			ConfirmBtn.IsEnabled = ConfirmationBoxTb.Text == ((ConfirmationTag) Tag).Confirmation;
		}

		private void CancelBtn_OnClick(object sender, RoutedEventArgs e) {
			((ConfirmationTag) Tag).Confirmed = false;
			Close();
		}

		private void ConfirmationWindow_OnLoaded(object sender, RoutedEventArgs e) {
			ConfirmationTag confirmationTag = (ConfirmationTag) Tag;
			CancelBtn.Content = confirmationTag.CancelButton;
			ConfirmBtn.Content = confirmationTag.ContinueButton;
			DescriptionTb.Text = confirmationTag.DescriptionText;
			WhatToWriteTb.Text = string.Format(ConfirmationStrings.WriteInstructions, confirmationTag.Confirmation);
			ConfirmationBoxTb.TextChanged += ConfirmationBoxTb_OnTextChanged;
			if (confirmationTag.Icon != null) {
				Icon = confirmationTag.Icon;
			}

			Title = confirmationTag.Title;
			Height = DescriptionTb.LineCount * FontSizeMultiplier + 133;
		}
	}
}