using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class WifiCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    WifiCodeControl ctrl;

    ctrl = GetService<WifiCodeControl>();

    Assert.IsNotNull(ctrl);
  }
}