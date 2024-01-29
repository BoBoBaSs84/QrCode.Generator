using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class AboutControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    AboutControl? control;

    control = GetService<AboutControl>();

    Assert.IsNotNull(control);
  }
}
