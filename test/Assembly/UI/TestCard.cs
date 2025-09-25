using Godot;

namespace Test.UI;

public partial class TestCard : MarginContainer {
  // Public Properties
  [Export(PropertyHint.MultilineText)]
  string _title;
  public string Title {
    get => _title;
    set {
      if (_title == value) return;
      _title = value;
      TitleChanged(value);
    }
  }


  // Signals
  [Signal] public delegate void ButtonPressedEventHandler();


  // Node References
  Label m_Label;
  Button m_Button;

  public override void _Ready() {
    m_Label = GetNode<Label>("Padding/VBox/Label");
    m_Button = GetNode<Button>("Padding/VBox/Button");

    m_Button.Pressed += () => {
      EmitSignal(SignalName.ButtonPressed);
    };

    TitleChanged(Title);
  }

  void TitleChanged(string newTitle) {
    m_Label.Text = newTitle;
  }

}
