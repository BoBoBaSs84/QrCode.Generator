using System.ComponentModel.DataAnnotations;

using BB84.Extensions;

using QrCode.Generator.Models.Base;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.Generator.Models;

/// <summary>
/// The main model class.
/// </summary>
public sealed class WifiCodeModel : QrCodeModel
{
  private Authentication _authentication;
  private string _sSID;
  private string _password;
  private bool _hidden;
  private bool _isValid;

  /// <summary>
  /// Initializes an instance of <see cref="WifiCodeModel"/> class.
  /// </summary>
  public WifiCodeModel()
  {
    _authentication = Authentication.WPA;
    _sSID = string.Empty;
    _password = string.Empty;
    _hidden = false;

    PropertyChanged += (s, e) =>
    {
      if (e.PropertyName != nameof(IsValid))
        IsValid = HasErrors.IsFalse();
    };
  }

  /// <summary>
  /// The authentication mode to use.
  /// </summary>
  public Authentication Authentication
  {
    get => _authentication;
    set => SetProperty(ref _authentication, value);
  }

  /// <summary>
  /// The service set identifier.
  /// </summary>
  [Required]
  public string SSID
  {
    get => _sSID;
    set => SetPropertyAndValidate(ref _sSID, value);
  }

  /// <summary>
  /// The password to use.
  /// </summary>
  public string Password
  {
    get => _password;
    set => SetProperty(ref _password, value);
  }

  /// <summary>
  /// Is the wifi hidden?
  /// </summary>
  public bool Hidden
  {
    get => _hidden;
    set => SetProperty(ref _hidden, value);
  }

  /// <inheritdoc/>
  public override bool IsValid
  {
    get => _isValid;
    protected set => SetProperty(ref _isValid, value);
  }
}
