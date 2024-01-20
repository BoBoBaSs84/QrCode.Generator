using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class EventCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    EventCodeControl ctrl;

    ctrl = GetService<EventCodeControl>();

    Assert.IsNotNull(ctrl);
  }
}