using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class GiroCodeViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    GiroCodeViewModel? viewModel;

    viewModel = GetService<GiroCodeViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.EncodingTypes.Length != 0);
    Assert.IsTrue(viewModel.ReferenceTypes.Length != 0);
    Assert.IsTrue(viewModel.VersionTypes.Length != 0);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<IExportService<GiroCodeModel>> exportServiceMock = new();
    Mock<ITemplateService<GiroCodeModel>> templateServiceMock = new();
    GiroCodeModel model = new()
    {
      IBAN = "DE33100205000001194700",
      BIC = "BFSWDE33BER",
      Name = "Wikimedia",
      Amount = 14.99m
    };
    GiroCodeViewModel viewModel = new(qrCodeServiceMock.Object, exportServiceMock.Object, templateServiceMock.Object, model);

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}