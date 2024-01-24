using System.Windows.Media;

using BB84.Extensions;
using BB84.Notifications;

using static QRCoder.QRCodeGenerator;

namespace QrCode.Generator.Models.Base;

/// <summary>
/// The qr code model class.
/// </summary>
public abstract class QrCodeModel : ValidatableObject
{
  private ECCLevel _errorCorrection;
  private Color _foregroundColor;
  private Color _backgroundColor;

  /// <summary>
  /// Initializes an instance of <see cref="QrCodeModel"/> class.
  /// </summary>
  public QrCodeModel()
  {
    _errorCorrection = ECCLevel.M;
    _foregroundColor = Colors.Black;
    _backgroundColor = Colors.White;
  }

  /// <summary>
  /// The error correction level to use.
  /// </summary>
  public ECCLevel ErrorCorrection
  {
    get => _errorCorrection;
    set => SetProperty(ref _errorCorrection, value);
  }

  /// <summary>
  /// The foreground color to use.
  /// </summary>
  public Color ForegroundColor
  {
    get => _foregroundColor;
    set => SetProperty(ref _foregroundColor, value);
  }

  /// <summary>
  /// The background color to use.
  /// </summary>
  public Color BackgroundColor
  {
    get => _backgroundColor;
    set => SetProperty(ref _backgroundColor, value);
  }

  /// <summary>
  /// Is the model valid for processing?
  /// </summary>
  public bool IsValid => HasErrors.IsFalse();
}
