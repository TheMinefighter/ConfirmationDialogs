using System;
using System.Windows;
using System.Windows.Controls;

namespace ConfirmationDialogs
{
	/// <summary>
	/// Interaction logic for ConfirmationWindow.xaml
	/// </summary>
	public partial class ConfirmationWindow : Window
	{
		internal ConfirmationWindow(ConfirmationTag tag) {
			InitializeComponent();
			Tag = tag;
		}


		private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
		{
			if (ConfirmationBoxTb.Text == ((ConfirmationTag)Tag).Confirmation)
			{
				((ConfirmationTag)Tag).Confirmed = true;
				Close();
			}
		}

		private void ConfirmationBoxTb_OnTextChanged(object sender, TextChangedEventArgs e)
		{
				ConfirmBtn.IsEnabled = ConfirmationBoxTb.Text == ((ConfirmationTag)Tag).Confirmation;

		}

		private void CancelBtn_OnClick(object sender, RoutedEventArgs e) {
				((ConfirmationTag)Tag).Confirmed = false;
				Close();
		}	

		private void ConfirmationWindow_OnLoaded(object sender, RoutedEventArgs e) {
			ConfirmationTag confirmationTag = (ConfirmationTag)Tag;
			CancelBtn.Content = confirmationTag.CancelButton;
			ConfirmBtn.Content = confirmationTag.ContinueButton;
			DescriptionTb.Text = confirmationTag.Text;
			WhatToWriteTb.Text = string.Format(ConfirmationStrings.WhatToWrite, confirmationTag.Confirmation);
			ConfirmationBoxTb.TextChanged += ConfirmationBoxTb_OnTextChanged;
		}
	}
}