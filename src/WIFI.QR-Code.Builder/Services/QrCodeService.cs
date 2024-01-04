using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Net.Codecrete.QrCodeGenerator;

using WIFI.QRCode.Builder.Interfaces;

namespace WIFI.QRCode.Builder.Services;

/// <summary>
/// The QR-Code service class.
/// </summary>
internal sealed class QrCodeService : IQrCodeService
{
  /// <summary>
  /// Create a resolution independent drawing for the specified QR code.
  /// <para>
  /// The drawing can be used as an image's source, or for printing.
  /// </para>
  /// </summary>
  /// <param name="qrCode">The QR code.</param>
  /// <param name="size">The width and height of the resulting drawing, including the border (in dip).</param>
  /// <param name="borderWidth">The width of the border, in multiples of a single module (QR code pixel)</param>
  /// <returns>The device independent drawing.</returns>
  public DrawingImage CreateDrawing(QrCode qrCode, double size, int borderWidth = 3)
    => CreateDrawing(qrCode, size, borderWidth, Colors.Black, Colors.White);

  /// <summary>
  /// Create a bitmap for the specified QR code.
  /// <para>
  /// To achieve a crisp bitmap without any anti-aliasing, the bitmap is sized such
  /// that each QR code module is multiple pixels tall and wide.
  /// The resulting size depends on the QR code size;
  /// it is (qr-code-size + 2 * border-width) pixels tall and wide.
  /// </para>
  /// </summary>
  /// <param name="qrCode">The QR code.</param>
  /// <param name="moduleSize">The size of each module (QR code pixel), in pixels</param>
  /// <param name="borderWidth">The width of the border around the QR code, in multiples of a single module (QR code pixel).</param>
  /// <returns>The bitmap.</returns>
  public BitmapSource CreateBitmapImage(QrCode qrCode, int moduleSize, int borderWidth = 3)
    => CreateBitmapImage(qrCode, moduleSize, borderWidth, Colors.Black, Colors.White);

  /// <inheritdoc cref="CreateDrawing(QrCode, double, int)"/>
  /// <param name="qrCode"></param>
  /// <param name="size"></param>
  /// <param name="borderWidth"></param>
  /// <param name="foreground">The foreground color to use.</param>
  /// <param name="background">The background color to use.</param>
  private static DrawingImage CreateDrawing(QrCode qrCode, double size, int borderWidth, Color foreground, Color? background)
  {
    DrawingGroup group = new();
    using (DrawingContext drawingContext = group.Open())
    {
      SolidColorBrush? backgroundBrush = background != null ? new SolidColorBrush((Color)background) : null;
      SolidColorBrush foregroundBrush = new(foreground);
      double scale = size / (qrCode.Size + (2 * borderWidth));
      drawingContext.PushTransform(new ScaleTransform(scale, scale));
      Draw(qrCode, drawingContext, borderWidth, foregroundBrush, backgroundBrush);
      drawingContext.Pop();
    }

    DrawingImage image = new(group);
    image.Freeze();
    return image;
  }

  /// <summary>
  /// Draws the QR code in the specified drawing context.
  /// <para>
  /// The QR code is drawn with the top left corner of the border at (0, 0).
  /// Each module (QR code pixel) will be drawn with 1 unit wide and tall.
  /// If a different position or size is desired, the drawing context's transformation
  /// matrix can be setup accordingly.
  /// </para>
  /// </summary>
  /// <param name="qrCode">The QR code.</param>
  /// <param name="drawingContext">The drawing context.</param>
  /// <param name="borderWidth"></param>
  /// <param name="foreground"></param>
  /// <param name="background"></param>
  private static void Draw(QrCode qrCode, DrawingContext drawingContext, int borderWidth, Brush foreground, Brush? background)
  {
    int size = qrCode.Size;

    // draw the background
    if (background != null)
      drawingContext.DrawRectangle(background, null, new Rect(0, 0, size + (2 * borderWidth), size + (2 * borderWidth)));

    // draw the modules
    for (int y = 0; y < size; y++)
    {
      for (int x = 0; x < size; x++)
      {
        if (qrCode.GetModule(x, y))
        {
          Rect rect = new(x + borderWidth, y + borderWidth, 1, 1);
          drawingContext.DrawRectangle(foreground, null, rect);
        }
      }
    }
  }

  /// <inheritdoc cref="CreateBitmapImage(QrCode, int, int)"/>
  /// <param name="qrCode"></param>
  /// <param name="moduleSize"></param>
  /// <param name="borderWidth"></param>
  /// <param name="foreground">The forground color.</param>
  /// <param name="background">The background color.</param>
  /// <returns>The bitmap.</returns>
  private static BitmapSource CreateBitmapImage(QrCode qrCode, int moduleSize, int borderWidth, Color foreground, Color background)
  {
    AliasedDrawingVisual drawingVisual = new();
    int size = qrCode.Size + (2 * borderWidth);

    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
    {
      SolidColorBrush foregroundBrush = new(foreground);
      SolidColorBrush backgroundBrush = new(background);
      drawingContext.PushTransform(new ScaleTransform(moduleSize, moduleSize));
      drawingContext.DrawRectangle(backgroundBrush, null, new Rect(0, 0, size, size));
      Draw(qrCode, drawingContext, borderWidth, foregroundBrush, null);
    }

    RenderTargetBitmap bitmap = new(size * moduleSize, size * moduleSize, 96, 96, PixelFormats.Pbgra32);
    bitmap.Render(drawingVisual);
    return bitmap;
  }

  /// <summary>
  /// Drawing visual using aliased edge mode.
  /// <para>
  /// This subclass is needed because the <c>VisualEdgeMode</c> property is protected
  /// and <see cref="RenderOptions"/> doesn't work for <c>DrawingVisual</c>.
  /// </para>
  /// </summary>
  private class AliasedDrawingVisual : DrawingVisual
  {
    public AliasedDrawingVisual()
      => VisualEdgeMode = EdgeMode.Aliased;
  }
}
