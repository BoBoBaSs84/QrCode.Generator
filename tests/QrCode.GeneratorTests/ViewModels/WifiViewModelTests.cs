using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class WifiViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void WifiViewModelTest()
  {
    WifiViewModel? viewModel;

    viewModel = GetService<WifiViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.AuthenticationTypes.Length != 0);
  }
}