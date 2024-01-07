using BB84.Notifications.Attributes;

using QRCoder;

using WIFI.QRCode.Builder.Models.Base;

using static QRCoder.PayloadGenerator.WiFi;

namespace WIFI.QRCode.Builder.Models;

/// <summary>
/// The main model class.
/// </summary>
public sealed class WifiModel : QrCodeModel
{
  private Authentication _authentication;
  private string _sSID;
  private string _password;
  private bool _hidden;

  /// <summary>
  /// Initializes an instance of <see cref="WifiModel"/> class.
  /// </summary>
  public WifiModel()
  {
    _authentication = Authentication.WPA;
    _sSID = string.Empty;
    _password = string.Empty;
    _hidden = false;
  }

  /// <summary>
  /// The authentication mode to use.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public Authentication Authentication { get => _authentication; set => SetProperty(ref _authentication, value); }

  /// <summary>
  /// The service set identifier.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public string SSID { get => _sSID; set => SetProperty(ref _sSID, value); }

  /// <summary>
  /// The password to use.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public string Password { get => _password; set => SetProperty(ref _password, value); }

  /// <summary>
  /// Is the wifi hidden?
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public bool Hidden { get => _hidden; set => SetProperty(ref _hidden, value); }

  /// <inheritdoc cref="QrCodeModel.PayLoad"/>
  public override string PayLoad => GetPayLoad();

  private string GetPayLoad()
  {
    PayloadGenerator.WiFi generator = new(SSID, Password, Authentication, Hidden);
    return generator.ToString();
  }
}
