namespace Test;

public class TestObject {
  string m_InternalString;


  public TestObject() {
    m_InternalString = "This is the internal string";
  }

  public override string ToString() {
    return $"TestObject custom ToString method. The internal string is: \"{m_InternalString}\"";
  }
}