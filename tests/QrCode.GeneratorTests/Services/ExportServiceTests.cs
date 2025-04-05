// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Microsoft.Extensions.Logging;

using Moq;

using QrCode.Generator.Enumerators;
using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;
using QrCode.Generator.Services;

namespace QrCode.GeneratorTests.Services;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit testing.")]
public sealed class ExportServiceTests : UnitTestBase
{
  private Mock<ILoggerService<ExportService<TestClass>>> _loggerServiceMock = default!;
  private Mock<IQrCodeService> _qrCodeServiceMock = default!;
  private Mock<IFileProvider> _fileProviderMock = default!;

  [TestMethod]
  public void ExportJpegExceptionTest()
  {
    ExportService<TestClass> sut = CreateMockedInstance();

    Assert.ThrowsException<NotImplementedException>(() => sut.Export(string.Empty, ExportType.JPEG, string.Empty, new()));

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<NotImplementedException>()), Times.Once);
  }

  [TestMethod]
  public void ExportBmpSuccessTest()
  {
    TestClass testClass = new();
    ExportService<TestClass> sut = CreateMockedInstance();
    _qrCodeServiceMock.Setup(x => x.CreateBmp(It.IsAny<string>(), It.IsAny<int>(), testClass.ForegroundColor, testClass.BackgroundColor, testClass.ErrorCorrection))
      .Returns([]);

    sut.Export(string.Empty, ExportType.BMP, string.Empty, testClass);

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<InvalidOperationException>()), Times.Never);
  }

  [TestMethod]
  public void ExportPdfSuccessTest()
  {
    TestClass testClass = new();
    ExportService<TestClass> sut = CreateMockedInstance();
    _qrCodeServiceMock.Setup(x => x.CreatePdf(It.IsAny<string>(), It.IsAny<int>(), testClass.ForegroundColor, testClass.BackgroundColor, testClass.ErrorCorrection))
      .Returns([]);

    sut.Export(string.Empty, ExportType.PDF, string.Empty, testClass);

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<InvalidOperationException>()), Times.Never);
  }

  [TestMethod]
  public void ExportPngSuccessTest()
  {
    TestClass testClass = new();
    ExportService<TestClass> sut = CreateMockedInstance();
    _qrCodeServiceMock.Setup(x => x.CreatePng(It.IsAny<string>(), It.IsAny<int>(), testClass.ForegroundColor, testClass.BackgroundColor, testClass.ErrorCorrection))
      .Returns([]);

    sut.Export(string.Empty, ExportType.PNG, string.Empty, testClass);

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<InvalidOperationException>()), Times.Never);
  }

  [TestMethod]
  public void ExportSvgSuccessTest()
  {
    TestClass testClass = new();
    ExportService<TestClass> sut = CreateMockedInstance();
    _qrCodeServiceMock.Setup(x => x.CreateSvg(It.IsAny<string>(), It.IsAny<int>(), testClass.ForegroundColor, testClass.BackgroundColor, testClass.ErrorCorrection))
      .Returns([]);

    sut.Export(string.Empty, ExportType.SVG, string.Empty, testClass);

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<InvalidOperationException>()), Times.Never);
  }

  private ExportService<TestClass> CreateMockedInstance()
  {
    _loggerServiceMock = new();
    _qrCodeServiceMock = new();
    _fileProviderMock = new();

    return new(_loggerServiceMock.Object, _qrCodeServiceMock.Object, _fileProviderMock.Object);
  }

  internal sealed class TestClass : QrCodeModel
  { }
}