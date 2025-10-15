// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;
using QrCode.Generator.ViewModels.Base;

using static QRCoder.QRCodeGenerator;

namespace QrCode.GeneratorTests.ViewModels.Base;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit testing.")]
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
    Assert.IsNotEmpty(viewModel.ErrorCorrectionLevels);
    Assert.IsNotEmpty(viewModel.ExportTypes);
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
    _qrCodeServiceMock.Setup(x => x.CreateBitmap(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<Color>(), It.IsAny<Color>(), It.IsAny<ECCLevel>()))
      .Returns(BitmapSource.Create(1, 1, 1, 1, PixelFormats.Gray8, null, new byte[4], 1));

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
    TestModel testModel = new();
    TestViewModel viewModel = CreateMockedInstance();
    _templateServiceMock.Setup(x => x.From(It.IsAny<string>()))
      .Returns(testModel);

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

  private TestViewModel CreateMockedInstance(TestModel? model = null)
  {
    _qrCodeServiceMock = new();
    _exportServiceMock = new();
    _templateServiceMock = new();

    return new(_qrCodeServiceMock.Object, _exportServiceMock.Object, _templateServiceMock.Object, model ?? new());
  }

  internal sealed class TestViewModel(IQrCodeService service, IExportService<TestModel> exportService, ITemplateService<TestModel> templateService, TestModel model)
    : QrCodeViewModel<TestModel>(service, exportService, templateService, model)
  {
    protected override void Export()
    {
      ExportPath = UnitTest;
      base.Export();
    }

    protected override void LoadTemplate(TestModel model)
    {
      LoadPath = UnitTest;
      base.LoadTemplate(model);
    }

    protected override void SaveTemplate(TestModel model)
    {
      SavePath = UnitTest;
      base.SaveTemplate(model);
    }

    protected override void SetPayLoad()
      => Payload = UnitTest;
  }

  internal sealed class TestModel : QrCodeModel
  { }
}