using System;


namespace Tests {
	//Test2
	internal class Program {
		[STAThread]
		public static void Main(string[] args) {
			Console.WriteLine(ConfirmationDialogs.Confirmation.Confirm());
			Console.Read();
		}
	}
}