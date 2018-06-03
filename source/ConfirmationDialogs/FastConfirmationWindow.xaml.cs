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
	   internal FastConfirmationWindow(ConfirmationTag tag)
	   {
		   InitializeComponent();
		   Tag = tag;
	   }

      private void ConfirmBtn_OnClick(object sender, RoutedEventArgs e)
	   {

			   ((ConfirmationTag)Tag).Confirmed = true;
			   Close();
		   
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
	   }
   }
}