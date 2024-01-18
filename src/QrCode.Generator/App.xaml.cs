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
    => _loggerService.Log(LogCritical, exception);

  private static IHostBuilder CreateHostBuilder()
    => Host.CreateDefaultBuilder().ConfigureServices(services =>
    {
      _ = services.RegisterModels();
      _ = services.RegisterServices();
      _ = services.RegisterViewModels();
      _ = services.RegisterWindows();
    });
}
