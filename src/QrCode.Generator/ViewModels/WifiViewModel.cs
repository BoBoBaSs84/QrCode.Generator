﻿using QRCoder;

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

  /// <summary>
  /// Initializes an instance of <see cref="WifiViewModel"/> class.
  /// </summary>
  /// <param name="qrCodeService">The qr code service instance to use.</param>
  /// <param name="model">The model instance to use.</param>
  public WifiViewModel(IQrCodeService qrCodeService, WifiModel model) : base(qrCodeService)
  {
    _qrCodeService = qrCodeService;
    Model = model;
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
  protected override void SetPayLoad()
  {
    PayloadGenerator.WiFi generator = new(Model.SSID, Model.Password, Model.Authentication, Model.Hidden);
    Payload = generator.ToString();
  }
}