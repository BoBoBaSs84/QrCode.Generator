using QrCode.Generator.Interfaces.Services;
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
    IQrCodeService service = GetService<IQrCodeService>();
    EventCodeViewModel viewModel = new(service, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}