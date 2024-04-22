using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="MainViewModel"/> class.
/// </remarks>
/// <param name="navigationService">The navigation service instance to use.</param>
public sealed class MainViewModel(INavigationService navigationService) : ViewModelBase
{
  private IActionCommand? _aboutCommand;
  private IActionCommand? _contactCommand;
  private IActionCommand? _exitCommand;
  private IActionCommand? _eventCommand;
  private IActionCommand? _giroCommand;
  private IActionCommand? _wifiCommand;

  /// <summary>
  /// The navigation service instance.
  /// </summary>
  public INavigationService NavigationService
    => navigationService;

  /// <summary>
  /// The command to show the about control.
  /// </summary>
  public IActionCommand AboutCommand
    => _aboutCommand ??= new ActionCommand(NavigationService.NavigateTo<AboutViewModel>);

  /// <summary>
  /// The command to show the contact code control.
  /// </summary>
  public IActionCommand ContactCommand
    => _contactCommand ??= new ActionCommand(NavigationService.NavigateTo<ContactDataViewModel>);

  /// <summary>
  /// The command to exit the application.
  /// </summary>
  public IActionCommand ExitCommand
    => _exitCommand ??= new ActionCommand(() => Environment.Exit(1));

  /// <summary>
  /// The command to show the event code control.
  /// </summary>
  public IActionCommand EventCommand
    => _eventCommand ??= new ActionCommand(NavigationService.NavigateTo<EventCodeViewModel>);

  /// <summary>
  /// The command to show the giro code control.
  /// </summary>
  public IActionCommand GiroCommand
    => _giroCommand ??= new ActionCommand(NavigationService.NavigateTo<GiroCodeViewModel>);

  /// <summary>
  /// The command to show the wifi code control.
  /// </summary>
  public IActionCommand WifiCommand
    => _wifiCommand ??= new ActionCommand(NavigationService.NavigateTo<WifiCodeViewModel>);
}
