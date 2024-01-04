using System.Windows.Media;
using System.Windows.Media.Imaging;

using Net.Codecrete.QrCodeGenerator;

namespace WIFI.QRCode.Builder.Interfaces.Services;

/// <summary>
/// The QR-Code service interface.
/// </summary>
public interface IQrCodeService
{
  /// <summary>
  /// Create a bitmap for the specified QR code.
  /// </summary>
  /// <remarks>
  /// To achieve a crisp bitmap without any anti-aliasing, the bitmap is sized such
  /// that each QR code module is multiple pixels tall and wide.
  /// The resulting size depends on the QR code size;
  /// it is (qr-code-size + 2 * border-width) pixels tall and wide.
  /// </remarks>
  /// <param name="qrCode">The QR code.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="borderWidth">The width of the border around the QR code, in multiples of a single module (QR code pixel).</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <returns>The bitmap.</returns>
  BitmapSource CreateBitmapImage(QrCode qrCode, int moduleSize, int borderWidth, Color foreground, Color background);

  /// <summary>
  /// Create a resolution independent drawing for the specified QR code.
  /// </summary>
  /// <remarks>
  /// The drawing can be used as an image's source, or for printing.
  /// </remarks>
  /// <param name="qrCode">The QR code.</param>
  /// <param name="size">The width and height of the resulting drawing, including the border (in dip).</param>
  /// <param name="borderWidth">The width of the border, in multiples of a single module (QR code pixel)</param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  /// <returns>The device independent drawing.</returns>
  DrawingImage CreateDrawing(QrCode qrCode, double size, int borderWidth, Color foreground, Color background);
}
