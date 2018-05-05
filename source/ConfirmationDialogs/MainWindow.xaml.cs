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
		internal ConfirmationWindow(ConfirmationTag tag)
		{
			Tag = tag;
			DescriptionTb.Text = tag.Text;
			WhatToWriteTb.Text = string.Format("Lol {0} df", tag.Confirmation);
		}


		private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
		{
			if (ConfirmationBoxTb.Text == ((ConfirmationTag)Tag).Text)
			{
				((ConfirmationTag)Tag).Confirmed = true;
				Close();
			}
		}

		private void ConfirmationBoxTb_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			if (ConfirmationBoxTb.Text == ((ConfirmationTag)Tag).Text)
			{
				ConfirmBtn.IsEnabled = true;
			}
		}
	}
}