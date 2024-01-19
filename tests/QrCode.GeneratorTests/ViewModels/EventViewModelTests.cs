using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class EventViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void EventViewModelTest()
  {
    EventViewModel? viewModel;

    viewModel = GetService<EventViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.GetEncodingTypes.Length != 0);
  }
}