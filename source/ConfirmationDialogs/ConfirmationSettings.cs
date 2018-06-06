namespace ConfirmationDialogs {
	public static class ConfirmationSettings {
		public static ConfirmationConfiguration Configurations {
			set => Confirmation._configuration = value;
			get => Confirmation._configuration;
		}

		public static bool Skip {
			set => Confirmation._configuration.SkipAlways = value;
			get => Confirmation._configuration.SkipAlways;
		}

		public static bool AllowSkip {
			set => Confirmation._configuration.AllowSkip = value;
			get => Confirmation._configuration.AllowSkip;
		}

		public static bool Fast {
			set => Confirmation._configuration.Fast = value;
			get => Confirmation._configuration.Fast;
		}

		public static ModifierRequirement Alt {
			set => Confirmation._configuration.Alt = value;
			get => Confirmation._configuration.Alt;
		}

		public static ModifierRequirement Shift {
			set => Confirmation._configuration.Shift = value;
			get => Confirmation._configuration.Shift;
		}

		public static ModifierRequirement Control {
			set => Confirmation._configuration.Control = value;
			get => Confirmation._configuration.Control;
		}

		public static ModifierRequirement Windows {
			set => Confirmation._configuration.Windows = value;
			get => Confirmation._configuration.Windows;
		}
	}
}