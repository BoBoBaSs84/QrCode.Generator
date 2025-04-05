// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.Services;

[TestClass]
public sealed class NavigationServiceTests : UnitTestBase
{
  [WpfTestMethod]
  public void NavigateToTest()
  {
    INavigationService? service = GetService<INavigationService>();

    service.NavigateTo<WifiCodeViewModel>();

    Assert.IsNotNull(service);
    Assert.IsInstanceOfType(service, typeof(INavigationService));
    Assert.IsInstanceOfType(service.CurrentView, typeof(WifiCodeViewModel));
  }
}