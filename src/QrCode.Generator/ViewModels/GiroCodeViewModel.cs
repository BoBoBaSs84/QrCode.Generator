using BB84.Extensions;

using WIFI.QRCode.Builder.Extensions;
using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.ViewModels.Base;

using static QRCoder.PayloadGenerator;
using static QRCoder.PayloadGenerator.Girocode;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The giro code view model class.
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class GiroCodeViewModel(IQrCodeService qrCodeService, GiroCodeModel model) : QrCodeViewModel(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public GiroCodeModel Model { get; } = model;

  /// <summary>
  /// The remittance types to select from.
  /// </summary>
  public Tuple<string, TypeOfRemittance>[] ReferenceTypes
    => TypeOfRemittance.Structured.GetValues().AsTuple();

  /// <summary>
  /// The giro version types to select from.
  /// </summary>
  public Tuple<string, GirocodeVersion>[] VersionTypes
    => GirocodeVersion.Version1.GetValues().AsTuple();

  /// <summary>
  /// The giro encoding types to select from.
  /// </summary>
  public Tuple<string, GirocodeEncoding>[] EncodingTypes
    => GirocodeEncoding.ISO_8859_1.GetValues().AsTuple();

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    Girocode generator = new(Model.IBAN, Model.BIC, Model.Name, Model.Amount, Model.ReferenceInformation,
      Model.TypeOfRemittance, Model.PurposeOfCreditTransfer, Model.MessageToGirocodeUser, Model.Version,
      Model.Encoding
      );

    Payload = generator.ToString();
  }
}
