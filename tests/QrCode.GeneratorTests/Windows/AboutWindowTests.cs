using QrCode.Generator.ViewModels;
using QrCode.Generator.Windows;

namespace QrCode.GeneratorTests.Windows;

[TestClass]
public sealed class AboutWindowTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    AboutWindow? aboutWindow;

    aboutWindow = GetService<AboutWindow>();

    Assert.IsNotNull(aboutWindow);
    Assert.IsInstanceOfType(aboutWindow.DataContext, typeof(AboutViewModel));
  }
}