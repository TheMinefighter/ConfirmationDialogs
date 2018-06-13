using System.Windows.Input;

namespace ConfirmationDialogs {
	/// <summary>
	///  Contains settings about when to skip a confirmation dialog
	/// </summary>
	public class SkipConfirmationConfiguration {
		/// <summary>
		///  Whether to allow skipping confirmation dialogs at all (overriden by <see cref="SkipAlways" />)
		/// </summary>
		public bool AllowSkip;

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Alt" /> key
		/// </summary>
		public ModifierRequirement Alt;

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Control" /> key
		/// </summary>
		public ModifierRequirement Control;

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Shift" /> key
		/// </summary>
		public ModifierRequirement Shift;

		/// <summary>
		///  Whether to skip all confirmation dialog (overrides <see cref="AllowSkip" /> if true)
		/// </summary>
		public bool SkipAlways;

		/// <summary>
		///  The <see cref="ModifierRequirement" /> for pressing the <see cref="ModifierKeys.Windows" /> key
		/// </summary>
		public ModifierRequirement Windows;

		//public Dictionary<ModifierKeys,ModifierRequirement> Requirements;

		/// <summary>
		/// </summary>
		/// <returns></returns>
		public object Clone() => new SkipConfirmationConfiguration {
			AllowSkip = AllowSkip,
			SkipAlways = SkipAlways,
			Shift = Shift,
			Alt = Alt,
			Control = Control,
			Windows = Windows
		};

		internal SkipConfirmationConfiguration CreateFromDefaults(ModifierRequirement? shift, ModifierRequirement? alt,
			ModifierRequirement? control, ModifierRequirement? windows,
			bool? allowSkip, bool? skipAlways) =>
			new SkipConfirmationConfiguration {
				Shift = shift ?? Shift,
				Alt = alt ?? Alt,
				Control = control ?? Control,
				Windows = windows ?? Windows,
				AllowSkip = allowSkip ?? AllowSkip,
				SkipAlways = skipAlways ?? SkipAlways
			};

		/// <summary>
		///  Contains multiple presets of <exception cref="SkipConfirmationConfiguration"></exception>
		/// </summary>
		public static class Presets {
			/// <summary>
			///  Allows to skip dialogs simply by pressing shift
			/// </summary>
			public static SkipConfirmationConfiguration ShiftForSKip => new SkipConfirmationConfiguration {
				Shift = ModifierRequirement.Required,
				AllowSkip = true
			};

			/// <summary>
			///  Skips sll dialogs
			/// </summary>
			public static SkipConfirmationConfiguration SkipAlways => new SkipConfirmationConfiguration {SkipAlways = true};

			/// <summary>
			///  Never skips any dialog
			/// </summary>
			public static SkipConfirmationConfiguration NeverSkip => new SkipConfirmationConfiguration();
		}
	}
}