using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class MainViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void MainViewModelTest()
  {
    MainViewModel? viewModel;

    viewModel = GetService<MainViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.AboutCommand);
    Assert.IsNotNull(viewModel.ContactDataCommand);
    Assert.IsNotNull(viewModel.EventCommand);
    Assert.IsNotNull(viewModel.ExitCommand);
    Assert.IsNotNull(viewModel.GiroCommand);
    Assert.IsNotNull(viewModel.NavigationService);
    Assert.IsNotNull(viewModel.WifiCommand);
  }
}