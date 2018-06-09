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
