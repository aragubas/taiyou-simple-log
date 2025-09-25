/*
  License with "MIT" (https://spdx.org/licenses/MIT.html)
  Copyright 2025 Aragubas. Check out https://aragubas.com 
  by Aragubas/Harley Sky Saphri at harleyskysaphri@gmail.com. Check out https://aragubas.com
*/

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Godot;

namespace TaiyouSimpleLog;

/// <summary>
/// Main TaiyouSimpleLog class
/// </summary>
public static class Log {
  static readonly string s_DefaultDebugColor = "#696969";
  static readonly string s_DefaultWarningColor = "#FFA500";
  static readonly string s_DefaultErrorColor = "#FF0000";

  /// <summary>
  /// HTML color for debug messages
  /// </summary>
  public static string DebugColor = s_DefaultDebugColor;
  /// <summary>
  /// HTML color for warning messages 
  /// </summary>
  public static string WarningColor = s_DefaultWarningColor;
  /// <summary>
  /// HTML color for error messages 
  /// </summary>
  public static string ErrorColor = s_DefaultErrorColor;
  /// <summary>
  /// If enabled, the actual message from the log output will not be colored 
  /// </summary>
  public static bool NoColorMessages;
  /// <summary>
  /// If enabled, Warning and Error messages will not be logged into Godot's internal debugger, but rather on the OS's terminal/Godot's Output Window 
  /// </summary>
  public static bool PrintRich;
  /// <summary>
  /// If enabled, Warning messages will not be logged into Godot's internal debugger, but rather on the OS's terminal/Godot's Output Window
  /// </summary>
  public static bool PrintRichWarning;
  /// <summary>
  /// If enabled, Error messages will not be logged into Godot's internal debugger, but rather on the OS's terminal/Godot's Output Window  
  /// </summary>
  public static bool PrintRichError;

  /// <summary>
  /// Resets DebugColor to it's default, hardcoded value
  /// </summary>
  public static void ResetDebugColor() {
    DebugColor = s_DefaultDebugColor;
  }

  /// <summary>
  /// Resets WarningColor to it's default, hardcoded value
  /// </summary>
  public static void ResetWarningColor() {
    WarningColor = s_DefaultWarningColor;
  }

  /// <summary>
  /// Resets ErrorsColor to it's default, hardcoded value
  /// </summary>
  public static void ResetErrorColor() {
    ErrorColor = s_DefaultErrorColor;
  }

  /// <summary>
  /// Logs message into OS terminal 
  /// </summary>
  /// <param name="message">Message to log</param>
  /// <param name="methodName">The name of the calling method. Automatically filled, auto-filled by the compiler</param> 
  /// <param name="className">The name of the calling class, auto-filled by the compiler</param>
  [StackTraceHidden]
  public static void Debug(
    string message,
    [CallerFilePath] string className = "",
    [CallerMemberName] string methodName = "") {

    className = Path.GetFileName(className);

    string printMessage;
    if (NoColorMessages)
      printMessage = $"[color={DebugColor}]{MethodHeader(className, methodName)};[/color] {message}";
    else
      printMessage = $"[color={DebugColor}]{MethodHeader(className, methodName)}; {message} [/color]";

    GD.PrintRich(printMessage);
  }

  /// <summary>
  /// Logs message into Godot's built in debugger (if PrintRich or PrintRichWarning is <b>not</b> defined) and into OS terminal
  /// </summary>
  /// <param name="message"></param>
  /// <param name="methodName">The name of the calling method, auto-filled by the compiler</param> 
  /// <param name="className">The name of the calling class, auto-filled by the compiler</param>
  [StackTraceHidden]
  public static void Warning(
    string message,
    [CallerFilePath] string className = "",
    [CallerMemberName] string methodName = "") {
    className = Path.GetFileName(className);

    if (PrintRich || PrintRichWarning) {
      string printMessage;
      if (NoColorMessages)
        printMessage = $"[color={WarningColor}] WARN {MethodHeader(className, methodName)};[/color] {message}";
      else
        printMessage = $"[color={WarningColor}] WARN {MethodHeader(className, methodName)}; {message}[/color]";

      GD.PrintRich(printMessage);
      return;
    }

    // Not printing rich
    GD.PushWarning($"{MethodHeader(className, methodName)}; {message}");
  }

  /// <summary>
  /// Logs message into standard error output (if PrintRich or PrintRichError is <b>not</b> defined) and into OS terminal
  /// </summary>
  /// <param name="message"></param>
  /// <param name="methodName">The name of the calling method, auto-filled by the compiler</param> 
  /// <param name="className">The name of the calling class, auto-filled by the compiler</param>
  [StackTraceHidden]
  public static void Error(
    string message,
    [CallerFilePath] string className = "",
    [CallerMemberName] string methodName = "") {

    className = Path.GetFileName(className);

    if (PrintRich || PrintRichError) {
      string printMessage;

      if (NoColorMessages)
        printMessage = $"[color={ErrorColor}]ERROR {MethodHeader(className, methodName)};[/color] {message}";
      else
        printMessage = $"[color={ErrorColor}]ERROR {MethodHeader(className, methodName)}; {message}[/color]";

      GD.PrintRich(printMessage);
      return;
    }

    // Not printing rich
    GD.PushError($"{MethodHeader(className, methodName)}; {message}");
  }

  /// <summary>
  /// Returns a neatly formatted string with the className and methodName as if Reflection was available
  /// </summary>
  /// <param name="className">Name of the calling class (without namespace)</param>
  /// <param name="methodName">Name of the calling method</param>
  /// <returns>A neatly formatted string with className and methodName</returns>
  public static string MethodHeader(string className, string methodName)
    => $"{className}::{methodName}";
}