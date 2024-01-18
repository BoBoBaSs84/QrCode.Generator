using BB84.Extensions;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using QRCoder;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The wifi qr code view model class.
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class WifiViewModel(IQrCodeService qrCodeService, WifiModel model) : QrCodeViewModel(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public WifiModel Model { get; } = model;

  /// <summary>
  /// The authentication types to select from.
  /// </summary>
  public Tuple<string, Authentication>[] AuthenticationTypes
    => Model.Authentication.GetValues().AsTuple();

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    PayloadGenerator.WiFi generator = new(Model.SSID, Model.Password, Model.Authentication, Model.Hidden);
    Payload = generator.ToString();
  }
}
