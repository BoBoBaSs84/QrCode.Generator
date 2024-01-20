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