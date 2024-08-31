using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.GeneratorTests.ViewModels.Base;

[TestClass]
public sealed class QrCodeViewModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";

  [WpfTestMethod]
  public void ConstructorTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel? viewModel;

    viewModel = new(service, new());

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.CreateCommand);
    Assert.IsNotNull(viewModel.CopyCommand);
    Assert.IsTrue(viewModel.ErrorCorrectionLevels.Length != 0);
  }

  [WpfTestMethod]
  public void CreateCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  [WpfTestMethod]
  public void CopyCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service, new());

    viewModel.CopyCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  [WpfTestMethod]
  public void LoadTemplateCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service, new());

    viewModel.LoadTemplateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.LoadPath);
  }

  [WpfTestMethod]
  public void SaveTemplateCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service, new());

    viewModel.SaveTemplateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.SavePath);
  }

  private sealed class TestViewModel(IQrCodeService service, TestModel model) : QrCodeViewModel<TestModel>(service, model)
  {
    public override void LoadTemplate(TestModel model)
      => LoadPath = UnitTest;

    public override void SaveTemplate(TestModel model)
      => SavePath = UnitTest;

    protected override void SetPayLoad()
      => Payload = UnitTest;
  }

  private sealed class TestModel : QrCodeModel
  { }
}