using QRCode.API.Contracts;

namespace QRCode.API.Abstractions;

/// <summary>
/// Represents a service contract for generating QR codes.
/// </summary>
public interface IQRCodeService
{
  /// <summary>
  /// Generates a QR code for a contact based on the provided event details.
  /// </summary>
  /// <remarks>
  /// The method uses the contact information provided in the <paramref name="request"/> to generate
  /// a QR code in the specified output format. If no output type is specified, the default format is VCard3.
  /// The generated contact can be used to create a QR code representation of the contact details.
  /// </remarks>
  /// <param name="request">The request containing the contact details to be encoded.</param>
  /// <returns>
  /// An <see cref="IResult"/> containing the generated QR code as a PNG image.
  /// </returns>
  IResult GetContactCode(ContactCodeRequest request);

  /// <summary>
  /// Generates a QR code for a calendar event based on the provided event details.
  /// </summary>
  /// <remarks>
  /// The method creates a calendar event payload using the specified event details and generates
  /// a QR code representation of the event. The description and location fields in the request
  /// are processed to replace newline characters with a format suitable for QR code generation.
  /// </remarks>
  /// <param name="request">
  /// The request containing details of the calendar event, such as subject, description, location,
  /// start and end times, and encoding options.
  /// </param>
  /// <returns>
  /// An <see cref="IResult"/> containing the generated QR code as a PNG image.
  /// </returns>
  IResult GetEventCode(EventCodeRequest request);

  /// <summary>
  /// Generates a QR code for a SEPA credit transfer (Girocode) based on the provided banking details.
  /// </summary>
  /// <remarks>
  /// The method creates a Girocode payload according to the European Payments Council (EPC) specifications
  /// for SEPA credit transfers. The generated QR code contains information such as IBAN, BIC, beneficiary name,
  /// amount, and remittance information. The QR code can be scanned by banking applications to initiate
  /// a payment transaction.
  /// </remarks>
  /// <param name="request">
  /// The request containing banking details such as IBAN, BIC, beneficiary name, amount, remittance information,
  /// version, and encoding options.
  /// </param>
  /// <returns>
  /// An <see cref="IResult"/> containing the generated QR code as a PNG image.
  /// </returns>
  IResult GetGiroCode(GiroCodeRequest request);

  /// <summary>
  /// Generates a QR code for Wi-Fi access based on the provided request details.
  /// </summary>
  /// <remarks>
  /// The method creates a QR code that encodes the Wi-Fi credentials specified in the
  /// request. The QR code is customized with the specified foreground and background colors.
  /// </remarks>
  /// <param name="request">
  /// The request containing Wi-Fi details such as SSID, password, authentication type,
  /// visibility, and QR code customization options.
  /// </param>
  /// <returns>
  /// An <see cref="IResult"/> containing the generated QR code as a PNG image.
  /// </returns>
  IResult GetWifiCode(WifiCodeRequest request);
}
