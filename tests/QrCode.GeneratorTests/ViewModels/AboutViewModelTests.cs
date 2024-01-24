using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class AboutViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void AboutViewModelTest()
  {
    AboutViewModel? viewModel;

    viewModel = GetService<AboutViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
  }
}