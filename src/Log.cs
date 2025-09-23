/*
  License with "MIT" (https://spdx.org/licenses/MIT.html)
  Copyright 2025 Aragubas. Check out https://aragubas.com 
  by Aragubas/Harley Sky Saphri at harleyskysaphri@gmail.com. Check out https://aragubas.com
*/

#if !TAIYOULOG_NO_REFLECTION
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
#endif
using Godot;

namespace TaiyouSimpleLog;

public static class Log {
  static readonly string s_DefaultDebugColor = "dimgray";
  static readonly string s_DefaultWarningColor = "orange";
  static readonly string s_DefaultErrorColor = "red";

  public static string DebugColor = s_DefaultDebugColor;
  public static string WarningColor = s_DefaultWarningColor;
  public static string ErrorColor = s_DefaultErrorColor;

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
  /// <param name="includeNamespace">If true, includes the whole namespace instead of just the name of the function</param>
  /// <param name="methodName">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling method</param> 
  /// <param name="className">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling class</param>
#if !TAIYOULOG_NO_REFLECTION
  [StackTraceHidden]
#endif
  public static void Debug(string message, bool includeNamespace = false, string methodName = "", string className = "") {
#if !TAIYOULOG_NO_REFLECTION
    // Colors colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color={DebugColor}]{MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)};[/color] {message}";
#else
    string printMessage = $"[color={DebugColor}]{MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)}; {message} [/color]";
#endif

    GD.PrintRich(printMessage);
#else
    // Colors colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color={DebugColor}]{MethodHeader(className, methodName)};[/color] {message}";
#else
    string printMessage = $"[color={DebugColor}]{MethodHeader(className, methodName)}; {message} [/color]";
#endif

    GD.PrintRich(printMessage);
#endif
  }

  /// <summary>
  /// Logs message into Godot's built in debugger (if TAIYOULOG_PRINTRICH or TAIYOULOG_WARNING_PRINTRICH is <b>not</b> defined) and into OS terminal
  /// </summary>
  /// <param name="message"></param>
  /// <param name="includeNamespace"></param>
  /// <param name="methodName">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling method</param> 
  /// <param name="className">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling class</param>
#if !TAIYOULOG_NO_REFLECTION
  [StackTraceHidden]
#endif
  public static void Warning(string message, bool includeNamespace = false, string methodName = "", string className = "") {
#if !TAIYOULOG_NO_REFLECTION
    //  If NO_REFLECTION is NOT set (default behavior)
#if TAIYOULOG_WARNING_PRINTRICH || TAIYOULOG_PRINTRICH

    // Colors colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color={WarningColor}] WARN {MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)};[/color] {message}";
#else
    string printMessage = $"[color={WarningColor}] WARN {MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)}; {message} [/color]";
#endif

    GD.PrintRich(printMessage);
#else
    GD.PushWarning($"{MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)}; {message}");
#endif

#else
    //  If NO_REFLECTION is set
#if TAIYOULOG_WARNING_PRINTRICH || TAIYOULOG_PRINTRICH

    // Colors! Colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color={WarningColor}] WARN {MethodHeader(className, methodName)};[/color] {message}";
#else
    string printMessage = $"[color={WarningColor}] WARN {MethodHeader(className, methodName)}; {message}[/color]";
#endif

    GD.PrintRich(printMessage);
#else
    GD.PushWarning($"{MethodHeader(className, methodName)}; {message}");
#endif
#endif
  }

  /// <summary>
  /// Logs message into standard error output (if TAIYOULOG_PRINTRICH or TAIYOULOG_ERROR_PRINTRICH is <b>not</b> defined) and into OS terminal
  /// </summary>
  /// <param name="message"></param>
  /// <param name="includeNamespace"></param>
  /// <param name="methodName">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling method</param> 
  /// <param name="className">(Only used if TAIYOULOG_NO_REFLECTION <b>is</b> defined) The name of the calling class</param>
 #if !TAIYOULOG_NO_REFLECTION
  [StackTraceHidden]
#endif
  public static void Error(string message, bool includeNamespace = false, string methodName = "", string className = "") {
#if !TAIYOULOG_NO_REFLECTION
    //  If NO_REFLECTION is NOT set (default behavior)
#if TAIYOULOG_ERROR_PRINTRICH || TAIYOULOG_PRINTRICH

    // Colors colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color=${ErrorColor}]ERROR {MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)};[/color] {message}";
#else
    string printMessage = $"[color={ErrorColor}]ERROR {MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)}; {message} [/color]";
#endif

    GD.PrintRich(printMessage);

#else
    GD.PushError($"{MethodHeader(new StackFrame(1).GetMethod(), includeNamespace)}; {message}");
#endif

#else
    //  If NO_REFLECTION is set
#if TAIYOULOG_ERROR_PRINTRICH || TAIYOULOG_PRINTRICH

    // Colors! Colors!
#if TAIYOULOG_NO_COLOR_MESSAGE
    string printMessage = $"[color={ErrorColor}]ERROR {MethodHeader(className, methodName)};[/color] {message}";
#else
    string printMessage = $"[color={ErrorColor}]ERROR {MethodHeader(className, methodName)}; {message}[/color]";
#endif

    GD.PrintRich(printMessage);
#else
    GD.PushError($"{MethodHeader(className, methodName)}; {message}");
#endif
#endif
  }

#if !TAIYOULOG_NO_REFLECTION
  /// <summary>
  /// Gets the name of the function called before this one and optionally the namespace
  /// </summary>
  /// <param name="methodBase">MethodBase reflection parameter</param>
  /// <param name="includeNamespace">If true, includes the name of the calling namespace</param>
  /// <returns></returns>
  [MethodImpl(MethodImplOptions.AggressiveInlining)]
  public static string MethodHeader(MethodBase methodBase, bool includeNamespace = false) {
    return $"{(includeNamespace ? methodBase.DeclaringType : methodBase.DeclaringType.Name)}::{methodBase.Name}";
  }
#else
  /// <summary>
  /// Returns a neatly formatted string with the className and methodName as if Reflection was available
  /// </summary>
  /// <param name="className">Name of the calling class (without namespace)</param>
  /// <param name="methodName">Name of the calling method</param>
  /// <returns>A neatly formatted string with className and methodName</returns>
  public static string MethodHeader(string className, string methodName)
    => $"{className}::{methodName}";
#endif
}