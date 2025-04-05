// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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