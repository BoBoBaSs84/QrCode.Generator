// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Swashbuckle.AspNetCore.SwaggerUI;

namespace QRCode.API.Extensions;

/// <summary>
/// Represents extension methods for configuring <see cref="SwaggerUIOptions"/>
/// </summary>
public static class SwaggerUIOptionsExtensions
{
  /// <summary>
  /// Configures the specified <see cref="SwaggerUIOptions"/> with default settings.
  /// </summary>
  /// <param name="options">The <see cref="SwaggerUIOptions"/> instance to configure.</param>
  /// <returns>
  /// The same <see cref="SwaggerUIOptions"/> instance, so that additional configuration can be chained.
  /// </returns>
  internal static SwaggerUIOptions ConfigureSwaggerUIOptions(this SwaggerUIOptions options)
  {
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "QR-Code.API v1");

    return options;
  }
}
