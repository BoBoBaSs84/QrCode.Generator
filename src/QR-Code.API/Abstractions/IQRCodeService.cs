using QRCode.API.Contracts;

namespace QRCode.API.Abstractions;

/// <summary>
/// Represents a service contract for generating QR codes.
/// </summary>
public interface IQRCodeService
{
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
  /// Generates a QR code for Wi-Fi access based on the provided request details.
  /// </summary>
  /// <remarks>
  /// The method creates a QR code that encodes the Wi-Fi credentials specified in the
  /// <paramref name="request"/>. The QR code is customized with the specified foreground
  /// and background colors.
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
