// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Swashbuckle.AspNetCore.Swagger;

namespace QRCode.API.Extensions;

/// <summary>
/// Represents extension methods for configuring <see cref="SwaggerOptions"/>
/// </summary>
public static class SwaggerOptionsExtensions
{
  /// <summary>
  /// Configures the specified <see cref="SwaggerOptions"/> with default settings for OpenAPI version 2.0.
  /// </summary>
  /// <param name="options">The <see cref="SwaggerOptions"/> instance to configure.</param>
  /// <returns>
  /// The same <see cref="SwaggerOptions"/> instance, so that additional configuration can be chained.
  /// </returns>
  internal static SwaggerOptions ConfigureSwaggerOptions(this SwaggerOptions options)
  {
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    options.RouteTemplate = "swagger/{documentName}/swagger.json";

    return options;
  }
}
