using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

using Net.Codecrete.QrCodeGenerator;

using WIFI.QRCode.Builder.Interfaces.Services;

namespace WIFI.QRCode.Builder.Services;

/// <summary>
/// The QR-Code service class.
/// </summary>
internal sealed class QrCodeService : IQrCodeService
{
  /// <inheritdoc cref="IQrCodeService.CreateBitmapImage(QrCode, int, int, Color, Color)"/>
  public BitmapSource CreateBitmapImage(QrCode qrCode, int moduleSize, int borderWidth, Color foreground, Color background)
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

  /// <inheritdoc cref="IQrCodeService.CreateDrawing(QrCode, double, int, Color, Color)"/>
  public DrawingImage CreateDrawing(QrCode qrCode, double size, int borderWidth, Color foreground, Color background)
  {
    DrawingGroup group = new();
    using (DrawingContext drawingContext = group.Open())
    {
      SolidColorBrush backgroundBrush = new(background);
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
  /// </summary>
  /// <remarks>
  /// The QR code is drawn with the top left corner of the border at (0, 0).
  /// Each module (QR code pixel) will be drawn with 1 unit wide and tall.
  /// If a different position or size is desired, the drawing context's transformation
  /// matrix can be setup accordingly.
  /// </remarks>
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

  /// <summary>
  /// Drawing visual using aliased edge mode.
  /// </summary>
  /// <remarks>
  /// This subclass is needed because the <c>VisualEdgeMode</c> property is protected
  /// and <see cref="RenderOptions"/> doesn't work for <c>DrawingVisual</c>.
  /// </remarks>
  private class AliasedDrawingVisual : DrawingVisual
  {
    public AliasedDrawingVisual()
      => VisualEdgeMode = EdgeMode.Aliased;
  }
}
