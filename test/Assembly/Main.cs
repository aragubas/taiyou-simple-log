using Godot;
using TaiyouSimpleLog;
using Test.UI;

namespace Test;

public partial class Main : Control {
  // Node References
  TestCard m_DebugPrint;
  TestCard m_WarningPrint;
  TestCard m_ErrorPrint;
  TestCard m_ObjDebugPrint;
  TestCard m_ObjWarningPrint;
  TestCard m_ObjErrorPrint;
  CheckButton m_NoColorMessages;
  CheckButton m_PrintRich;
  CheckButton m_PrintRichWarning;
  CheckButton m_PrintRichError;
  ColorPickerButton m_DebugColorPicker;
  ColorPickerButton m_WarningColorPicker;
  ColorPickerButton m_ErrorColorPicker;

  public override void _Ready() {
    // TestCards
    m_DebugPrint = GetNode<TestCard>("Center/VBox/TestCards/DebugPrint");
    m_WarningPrint = GetNode<TestCard>("Center/VBox/TestCards/WarningPrint");
    m_ErrorPrint = GetNode<TestCard>("Center/VBox/TestCards/ErrorPrint");
    m_ObjDebugPrint = GetNode<TestCard>("Center/VBox/TestCards/ObjDebugPrint");
    m_ObjWarningPrint = GetNode<TestCard>("Center/VBox/TestCards/ObjWarningPrint");
    m_ObjErrorPrint = GetNode<TestCard>("Center/VBox/TestCards/ObjErrorPrint");
    // Toggles
    m_NoColorMessages = GetNode<CheckButton>("Center/VBox/TogglesCenter/TogglesGrid/NoColorMessages");
    m_PrintRich = GetNode<CheckButton>("Center/VBox/TogglesCenter/TogglesGrid/PrintRich");
    m_PrintRichWarning = GetNode<CheckButton>("Center/VBox/TogglesCenter/TogglesGrid/PrintRichWarning");
    m_PrintRichError = GetNode<CheckButton>("Center/VBox/TogglesCenter/TogglesGrid/PrintRichError");
    // Color Pickers
    m_DebugColorPicker = GetNode<ColorPickerButton>("Center/VBox/ColorsCenter/ColorsGrid/DebugColor");
    m_WarningColorPicker = GetNode<ColorPickerButton>("Center/VBox/ColorsCenter/ColorsGrid/WarningColor");
    m_ErrorColorPicker = GetNode<ColorPickerButton>("Center/VBox/ColorsCenter/ColorsGrid/ErrorColor");
    // Color Reset Buttons
    GetNode<Button>("Center/VBox/ColorsCenter/ColorsGrid/ResetDebugColor").Pressed += ResetDebugColor;
    GetNode<Button>("Center/VBox/ColorsCenter/ColorsGrid/ResetWarningColor").Pressed += ResetWarningColor;
    GetNode<Button>("Center/VBox/ColorsCenter/ColorsGrid/ResetErrorColor").Pressed += ResetErrorColor;

    string testMessage = "Lorem Ipsum dolor sit amet";
    TestObject testObject = new();

    ///////////
    // Cards //
    ///////////
    m_DebugPrint.ButtonPressed += () => {
      Log.Debug(testMessage);
    };

    m_WarningPrint.ButtonPressed += () => {
      Log.Warning(testMessage);
    };

    m_ErrorPrint.ButtonPressed += () => {
      Log.Error(testMessage);
    };

    m_ObjDebugPrint.ButtonPressed += () => {
      Log.Debug(testObject);
    };

    m_ObjWarningPrint.ButtonPressed += () => {
      Log.Warning(testObject);
    };

    m_ObjErrorPrint.ButtonPressed += () => {
      Log.Error(testObject);
    };

    /////////////
    // Toggles //
    /////////////
    m_NoColorMessages.Toggled += (bool toggledOn) => {
      Log.NoColorMessages = toggledOn;
    };

    m_PrintRich.Toggled += (bool toggledOn) => {
      Log.PrintRich = toggledOn;
    };

    m_PrintRichWarning.Toggled += (bool toggledOn) => {
      Log.PrintRichWarning = toggledOn;
    };

    m_PrintRichError.Toggled += (bool toggledOn) => {
      Log.PrintRichError = toggledOn;
    };

    //////////////////
    // Color Picker //
    //////////////////
    m_DebugColorPicker.ColorChanged += (color) => {
      Log.DebugColor = color.ToHtml();
    };

    m_WarningColorPicker.ColorChanged += (color) => {
      Log.WarningColor = color.ToHtml();
    };

    m_ErrorColorPicker.ColorChanged += (color) => {
      Log.ErrorColor = color.ToHtml();
    };

    LoadDebugColor();
    LoadWarningColor();
    LoadErrorColor();
  }

  void LoadDebugColor() {
    m_DebugColorPicker.Color = Color.FromHtml(Log.DebugColor);
  }

  void LoadWarningColor() {
    m_WarningColorPicker.Color = Color.FromHtml(Log.WarningColor);
  }

  void LoadErrorColor() {
    m_ErrorColorPicker.Color = Color.FromHtml(Log.ErrorColor);
  }

  void ResetDebugColor() {
    Log.ResetDebugColor();
    LoadDebugColor();
  }

  void ResetWarningColor() {
    Log.ResetWarningColor();
    LoadWarningColor();
  }

  void ResetErrorColor() {
    Log.ResetErrorColor();
    LoadErrorColor();
  }
}
