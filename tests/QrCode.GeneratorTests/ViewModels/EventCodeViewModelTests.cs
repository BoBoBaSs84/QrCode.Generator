using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class EventViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    EventCodeViewModel? viewModel;

    viewModel = GetService<EventCodeViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.GetEncodingTypes.Length != 0);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    IQrCodeService qrCodeService = GetService<IQrCodeService>();
    ITemplateService<EventCodeModel> templateService = GetService<ITemplateService<EventCodeModel>>();
    EventCodeViewModel viewModel = new(qrCodeService, templateService, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}