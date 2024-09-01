using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.GeneratorTests.ViewModels.Base;

[TestClass]
public sealed class QrCodeViewModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";
  private Mock<IQrCodeService> _qrCodeServiceMock = default!;
  private Mock<IExportService<TestModel>> _exportServiceMock = default!;
  private Mock<ITemplateService<TestModel>> _templateServiceMock = default!;

  [WpfTestMethod]
  public void ConstructorTest()
  {
    TestViewModel? viewModel;

    viewModel = CreateMockedInstance();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.CreateCommand);
    Assert.IsNotNull(viewModel.CopyCommand);
    Assert.IsNotNull(viewModel.ExportCommand);
    Assert.IsNotNull(viewModel.LoadTemplateCommand);
    Assert.IsNotNull(viewModel.SaveTemplateCommand);
    Assert.IsTrue(viewModel.ErrorCorrectionLevels.Length != 0);
    Assert.IsTrue(viewModel.ExportTypes.Length != 0);
  }

  [WpfTestMethod]
  public void CreateCommandTest()
  {
    TestViewModel viewModel = CreateMockedInstance();

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  [WpfTestMethod]
  public void CopyCommandTest()
  {
    TestViewModel viewModel = CreateMockedInstance();

    viewModel.CopyCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  [WpfTestMethod]
  public void ExportCommandTest()
  {
    TestViewModel viewModel = CreateMockedInstance();

    viewModel.ExportCommand.Execute();

    Assert.AreEqual(UnitTest, viewModel.ExportPath);
  }

  [WpfTestMethod]
  public void LoadTemplateCommandTest()
  {
    TestViewModel viewModel = CreateMockedInstance();

    viewModel.LoadTemplateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.LoadPath);
  }

  [WpfTestMethod]
  public void SaveTemplateCommandTest()
  {
    TestViewModel viewModel = CreateMockedInstance();

    viewModel.SaveTemplateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.SavePath);
  }

  private TestViewModel CreateMockedInstance()
  {
    _qrCodeServiceMock = new();
    _exportServiceMock = new();
    _templateServiceMock = new();

    return new(_qrCodeServiceMock.Object, _exportServiceMock.Object, _templateServiceMock.Object, new());
  }

  internal sealed class TestViewModel(IQrCodeService service, IExportService<TestModel> exportService, ITemplateService<TestModel> templateService, TestModel model)
    : QrCodeViewModel<TestModel>(service, exportService, templateService, model)
  {
    protected override void Export()
      => ExportPath = UnitTest;

    protected override void LoadTemplate(TestModel model)
      => LoadPath = UnitTest;

    protected override void SaveTemplate(TestModel model)
      => SavePath = UnitTest;

    protected override void SetPayLoad()
      => Payload = UnitTest;
  }

  internal sealed class TestModel : QrCodeModel
  { }
}