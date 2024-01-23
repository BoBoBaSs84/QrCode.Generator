using QrCode.Generator.Interfaces.Services;
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
    IQrCodeService service = GetService<IQrCodeService>();
    ContactDataViewModel viewModel = new(service, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}