﻿// -----------------------------------------------------------------------------
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

using static QRCoder.PayloadGenerator;
using static QRCoder.PayloadGenerator.Girocode;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The giro code view model class.
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="exportService">The export service instance to use.</param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class GiroCodeViewModel(IQrCodeService qrCodeService, IExportService<GiroCodeModel> exportService, ITemplateService<GiroCodeModel> templateService, GiroCodeModel model)
  : QrCodeViewModel<GiroCodeModel>(qrCodeService, exportService, templateService, model)
{
  /// <summary>
  /// The remittance types to select from.
  /// </summary>
  public Tuple<string, TypeOfRemittance>[] ReferenceTypes
    => Model.Type.GetValues().AsTuple();

  /// <summary>
  /// The giro version types to select from.
  /// </summary>
  public Tuple<string, GirocodeVersion>[] VersionTypes
    => Model.Version.GetValues().AsTuple();

  /// <summary>
  /// The giro encoding types to select from.
  /// </summary>
  public Tuple<string, GirocodeEncoding>[] EncodingTypes
    => Model.Encoding.GetValues().AsTuple();

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    Girocode generator = new(Model.IBAN, Model.BIC, Model.Name, Model.Amount, Model.Reference,
      Model.Type, Model.Purpose, Model.Message, Model.Version, Model.Encoding);

    Payload = generator.ToString();
  }
}
