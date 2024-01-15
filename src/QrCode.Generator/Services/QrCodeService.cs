using System.Windows.Media;
using System.Windows.Media.Imaging;

using QRCoder;
using QRCoder.Xaml;

using WIFI.QRCode.Builder.Extensions;
using WIFI.QRCode.Builder.Interfaces.Services;

namespace WIFI.QRCode.Builder.Services;

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
    QRCoder.QRCode code = new(codeData);
    return Convert(code.GetGraphic(moduleSize, darkColorHex, lightColorHex));
  }

  private static DrawingImage CreateDrawing(QRCodeData codeData, int moduleSize, string darkColorHex, string lightColorHex)
  {
    XamlQRCode xamlCode = new(codeData);
    return xamlCode.GetGraphic(moduleSize, darkColorHex, lightColorHex);
  }

  private static BitmapSource Convert(System.Drawing.Bitmap bitmap)
  {
    System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(
      new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
      System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat
      );

    BitmapSource bitmapSource = BitmapSource.Create(
      bitmapData.Width, bitmapData.Height,
      bitmap.HorizontalResolution, bitmap.VerticalResolution,
      PixelFormats.Bgr24, null,
      bitmapData.Scan0, bitmapData.Stride * bitmapData.Height, bitmapData.Stride
      );

    bitmap.UnlockBits(bitmapData);

    return bitmapSource;
  }
}
