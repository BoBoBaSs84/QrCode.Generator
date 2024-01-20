using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class GiroCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    GiroCodeControl ctrl;

    ctrl = GetService<GiroCodeControl>();

    Assert.IsNotNull(ctrl);
  }
}