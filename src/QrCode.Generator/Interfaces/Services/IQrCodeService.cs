using System.Windows.Media;
using System.Windows.Media.Imaging;

using QRCoder;

namespace WIFI.QRCode.Builder.Interfaces.Services;

/// <summary>
/// The QR-Code service interface.
/// </summary>
public interface IQrCodeService
{

  /// <summary>
  /// Create a bitmap for the specified qr code payload.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The qr code abitmap.</returns>
  BitmapSource CreateBitmap(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);

  /// <summary>
  /// Create a resolution independent drawing for the specified qr code.
  /// </summary>
  /// <param name="payload">The qr code payload.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <param name="level">The level of error correction to use.</param>
  /// <returns>The device independent drawing.</returns>
  DrawingImage CreateDrawing(string payload, int moduleSize, Color foreground, Color background, QRCodeGenerator.ECCLevel level);
}
