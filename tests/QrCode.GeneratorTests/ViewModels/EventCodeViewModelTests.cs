using Moq;

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
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<ITemplateService<EventCodeModel>> templateServiceMock = new();
    EventCodeViewModel viewModel = new(qrCodeServiceMock.Object, templateServiceMock.Object, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}