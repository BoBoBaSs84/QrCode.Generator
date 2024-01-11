using BB84.Extensions;

using QRCoder;

using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.ViewModels.Base;

using static QRCoder.PayloadGenerator.WiFi;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The wifi qr code view model class.
/// </summary>
public sealed class WifiViewModel : QrCodeViewModel
{
  private readonly IQrCodeService _qrCodeService;
  private bool _isModelValid;

  /// <summary>
  /// Initializes an instance of <see cref="WifiViewModel"/> class.
  /// </summary>
  /// <param name="qrCodeService">The qr code service instance to use.</param>
  /// <param name="model">The model instance to use.</param>
  public WifiViewModel(IQrCodeService qrCodeService, WifiModel model) : base(qrCodeService)
  {
    _qrCodeService = qrCodeService;
    Model = model;
    Model.PropertyChanged += (s, e) => OnModelPropertyChanged();
  }

  /// <summary>
  /// The model instance to use.
  /// </summary>
  public WifiModel Model { get; }

  /// <summary>
  /// The authentication types to select from.
  /// </summary>
  public Tuple<string, Authentication>[] AuthenticationTypes
    => [new("nopass", Authentication.nopass), new("WPA", Authentication.WPA), new("WEP", Authentication.WEP)];

  /// <inheritdoc/>
  public override bool IsModelValid { get => _isModelValid; protected set => _isModelValid = value; }


  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    PayloadGenerator.WiFi generator = new(Model.SSID, Model.Password, Model.Authentication, Model.Hidden);
    Payload = generator.ToString();
  }

  private void OnModelPropertyChanged()
  => IsModelValid = Model.HasErrors.IsFalse();
}
