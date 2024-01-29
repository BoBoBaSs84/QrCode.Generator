using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class GiroCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    GiroCodeControl control;

    control = GetService<GiroCodeControl>();

    Assert.IsNotNull(control);
  }
}