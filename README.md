# Migrated
This project has been migrated to Codeberg. Here's the new, up-to-date link: https://codeberg.org/Aragubas/taiyou-simple-log

## Taiyou Simple Log
A simple, configurable and elegant logging library for Godot 4.* C# projects!

By using static boolean variables, you can configure TaiyouSimpleLog to do behave how you want 

TaiyouSimpleLog supports projects with and without Reflection (useful for Web/iOS/Android builds)

## Example 
By default, TaiyouLog is configured, Color Messages and PrintRich disabled 

```c#
Log.Debug(""); // Logs message into OS terminal and Godot's built in output
Log.Warning(""); // Logs message into Godot's built in debugger (if PrintRich is disabled) and OS terminal
Log.Error(""); // Logs message into Godot's built in debugger (if PrintRich is disabled) and OS terminal
```

## Customization
TaiyouSimpleLog has 7 static variables that can be changed:
1.  NoColorMessages
1.  PrintRich
1.  PrintRichWarning
1.  PrintRichError 
1.  DebugColor
1.  WarningColor
1.  ErrorColor

And 3 methods for resetting the colors to it's defaults
1. ResetDebugColor
1. ResetWarningColor
1. ResetErrorColor

### NoColorMessages
If enabled, the message part from the log output will not be colored 


### PrintRich
If enabled, Warning and Error messages will not be logged into Godot's internal debugger, but rather on the OS's terminal/Godot's Output Window 

### PrintRichWarning/PrintRichError 
If enabled, Warning/Error messages will not be logged into Godot's internal debugger, but rather on the OS's terminal/Godot's Output Window  

---
### Changing colors
You can also change the color set for Debug, Error and Warning (if PrintRich is enabled) by changing the respective variables in the ``Log.cs`` class
1. DebugColor
1. WarningColor
1. ErrorColor

Methods for restoring the default color is also available
1. ResetDebugColor()
1. ResetWarningColor()
1. ResetErrorColor()

---
### Example
Changing the color of a debug output to blue, and then restoring it back
```c#
Log.DebugColor = "#0000FF"; // Must be hexadecimal color codes 
Log.Debug("Debug! but in blue");
Log.ResetDebugColor(); // Resets to the default color, hardcoded in the class
```

# Donations 
If you like what you see and wants to help us develop more useful libraries, check out my funding platforms below!

Kofi (https://ko-fi.com/aragubas)


# License
This project has been licensed with the MIT license. 

More information at [LICENSE.txt](LICENSE.txt) 
