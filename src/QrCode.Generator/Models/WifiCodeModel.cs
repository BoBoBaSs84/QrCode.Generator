// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

using QrCode.Generator.Models.Base;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.Generator.Models;

/// <summary>
/// The main model class.
/// </summary>
public sealed class WifiCodeModel : QrCodeModel
{
  private Authentication _authentication;
  private string _ssid;
  private string _password;
  private bool _hidden;

  /// <summary>
  /// Initializes an instance of <see cref="WifiCodeModel"/> class.
  /// </summary>
  public WifiCodeModel()
  {
    _authentication = Authentication.WPA;
    _ssid = string.Empty;
    _password = string.Empty;
    _hidden = false;
  }

  /// <summary>
  /// The authentication mode to use.
  /// </summary>
  [Required]
  public Authentication Authentication
  {
    get => _authentication;
    set => SetPropertyAndValidate(ref _authentication, value);
  }

  /// <summary>
  /// The service set identifier.
  /// </summary>
  [Required]
  public string SSID
  {
    get => _ssid;
    set => SetPropertyAndValidate(ref _ssid, value);
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
  public override void FromTemplate(QrCodeModel template)
  {
    if (template is WifiCodeModel wifiCodeModel)
    {
      Authentication = wifiCodeModel.Authentication;
      SSID = wifiCodeModel.SSID;
      Password = wifiCodeModel.Password;
      Hidden = wifiCodeModel.Hidden;
    }

    base.FromTemplate(template);
  }
}
