using System.Windows.Media;
using System.Windows.Media.Imaging;

using FluentAssertions;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Services;

using static QRCoder.QRCodeGenerator;

namespace QrCode.GeneratorTests.Services;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit testing.")]
public sealed class QrCodeServiceTests : UnitTestBase
{
  private readonly string _payload = "UnitTestPayLoad";
  private readonly int _moduleSize = 10;
  private readonly Color _foreground = Colors.Black;
  private readonly Color _background = Colors.White;
  private readonly ECCLevel _level = ECCLevel.Default;

  [TestMethod]
  public void CreateInstanceTest()
  {
    IQrCodeService? qrCodeService;

    qrCodeService = GetService<IQrCodeService>();

    qrCodeService.Should().NotBeNull();
  }

  [TestMethod]
  public void CreateBitmapTest()
  {
    QrCodeService service = new();

    BitmapSource result = service.CreateBitmap(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
  }

  [TestMethod]
  public void CreateDrawingTest()
  {
    QrCodeService service = new();

    DrawingImage result = service.CreateDrawing(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
  }

  [TestMethod]
  public void CreateBmpTest()
  {
    QrCodeService service = new();

    byte[] result = service.CreateBmp(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
    result.Should().NotBeEmpty();
  }

  [TestMethod]
  public void CreatePdfTest()
  {
    QrCodeService service = new();

    byte[] result = service.CreatePdf(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
    result.Should().NotBeEmpty();
  }

  [TestMethod]
  public void CreatePngTest()
  {
    QrCodeService service = new();

    byte[] result = service.CreatePng(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
    result.Should().NotBeEmpty();
  }

  [TestMethod]
  public void CreateSvgTest()
  {
    QrCodeService service = new();

    byte[] result = service.CreateSvg(_payload, _moduleSize, _foreground, _background, _level);

    result.Should().NotBeNull();
    result.Should().NotBeEmpty();
  }
}