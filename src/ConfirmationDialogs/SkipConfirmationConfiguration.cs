using System;

namespace ConfirmationDialogs {
	public class SkipConfirmationConfiguration : ICloneable {
		public bool AllowSkip;
		public ModifierRequirement Alt;
		public ModifierRequirement Control;
		public ModifierRequirement Shift;
		public bool SkipAlways;
		public ModifierRequirement Windows;

		//public Dictionary<ModifierKeys,ModifierRequirement> Requirements;


		public object Clone() => new SkipConfirmationConfiguration {
			AllowSkip = AllowSkip,
			SkipAlways = SkipAlways,
			Shift = Shift,
			Alt = Alt,
			Control = Control,
			Windows = Windows
		};
		internal SkipConfirmationConfiguration CreateFromDefaults(ModifierRequirement? shift, ModifierRequirement? alt, ModifierRequirement? control, ModifierRequirement? windows,
			bool? allowSkip, bool? skipAlways) =>
			new SkipConfirmationConfiguration {
				Shift = shift ?? Shift,
				Alt = alt ?? Alt,
				Control = control ?? Control,
				Windows = windows ?? Windows,
				AllowSkip = allowSkip?? AllowSkip,
				SkipAlways = skipAlways ?? SkipAlways,
				};
		public static class Presets {
			public static readonly SkipConfirmationConfiguration ShiftForSKip = new SkipConfirmationConfiguration {
				Shift = ModifierRequirement.Required,
				AllowSkip = true
			};

			public static readonly SkipConfirmationConfiguration SkipAlways = new SkipConfirmationConfiguration {SkipAlways = true};
			public static readonly SkipConfirmationConfiguration NeverSkip = new SkipConfirmationConfiguration();
		}
	}
}