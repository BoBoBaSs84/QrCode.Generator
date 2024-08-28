using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The main view model class.
/// </summary>
/// <param name="navigationService">The navigation service instance to use.</param>
public sealed class MainViewModel(INavigationService navigationService) : ViewModelBase
{
  /// <summary>
  /// The navigation service instance.
  /// </summary>
  public INavigationService NavigationService
    => navigationService;

  /// <summary>
  /// The command to show the about control.
  /// </summary>
  public IActionCommand AboutCommand
    => new ActionCommand(NavigationService.NavigateTo<AboutViewModel>);

  /// <summary>
  /// The command to show the contact code control.
  /// </summary>
  public IActionCommand ContactCommand
    => new ActionCommand(NavigationService.NavigateTo<ContactDataViewModel>);

  /// <summary>
  /// The command to exit the application.
  /// </summary>
  public IActionCommand ExitCommand
    => new ActionCommand(Exit);

  /// <summary>
  /// The command to show the event code control.
  /// </summary>
  public IActionCommand EventCommand
    => new ActionCommand(NavigationService.NavigateTo<EventCodeViewModel>);

  /// <summary>
  /// The command to show the giro code control.
  /// </summary>
  public IActionCommand GiroCommand
    => new ActionCommand(NavigationService.NavigateTo<GiroCodeViewModel>);

  /// <summary>
  /// The command to show the wifi code control.
  /// </summary>
  public IActionCommand WifiCommand
    => new ActionCommand(NavigationService.NavigateTo<WifiCodeViewModel>);

  private void Exit()
    => Environment.Exit(1);
}
