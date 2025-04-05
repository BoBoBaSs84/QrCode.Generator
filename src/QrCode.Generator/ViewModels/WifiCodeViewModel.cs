// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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
/// <param name="exportService">The export service instance to use.</param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class WifiCodeViewModel(IQrCodeService qrCodeService, IExportService<WifiCodeModel> exportService, ITemplateService<WifiCodeModel> templateService, WifiCodeModel model)
  : QrCodeViewModel<WifiCodeModel>(qrCodeService, exportService, templateService, model)
{
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
