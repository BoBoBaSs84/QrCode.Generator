using BB84.Notifications;
using BB84.Notifications.Attributes;

using Net.Codecrete.QrCodeGenerator;

namespace WIFI.QRCode.Builder.ViewModels;

public sealed class MainViewModel : NotifyPropertyBase
{
  private TransmissionType _transmission;
  private string _sSID;
  private string _password;
  private bool _hidden;
  private int _borderWidth;
  private QrCode.Ecc _errorCorrection;

  public MainViewModel()
  {
    _transmission = TransmissionType.WPA;
    _sSID = string.Empty;
    _password = string.Empty;
    _hidden = false;
    _borderWidth = 3;
    _errorCorrection = QrCode.Ecc.Medium;
  }

  [NotifyChanged(nameof(Text))]
  public TransmissionType Transmission { get => _transmission; set => SetProperty(ref _transmission, value); }

  [NotifyChanged(nameof(Text))]
  public string SSID { get => _sSID; set => SetProperty(ref _sSID, value); }

  [NotifyChanged(nameof(Text))]
  public string Password { get => _password; set => SetProperty(ref _password, value); }

  [NotifyChanged(nameof(Text))]
  public bool Hidden { get => _hidden; set => SetProperty(ref _hidden, value); }

  public int BorderWidth { get => _borderWidth; set => SetProperty(ref _borderWidth, value); }

  public QrCode.Ecc ErrorCorrection { get => _errorCorrection; set => SetProperty(ref _errorCorrection, value); }

  public string Text => $"WIFI:T:{Transmission};S:{SSID};P:{Password};H:{Hidden}";

  public Tuple<string, QrCode.Ecc>[] ErrorCorrectionLevels { get; } = [
    new Tuple<string, QrCode.Ecc>("Low", QrCode.Ecc.Low),
    new Tuple<string, QrCode.Ecc>("Medium", QrCode.Ecc.Medium),
    new Tuple<string, QrCode.Ecc>("Quartile", QrCode.Ecc.Quartile),
    new Tuple<string, QrCode.Ecc>("High", QrCode.Ecc.High)
  ];

  public Tuple<string, TransmissionType>[] TransmissionTypes { get; } = [
    new("nopass", TransmissionType.NOPASS),
    new("WPA", TransmissionType.WPA),
    new("WEP", TransmissionType.WEP)
    ];

  public enum TransmissionType
  {
    NOPASS = 0,
    WPA = 1,
    WEP = 2,
  }
}

