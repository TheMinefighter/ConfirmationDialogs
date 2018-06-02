using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public static class ConfirmationSettings {

		public static bool Skip {
			set => Confirmation._setting.SkipAlways = value;
		}

		public static bool AllowSkip {
			set => Confirmation._setting.AllowSkip = value;
		}

		public static ModifierRequirement Alt {
			set => Confirmation._setting.Alt = value;
		}

		public static ModifierRequirement Shift {
			set => Confirmation._setting.Shift = value;
		}

		public static ModifierRequirement Control {
			set => Confirmation._setting.Control = value;
		}

		public static ModifierRequirement Windows {
			set => Confirmation._setting.Windows = value;
		}
	}
}