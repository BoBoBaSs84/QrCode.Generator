// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Diagnostics.CodeAnalysis;
using System.Windows;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Windows;

namespace QrCode.Generator.Builder;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Main entry point for application.")]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
public partial class App : Application
{
  private readonly IHost _host;
  private readonly IServiceProvider _serviceProvider;
  private readonly ILoggerService<App> _loggerService;

  private static readonly Action<ILogger, string, Exception?> LogInformation =
    LoggerMessage.Define<string>(LogLevel.Information, 0, "{Information}");

  private static readonly Action<ILogger, Exception?> LogCritical =
    LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

  /// <summary>
  /// Initializes a new instance of the <see cref="App"/> class.
  /// </summary>
  public App()
  {
    _host = CreateHostBuilder().Build();
    _serviceProvider = _host.Services;
    _loggerService = _serviceProvider.GetRequiredService<ILoggerService<App>>();

    DispatcherUnhandledException += (s, e) => OnUnhandledException(e.Exception);
  }

  /// <summary>
  /// The <see cref="GetService{T}"/> method should the requested registered service.
  /// </summary>
  /// <typeparam name="T">The requested service.</typeparam>
  /// <returns>The registered service.</returns>
  /// <exception cref="ArgumentException">If a service is not registered.</exception>
  public static T GetService<T>() where T : class =>
    (Current as App)!._host.Services.GetService(typeof(T)) is not T service
    ? throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.")
    : service;

  private async void Application_Startup(object sender, StartupEventArgs e)
  {
    _loggerService.Log(LogInformation, "Application starting...");
    await _host.StartAsync().ConfigureAwait(false);

    MainWindow mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
    mainWindow.Show();
  }

  private async void Application_Exit(object sender, ExitEventArgs e)
  {
    _loggerService.Log(LogInformation, "Application exiting...");

    using (_host)
      await _host.StopAsync(TimeSpan.FromSeconds(5)).ConfigureAwait(false);
  }

  private void OnUnhandledException(Exception exception)
  {
    _loggerService.Log(LogCritical, exception);
    MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
  }

  private static IHostBuilder CreateHostBuilder()
    => Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
      services.RegisterModels();
      services.RegisterServices();
      services.RegisterProviders();
      services.RegisterViewModels();
      services.RegisterWindows();
    });
}
