using QRCode.API.Abstractions;
using QRCode.API.Common;
using QRCode.API.Contracts;

namespace QRCode.API.Extensions;

/// <summary>
/// Represents extension methods for <see cref="WebApplication"/> class.
/// </summary>
public static class WebApplicationExtensions
{
  /// <summary>
  /// Adds an endpoint to the web application for generating event codes.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/event" route, which generates a calendar event code
  /// based on the provided <see cref="EventCodeRequest"/>. The endpoint is named "GetEventCode" and
  /// is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddEventCodeEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.EventCodeEndpoint, (EventCodeRequest request, IQRCodeService codeService)
      => codeService.GetEventCode(request))
        .WithName(Endpoints.GetEventCodeEndpointName)
        .WithDescription(Endpoints.EventCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the web application for generating a Wi-Fi QR code.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/wifi" route, which generates a Wi-Fi QR code
  /// based on the provided <see cref="WifiCodeRequest"/>. The endpoint is named "GetWifiCode" and
  /// is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddWifiCodeEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.WifiCodeEndpoint, (WifiCodeRequest request, IQRCodeService codeService)
      => codeService.GetWifiCode(request))
        .WithName(Endpoints.GetWifiCodeEndpointName)
        .WithDescription(Endpoints.WifiCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }
}
