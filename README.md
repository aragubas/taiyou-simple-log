# Taiyou Simple Log
A simple, configurable and elegant logging library for Godot 4.* C# projects!

By using C#'s compiler definitions, you can configure TaiyouSimpleLog to do exactly what you want without any additional runtime costs! 

TaiyouSimpleLog supports projects with and without Reflection (useful for Web/iOS/Android builds)

## Example 
By default, TaiyouLog is configured with Reflection enabled, Color Messages and PrintRich disabled 

```c#
Log.Debug(""); // Logs message into OS terminal and Godot's built in output
Log.Warning(""); // Logs message into Godot's built in debugger (if PrintRich is disabled) and OS terminal
Log.Error(""); // Logs message into Godot's built in debugger (if PrintRich is disabled) and OS terminal
```

## Customization
TaiyouSimpleLog has 5 compiler definitions that can be set:
1. TAIYOULOG_NO_REFLECTION
1. TAIYOULOG_NO_COLOR_MESSAGE
1. TAIYOULOG_PRINTRICH
1. TAIYOULOG_WARNING_PRINTRICH
1. TAIYOULOG_ERROR_PRINTRICH 

### TAIYOULOG_NO_REFLECTION
If set, any code that uses reflection will be disabled. Since TaiyouSimpleLog fetches the classname and methodname using Reflection, it will require you to manually set the ClassName and MethodName using the ``methodName`` and ``className`` parameters.

### TAIYOULOG_NO_COLOR_MESSAGE
If set, disables coloring the message segment from log output

### TAIYOULOG_PRINTRICH 
If set, enables PrintRich for Warnings and Errors. PrintRich will make errors and warnings not be logged into Godot's built in debugger, and instead on the Output window/OS Terminal.

### TAIYOULOG_(WARNING/ERROR)_PRINTRICH
If set, enables PrintRich for either Warning or Error, available as two compiler definitions
1. TAIYOULOG_WARNING_PRINTRICH
1. TAIYOULOG_ERROR_PRINTRICH
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


### Example
Changing the color of a debug output to blue, and then restoring it back
```c#
Log.DebugColor = "blue"; // Must be color codes accepted by Godot's PrintRich method
Log.Debug("Debug! but in blue");
Log.ResetDebugColor(); // Resets to the default color, hardcoded in the class
```

# Donations 
If you like what you see and wants to help us develop more useful libraries, check out my funding platforms below!

Kofi (https://ko-fi.com/aragubas)


# License
This project has been licensed with the MIT license. 

More information at [LICENSE.txt](LICENSE.txt) 