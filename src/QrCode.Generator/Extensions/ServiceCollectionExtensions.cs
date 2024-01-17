using System.Diagnostics.CodeAnalysis;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.Services;
using WIFI.QRCode.Builder.ViewModels;
using WIFI.QRCode.Builder.ViewModels.Base;
using WIFI.QRCode.Builder.Views;

namespace WIFI.QRCode.Builder.Extensions;

/// <summary>
/// The service collection extensions class.
/// </summary>
internal static class ServiceCollectionExtensions
{
  private const string EventSourceName = "QrCode.Generator";

  /// <summary>
  /// Registers the models to the service collection.
  /// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
  internal static IServiceCollection RegisterModels(this IServiceCollection services)
  {
    services.TryAddSingleton<EventModel>();
    services.TryAddSingleton<GiroCodeModel>();
    services.TryAddSingleton<WifiModel>();

    return services;
  }

  /// <summary>
  /// Registers the application services to the service collection.
  /// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
  [SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
  internal static IServiceCollection RegisterServices(this IServiceCollection services)
  {
    services.TryAddSingleton(typeof(ILoggerService<>), typeof(LoggerService<>));
    services.TryAddSingleton<IQrCodeService, QrCodeService>();
    services.TryAddSingleton<INavigationService, NavigationService>();

    services.AddLogging(config =>
    {
      config.AddEventLog(settings => settings.SourceName = EventSourceName);
      config.SetMinimumLevel(LogLevel.Warning);
    });

    services.TryAddSingleton<Func<Type, ViewModel>>(serviceProvider
      => viewModelType => (ViewModel)serviceProvider.GetRequiredService(viewModelType));

    return services;
  }

  /// <summary>
  /// Registers the view models to the service collection.
  /// </summary>
  /// <param name="services">The service collection to enrich.</param>
  /// <returns>The enriched service collection.</returns>
  internal static IServiceCollection RegisterViewModels(this IServiceCollection services)
  {
    services.TryAddSingleton<MainViewModel>();
    services.TryAddSingleton<EventViewModel>();
    services.TryAddSingleton<GiroCodeViewModel>();
    services.TryAddSingleton<WifiViewModel>();

    return services;
  }

  /// <summary>
  /// Registers the views to the service collection.
  /// </summary>
	/// <param name="services">The service collection to enrich.</param>
	/// <returns>The enriched service collection.</returns>
  internal static IServiceCollection RegisterViews(this IServiceCollection services)
  {
    services.TryAddSingleton<MainView>();

    return services;
  }
}
