namespace QRCode.API.Common;

/// <summary>
/// Represents the API endpoints.
/// </summary>
public static class Endpoints
{
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
}
