using QrCode.Generator.ViewModels;
using QrCode.Generator.Windows;

namespace QrCode.GeneratorTests.Windows;

[TestClass]
public sealed class MainWindowTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    MainWindow? mainWindow;

    mainWindow = GetService<MainWindow>();

    Assert.IsNotNull(mainWindow);
    Assert.IsInstanceOfType(mainWindow.DataContext, typeof(MainViewModel));
  }
}