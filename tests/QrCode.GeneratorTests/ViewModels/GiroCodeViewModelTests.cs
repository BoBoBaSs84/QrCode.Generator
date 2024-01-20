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
    IQrCodeService service = GetService<IQrCodeService>();
    GiroCodeModel model = new()
    {
      IBAN = "DE33100205000001194700",
      BIC = "BFSWDE33BER",
      Name = "Wikimedia",
      Amount = 1337.99m
    };
    GiroCodeViewModel viewModel = new(service, model);

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}