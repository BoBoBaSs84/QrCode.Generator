using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class WifiCodeViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    WifiCodeViewModel? viewModel;

    viewModel = GetService<WifiCodeViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.AuthenticationTypes.Length != 0);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<ITemplateService<WifiCodeModel>> templateServiceMock = new();
    WifiCodeViewModel viewModel = new(qrCodeServiceMock.Object, templateServiceMock.Object, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}