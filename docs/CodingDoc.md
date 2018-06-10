<br/><br/><br/><br/><br/>

For all of the following samples you will have to add `using ConfirmationDialogs;` to the top of your file.


So let's just ask the user for a simple Confirmation:

```
if (Confirmation.Confirm()) {
	//Executed only if the user confirmed that he is willing to continue
	}
```

Or we could change the warning displayed:

```
Confirmation.Confirm("This is a test warning");
```

When we want the user to retype a phrase ("CONFIRM" by default) we can do it by the following:

```
Confirmation.Confirm(confirmByRetyping: true);
```

As you might have noticed you can skip any confirmation dialog by pressing the shift key.

# Skipping
If you want to skip all confirmation dialogs, e.g. because the user has disabled them, you can just write:

```
ConfirmationSettings.SkipConfiguration=SkipConfirmationConfiguration.Presets.SkipAlways;
```

Or you can disable the skip functionality at all:

```
ConfirmationSettings.SkipConfiguration=SkipConfirmationConfiguration.Presets.NeverSkip;
```

Or to return back to default:

```
ConfirmationSettings.SkipConfiguration=SkipConfirmationConfiguration.Presets.ShiftForSkip;
```

## Manual skip configuration

If you have really special requirements this package serves you:
First you have four ModifierKeys which requirements can be changed in the following:
- Shift
- Alt 
- Control
- Windows

For each of them there are 3 different modes of Requirement:
- Required (Needed for skipping)
- MustNot (If pressed no skipping by keys at all)
- Ignored

Note: if all `ModifierRequirement`s are set to `Ignored` the confirmation will be skipped by default. 
You can find these states in the `ModifierRequirement` enumeration.
For skipping there are additionally the following two settings:
- SkipAlways
- AllowSkip

There are multiple ways of editing these settings.
To edit a single setting run e.g.:

```
ConfirmationSettings.Control = ModifierRequirement.Required
```

To change multiple values you can run:

```
ConfirmationSettings.SetDefaultSkipConfiguration(shift: ModifierRequirement.Ignored, control: ModifierRequirement.Required);
```

If you want to replace the configuration completely just run:

```
ConfirmationSettings.SkipConfirmationConfiguration = 
	new SkipConfirmationConfiguration{
		AllowSkip = true,
		Control =  ModifierRequirement.Required,
		Windows = ModifierRequirement.MustNot
	};
```
