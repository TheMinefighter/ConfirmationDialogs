using System;
using ConfirmationDialogs;

namespace Tests {
	internal class Program {
		[STAThread]
		public static void Main(string[] args) {
			ConfirmationSettings.Fast = false;
			Console.WriteLine(Confirmation.Confirm());
			Console.Read();
		}
	}
}