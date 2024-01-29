using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class ContactDataControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    ContactDataControl? control;

    control = GetService<ContactDataControl>();

    Assert.IsNotNull(control);
  }
}