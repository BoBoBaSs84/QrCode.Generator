using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.WiFi;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a WiFi QR code.
/// </summary>
public sealed class WifiCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the authentication mode to use.
  /// </summary>
  [Required] public required Authentication Authentication { get; init; }

  /// <summary>
  /// Gets or sets the service set identifier.
  /// </summary>
  [Required, MaxLength(32)] public required string SSID { get; init; }

  /// <summary>
  /// Gets or sets the password.
  /// </summary>
  [Required, MaxLength(64)] public required string Password { get; init; }

  /// <summary>
  /// Gets or sets a value indicating whether the network is hidden.
  /// </summary>
  public bool Hidden { get; init; }
}
