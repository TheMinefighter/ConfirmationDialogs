using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConfirmationDialogs
{
   /// <summary>
   /// Interaction logic for FastConfirmationWindow.xaml
   /// </summary>
   public partial class FastConfirmationWindow : Window
   {
      public FastConfirmationWindow()
      {
         InitializeComponent();
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

	   private void CancelBtn_OnClick(object sender, RoutedEventArgs e)
	   {
		   ((ConfirmationTag)Tag).Confirmed = false;
		   Close();
	   }

	   private void FastConfirmationWindow_OnLoaded(object sender, RoutedEventArgs e)
	   {
		   ConfirmationTag confirmationTag = (ConfirmationTag)Tag;
		   CancelBtn.Content = confirmationTag.CancelButton;
		   ConfirmBtn.Content = confirmationTag.ContinueButton;
		   DescriptionTb.Text = confirmationTag.Text;
		   WhatToWriteTb.Text = string.Format(ConfirmationStrings.WhatToWrite, confirmationTag.Confirmation);
		   ConfirmationBoxTb.TextChanged += ConfirmationBoxTb_OnTextChanged;
	   }
   }
}
}
