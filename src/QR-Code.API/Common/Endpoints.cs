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
  /// Represents the summary description for the Wi-Fi QR code generation operation.
  /// </summary>
  public const string WifiCodeOperationSummary = "Generates a Wi-Fi QR code based on the provided parameters.";

  /// <summary>
  /// Represents the endpoint for generating calendar event QR codes.
  /// </summary>
  public const string EventCodeEndpoint = "/event";

  /// <summary>
  /// Represents the name of the endpoint for generating calendar event QR codes.
  /// </summary>
  public const string GetEventCodeEndpointName = "GetEventCode";

  /// <summary>
  /// Represents the summary description for the calendar event QR code generation operation.
  /// </summary>
  public const string EventCodeOperationSummary = "Generates a calendar event QR code based on the provided parameters.";
}
