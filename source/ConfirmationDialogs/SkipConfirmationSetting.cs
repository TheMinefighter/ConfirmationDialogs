using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace ConfirmationDialogs {
	public struct SkipConfirmationSetting {
		public bool AllowSkip;
		public bool SkipAlways;
		public ModifierRequirement Shift;
		public ModifierRequirement Alt;
		public ModifierRequirement Control;
		public ModifierRequirement Windows;
		
		//public Dictionary<ModifierKeys,ModifierRequirement> Requirements;


		public static implicit operator SkipConfirmationSetting(SkipConfirmationPresets src) {
			switch (src) {
				case SkipConfirmationPresets.ShiftForSKip:
					return new SkipConfirmationSetting {
						Shift = ModifierRequirement.Required, AllowSkip = true
					};
				case SkipConfirmationPresets.SkipAlways: return new SkipConfirmationSetting(){SkipAlways=true};
				case SkipConfirmationPresets.NeverSkip: return new SkipConfirmationSetting();
				default:
					throw new ArgumentOutOfRangeException(nameof(src), src, null);
			}
		}
	}
}