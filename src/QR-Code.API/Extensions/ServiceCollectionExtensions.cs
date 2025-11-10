using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Mvc;

using QRCode.API.Abstractions;
using QRCode.API.Services;

namespace QRCode.API.Extensions;

/// <summary>
/// Represents extension methods for <see cref="IServiceCollection"/> class.
/// </summary>
public static class ServiceCollectionExtensions
{
  private static readonly string XmlCommentsFilePath
    = Path.Combine(AppContext.BaseDirectory, $"{typeof(ServiceCollectionExtensions).Assembly.GetName().Name}.xml");

  private static readonly JsonStringEnumConverter JsonStringEnumConverter = new();

  /// <summary>
  /// Reisters all services required for the application.
  /// </summary>
  /// <param name="services">The <see cref="IServiceCollection"/> to register the services with.</param>
  /// <returns>
  /// The same <see cref="IServiceCollection"/> instance, so that additional configuration can be chained.
  /// </returns>
  public static IServiceCollection RegisterServices(this IServiceCollection services)
  {
    services.AddSingleton<IQRCodeService, QRCodeService>();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(options
      => options.IncludeXmlComments(XmlCommentsFilePath));
    services.ConfigureHttpJsonOptions(options
      => options.SerializerOptions.Converters.Add(JsonStringEnumConverter));
    services.Configure<JsonOptions>(options
      => options.JsonSerializerOptions.Converters.Add(JsonStringEnumConverter));

    return services;
  }
}
