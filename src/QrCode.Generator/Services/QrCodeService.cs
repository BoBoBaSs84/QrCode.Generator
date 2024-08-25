using System.Drawing.Imaging;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;

using QRCoder;
using QRCoder.Xaml;

namespace QrCode.Generator.Services;

/// <summary>
/// The QR-Code service class.
/// </summary>
internal sealed class QrCodeService : IQrCodeService
{
  public BitmapSource CreateBitmap(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level)
  {
    QRCodeData codeData = CreateQrCodeData(payload, level);
    return CreateBitmap(codeData, moduleSize, foreground.GetHexString(), background.GetHexString());
  }

  public DrawingImage CreateDrawing(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level)
  {
    QRCodeData codeData = CreateQrCodeData(payload, level);
    return CreateDrawing(codeData, moduleSize, foreground.GetHexString(), background.GetHexString());
  }

  private static QRCodeData CreateQrCodeData(string payload, QRCodeGenerator.ECCLevel level)
  {
    QRCodeGenerator codeGenerator = new();
    return codeGenerator.CreateQrCode(payload, level);
  }

  private static BitmapSource CreateBitmap(QRCodeData codeData, int moduleSize, string darkColorHex, string lightColorHex)
  {
    QRCode code = new(codeData);
    return Convert(code.GetGraphic(moduleSize, darkColorHex, lightColorHex));
  }

  private static DrawingImage CreateDrawing(QRCodeData codeData, int moduleSize, string darkColorHex, string lightColorHex)
  {
    XamlQRCode xamlCode = new(codeData);
    return xamlCode.GetGraphic(moduleSize, darkColorHex, lightColorHex);
  }

  private static BitmapSource Convert(System.Drawing.Bitmap bitmap)
  {
    BitmapData bitmapData = bitmap.LockBits(
      rect: new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
      flags: ImageLockMode.ReadOnly,
      format: bitmap.PixelFormat
      );

    BitmapSource bitmapSource = BitmapSource.Create(
      pixelWidth: bitmapData.Width,
      pixelHeight: bitmapData.Height,
      dpiX: bitmap.HorizontalResolution,
      dpiY: bitmap.VerticalResolution,
      pixelFormat: PixelFormats.Bgra32, null,
      bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride
      );

    bitmap.UnlockBits(bitmapData);

    return bitmapSource;
  }
}
