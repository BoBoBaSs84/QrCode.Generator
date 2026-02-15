// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Microsoft.OpenApi;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace QRCode.API.Extensions;

/// <summary>
/// Provides extension methods for configuring Swagger generation options.
/// </summary>
public static class SwaggerGenOptionsExtensions
{
  private static readonly string XmlCommentsFilePath
    = Path.Combine(AppContext.BaseDirectory, $"{typeof(ServiceCollectionExtensions).Assembly.GetName().Name}.xml");

  /// <summary>
  /// Configures the Swagger generation options for the application, including support for
  /// non-nullable reference types, custom schema IDs, annotations, and XML comments.
  /// </summary>
  /// <param name="options">The <see cref="SwaggerGenOptions"/> to configure.</param>
  /// <returns>
  /// The same <see cref="SwaggerGenOptions"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static SwaggerGenOptions ConfigureSwaggerGenOptions(this SwaggerGenOptions options)
  {
    options.SupportNonNullableReferenceTypes();
    options.CustomSchemaIds(type
      => type.FullName?.Replace("+", ".", StringComparison.InvariantCulture));
    options.EnableAnnotations();
    options.IncludeXmlComments(XmlCommentsFilePath);

    options.SwaggerDoc("v1", new OpenApiInfo
    {
      Version = "v1",
      Title = "QR Code API",
      Description = "This API allows you to generate different types of QR codes, including URL, text, email, phone number, and Wi-Fi QR codes." +
      " It provides a simple interface for creating QR codes with customizable options.",
      Contact = new OpenApiContact
      {
        Name = "Support",
        Email = "support@qrcodeapi.com"
      },
      License = new OpenApiLicense
      {
        Name = "MIT License",
        Url = new Uri("https://opensource.org/licenses/MIT")
      },
      TermsOfService = new Uri("https://qrcodeapi.com/terms")
    });

    return options;
  }
}
