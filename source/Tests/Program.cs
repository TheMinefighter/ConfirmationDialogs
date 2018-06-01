using System;
using ConfirmationDialogs;


namespace Tests {
	internal class Program {
		[STAThread]
		public static void Main(string[] args) {
			Console.WriteLine(ConfirmationDialogs.Confirmation.Confirm());
			Console.Read();
		}
	}
}