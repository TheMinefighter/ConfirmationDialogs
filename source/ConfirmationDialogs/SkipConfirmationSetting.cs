using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Xml.Schema;

namespace ConfirmationDialogs {
	public struct SkipConfirmationSetting {
		public bool AllowSkip;
		public bool SkipAlways;
		public ModifierRequirement Shift;
		public ModifierRequirement Alt;
		public ModifierRequirement Control;
		public ModifierRequirement Windows;

		public static class Prests {
			public static readonly SkipConfirmationSetting ShiftForSKip = new SkipConfirmationSetting {
				Shift = ModifierRequirement.Required,
				AllowSkip = true
			};

			public static readonly SkipConfirmationSetting SkipAlways = new SkipConfirmationSetting {SkipAlways = true};
			public static readonly SkipConfirmationSetting NeverSkip= new SkipConfirmationSetting();
		}
		//public Dictionary<ModifierKeys,ModifierRequirement> Requirements;


	}
}