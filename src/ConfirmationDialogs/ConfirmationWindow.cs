﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConfirmationDialogs {
	/// <summary>
	///  Interaction logic for ConfirmationWindow.xaml
	/// </summary>
	public partial class ConfirmationWindow : Window {
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
		}

		private void DescriptionTb_OnMouseEnter(object sender, MouseEventArgs e) {
			System.Windows.Forms.MessageBox.Show("Test");
			throw new System.NotImplementedException();
		}
	}
}