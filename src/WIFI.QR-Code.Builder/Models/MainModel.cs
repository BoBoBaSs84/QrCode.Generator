using System.Windows.Media;

using BB84.Notifications;
using BB84.Notifications.Attributes;

using Net.Codecrete.QrCodeGenerator;

using WIFI.QRCode.Builder.Enumerators;

namespace WIFI.QRCode.Builder.Models;

/// <summary>
/// The main model class.
/// </summary>
public sealed class MainModel : NotifyPropertyBase
{
  private TransmissionType _transmission;
  private string _sSID;
  private string _password;
  private bool _hidden;
  private int _borderWidth;
  private QrCode.Ecc _errorCorrection;
  private Color _foregroundColor;
  private Color _backgroundColor;

  /// <summary>
  /// Initializes an instance of <see cref="MainModel"/> class.
  /// </summary>
  public MainModel()
  {
    _transmission = TransmissionType.WPA;
    _sSID = string.Empty;
    _password = string.Empty;
    _hidden = false;
    _borderWidth = 3;
    _errorCorrection = QrCode.Ecc.Medium;
    _foregroundColor = Colors.Black;
    _backgroundColor = Colors.White;
  }

  /// <summary>
  /// The transmission to use.
  /// </summary>
  [NotifyChanged(nameof(Value))]
  public TransmissionType Transmission { get => _transmission; set => SetProperty(ref _transmission, value); }

  /// <summary>
  /// The service set identifier.
  /// </summary>
  [NotifyChanged(nameof(Value))]
  public string SSID { get => _sSID; set => SetProperty(ref _sSID, value); }

  /// <summary>
  /// The password to use.
  /// </summary>
  [NotifyChanged(nameof(Value))]
  public string Password { get => _password; set => SetProperty(ref _password, value); }

  /// <summary>
  /// Is the wifi hidden?
  /// </summary>
  [NotifyChanged(nameof(Value))]
  public bool Hidden { get => _hidden; set => SetProperty(ref _hidden, value); }

  /// <summary>
  /// The border width of the QR code.
  /// </summary>
  public int BorderWidth { get => _borderWidth; set => SetProperty(ref _borderWidth, value); }

  /// <summary>
  /// The error correction level to use.
  /// </summary>
  public QrCode.Ecc ErrorCorrection { get => _errorCorrection; set => SetProperty(ref _errorCorrection, value); }

  /// <summary>
  /// The foreground color to use.
  /// </summary>
  public Color ForegroundColor { get => _foregroundColor; set => SetProperty(ref _foregroundColor, value); }

  /// <summary>
  /// The background color to use.
  /// </summary>
  public Color BackgroundColor { get => _backgroundColor; set => SetProperty(ref _backgroundColor, value); }

  /// <summary>
  /// The resulting qr code value.
  /// </summary>
  public string Value => $"WIFI:T:{Transmission};S:{SSID};P:{Password};H:{Hidden}";
}
