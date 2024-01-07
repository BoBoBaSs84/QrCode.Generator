using System.Windows.Media;

using BB84.Notifications;

using static QRCoder.QRCodeGenerator;

namespace WIFI.QRCode.Builder.Models.Base;

/// <summary>
/// The qr code model class.
/// </summary>
public abstract class QrCodeModel : NotifyPropertyBase
{
  private ECCLevel _errorCorrection;
  private Color _foregroundColor;
  private Color _backgroundColor;
  private bool _drawQuietZones;

  /// <summary>
  /// Initializes an instance of <see cref="QrCodeModel"/> class.
  /// </summary>
  public QrCodeModel()
  {
    _errorCorrection = ECCLevel.M;
    _foregroundColor = Colors.Black;
    _backgroundColor = Colors.White;
    _drawQuietZones = true;
  }

  /// <summary>
  /// The error correction level to use.
  /// </summary>
  public ECCLevel ErrorCorrection { get => _errorCorrection; set => SetProperty(ref _errorCorrection, value); }

  /// <summary>
  /// The foreground color to use.
  /// </summary>
  public Color ForegroundColor { get => _foregroundColor; set => SetProperty(ref _foregroundColor, value); }

  /// <summary>
  /// The background color to use.
  /// </summary>
  public Color BackgroundColor { get => _backgroundColor; set => SetProperty(ref _backgroundColor, value); }

  /// <summary>
  /// Should the qr code have borders?
  /// </summary>
  public bool DrawQuietZones { get => _drawQuietZones; set => SetProperty(ref _drawQuietZones, value); }

  /// <summary>
  /// The resulting qr code payload data value.
  /// </summary>
  public abstract string PayLoad {  get; }
}
