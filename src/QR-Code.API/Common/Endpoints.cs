// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
namespace QRCode.API.Common;

/// <summary>
/// Represents the API endpoints.
/// </summary>
public static class Endpoints
{
  /// <summary>
  /// Represents the endpoint for generating bookmark QR codes.
  /// </summary>
  public const string BookmarkCodeEndpoint = "/bookmark";

  /// <summary>
  /// Represents the name of the endpoint for generating bookmark QR codes.
  /// </summary>
  public const string GetBookmarkCodeEndpointName = "GetBookmarkCode";

  /// <summary>
  /// Represents the detailed description for the bookmark QR code generation operation.
  /// </summary>
  public const string BookmarkCodeOperationDescription = "The method generates a QR code for a browser bookmark using the URL and title provided in the request. The generated QR code can be scanned to quickly access the bookmarked webpage.";

  /// <summary>
  /// Represents the detailed description for the bookmark QR code generation operation.
  /// </summary>
  public const string BookmarkCodeOperationSummary = "Generates a browser bookmark data QR code based on the provided parameters.";

  /// <summary>
  /// Represents the endpoint for generating contact data QR codes.
  /// </summary>
  public const string ContactCodeEndpoint = "/contact";

  /// <summary>
  /// Represents the name of the endpoint for generating contact data QR codes.
  /// </summary>
  public const string GetContactCodeEndpointName = "GetContactCode";

  /// <summary>
  /// Represents the detailed description for the contact data QR code generation operation.
  /// </summary>
  public const string ContactCodeOperationDescription = "The method uses the contact information provided in the request to generate a QR code in the specified output format. If no output type is specified, the default format is VCard3. The generated contact can be used to create a QR code representation of the contact details.";

  /// <summary>
  /// Represents the summary for the contact data QR code generation operation.
  /// </summary>
  public const string ContactCodeOperationSummary = "Generates a contact data QR code based on the provided parameters.";

  /// <summary>
  /// Represents the endpoint for generating calendar event QR codes.
  /// </summary>
  public const string EventCodeEndpoint = "/event";

  /// <summary>
  /// Represents the name of the endpoint for generating calendar event QR codes.
  /// </summary>
  public const string GetEventCodeEndpointName = "GetEventCode";

  /// <summary>
  /// Represents the summary for the calendar event QR code generation operation.
  /// </summary>
  public const string EventCodeOperationSummary = "Generates a calendar event QR code based on the provided parameters.";

  /// <summary>
  /// Represents the detailed description for the calendar event QR code generation operation.
  /// </summary>
  public const string EventCodeOperationDescription = "The method creates a calendar event payload using the specified event details and generates a QR code representation of the event. The description and location fields in the request are processed to replace newline characters with a format suitable for QR code generation.";

  /// <summary>
  /// Represents the endpoint for generating Girocode QR codes.
  /// </summary>
  public const string GiroCodeEndpoint = "/giro";

  /// <summary>
  /// Represents the name of the endpoint for generating Girocode QR codes.
  /// </summary>
  public const string GetGiroCodeEndpointName = "GetGiroCode";

  /// <summary>
  /// Represents the summary for the Girocode QR code generation operation.
  /// </summary>
  public const string GiroCodeOperationSummary = "Generates a Girocode QR code for SEPA credit transfers based on the provided parameters.";

  /// <summary>
  /// Represents the detailed description for the Girocode QR code generation operation.
  /// </summary>
  public const string GiroCodeOperationDescription = "The method creates a Girocode payload for SEPA credit transfers using the specified banking details and generates a QR code representation. The Girocode contains information such as IBAN, BIC, beneficiary name, amount, and remittance information according to the European Payments Council (EPC) specifications.";

  /// <summary>
  /// Represents the endpoint for generating mail data QR codes.
  /// </summary>
  public const string MailCodeEndpoint = "/mail";

  /// <summary>
  /// Represents the name of the endpoint for generating mail data QR codes.
  /// </summary>
  public const string GetMailCodeEndpointName = "GetMailCode";

  /// <summary>
  /// Represents the summary for the mail data QR code generation operation.
  /// </summary>
  public const string MailCodeOperationSummary = "Generates a mail data QR code based on the provided parameters.";

  /// <summary>
  /// Represents the detailed description for the mail data QR code generation operation.
  /// </summary>
  public const string MailCodeOperationDescription = "The method generates a QR mail code using the email details provided in the request. The generated QR code can be scanned to quickly compose an email with the specified recipient, subject, and body.";

  /// <summary>
  /// Represents the endpoint for generating Wi-Fi QR codes.
  /// </summary>
  public const string WifiCodeEndpoint = "/wifi";

  /// <summary>
  /// Represents the name of the endpoint for generating Wi-Fi QR codes.
  /// </summary>
  public const string GetWifiCodeEndpointName = "GetWifiCode";

  /// <summary>
  /// Represents the summary for the Wi-Fi QR code generation operation.
  /// </summary>
  public const string WifiCodeOperationSummary = "Generates a Wi-Fi QR code based on the provided parameters.";

  /// <summary>
  /// Represents the detailed description for the Wi-Fi QR code generation operation.
  /// </summary>
  public const string WifiCodeOperationDescription = "The method creates a QR code that encodes the Wi-Fi credentials specified in the request. The QR code is customized with the specified foreground and background colors.";
}
