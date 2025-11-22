// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;

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
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating bookmark data codes.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/bookmark" route, which generates a bookmark data code
  /// based on the provided <see cref="BookmarkCodeRequest"/>. The endpoint is named "GetBookmarkCode" and
  /// is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddBookmarkEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.ContactCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] BookmarkCodeRequest request)
      => codeService.GetBookmarkCode(request))
        .WithName(Endpoints.GetContactCodeEndpointName)
        .WithDescription(Endpoints.ContactCodeOperationDescription)
        .WithSummary(Endpoints.ContactCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating contact data codes.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/contact" route, which generates a contact data code
  /// based on the provided <see cref="ContactCodeRequest"/>. The endpoint is named "GetContactCode" and
  /// is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddContactCodeEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.ContactCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] ContactCodeRequest request)
      => codeService.GetContactCode(request))
        .WithName(Endpoints.GetContactCodeEndpointName)
        .WithDescription(Endpoints.ContactCodeOperationDescription)
        .WithSummary(Endpoints.ContactCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating event codes.
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
    webApp.MapPost(Endpoints.EventCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] EventCodeRequest request)
      => codeService.GetEventCode(request))
        .WithName(Endpoints.GetEventCodeEndpointName)
        .WithDescription(Endpoints.EventCodeOperationDescription)
        .WithSummary(Endpoints.EventCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating Girocode QR codes.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/girocode" route, which generates a Girocode QR code
  /// for SEPA credit transfers based on the provided <see cref="GiroCodeRequest"/>. The endpoint is named
  /// "GetGiroCode" and is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddGiroCodeEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.GiroCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] GiroCodeRequest request)
      => codeService.GetGiroCode(request))
        .WithName(Endpoints.GetGiroCodeEndpointName)
        .WithDescription(Endpoints.GiroCodeOperationDescription)
        .WithSummary(Endpoints.GiroCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating mail data codes.
  /// </summary>
  /// <remarks>
  /// This method maps a POST request to the "/mail" route, which generates a mail data code
  /// based on the provided <see cref="MailCodeRequest"/>. The endpoint is named "GetMailCode" and
  /// is configured with OpenAPI support.
  /// </remarks>
  /// <param name="webApp">The <see cref="WebApplication"/> to which the endpoint is added.</param>
  /// <returns>
  /// The same <see cref="WebApplication"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static WebApplication AddMailCodeEndpoint(this WebApplication webApp)
  {
    webApp.MapPost(Endpoints.ContactCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] MailCodeRequest request)
      => codeService.GetMailCode(request))
        .WithName(Endpoints.GetContactCodeEndpointName)
        .WithDescription(Endpoints.ContactCodeOperationDescription)
        .WithSummary(Endpoints.ContactCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }

  /// <summary>
  /// Adds an endpoint to the <see cref="WebApplication"/> for generating a Wi-Fi QR code.
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
    webApp.MapPost(Endpoints.WifiCodeEndpoint, ([FromServices] IQRCodeService codeService, [FromBody] WifiCodeRequest request)
      => codeService.GetWifiCode(request))
        .WithName(Endpoints.GetWifiCodeEndpointName)
        .WithDescription(Endpoints.WifiCodeOperationDescription)
        .WithSummary(Endpoints.WifiCodeOperationSummary)
        .WithOpenApi();

    return webApp;
  }
}
