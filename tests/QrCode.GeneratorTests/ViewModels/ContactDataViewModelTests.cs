using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class ContactDataViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    ContactDataViewModel? viewModel;

    viewModel = GetService<ContactDataViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.AddressOrderTypes.Length != 0);
    Assert.IsTrue(viewModel.ContactOutputTypes.Length != 0);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<ITemplateService<ContactDataModel>> templateServiceMock = new();
    ContactDataViewModel viewModel = new(qrCodeServiceMock.Object, templateServiceMock.Object, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}