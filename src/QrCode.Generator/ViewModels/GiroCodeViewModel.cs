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
    => Model.TypeOfRemittance.GetValues().AsTuple();

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
    Girocode generator = new(Model.IBAN, Model.BIC, Model.Name, Model.Amount, Model.ReferenceInformation,
      Model.TypeOfRemittance, Model.PurposeOfCreditTransfer, Model.MessageToGirocodeUser, Model.Version,
      Model.Encoding
      );

    Payload = generator.ToString();
  }
}
