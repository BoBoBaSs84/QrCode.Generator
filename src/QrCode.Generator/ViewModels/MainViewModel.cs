﻿using BB84.Notifications;
using BB84.Notifications.Interfaces;

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
  private IRelayCommand? _aboutCommand;
  private IRelayCommand? _contactCommand;
  private IRelayCommand? _exitCommand;
  private IRelayCommand? _eventCommand;
  private IRelayCommand? _giroCommand;
  private IRelayCommand? _wifiCommand;

  /// <summary>
  /// The navigation service instance.
  /// </summary>
  public INavigationService NavigationService
    => navigationService;

  /// <summary>
  /// The command to show the about control.
  /// </summary>
  public IRelayCommand AboutCommand
    => _aboutCommand ??= new RelayCommand(NavigationService.NavigateTo<AboutViewModel>);

  /// <summary>
  /// The command to show the contact code control.
  /// </summary>
  public IRelayCommand ContactCommand
    => _contactCommand ??= new RelayCommand(NavigationService.NavigateTo<ContactDataViewModel>);

  /// <summary>
  /// The command to exit the application.
  /// </summary>
  public IRelayCommand ExitCommand
    => _exitCommand ??= new RelayCommand(() => Environment.Exit(1));

  /// <summary>
  /// The command to show the event code control.
  /// </summary>
  public IRelayCommand EventCommand
    => _eventCommand ??= new RelayCommand(NavigationService.NavigateTo<EventCodeViewModel>);

  /// <summary>
  /// The command to show the giro code control.
  /// </summary>
  public IRelayCommand GiroCommand
    => _giroCommand ??= new RelayCommand(NavigationService.NavigateTo<GiroCodeViewModel>);

  /// <summary>
  /// The command to show the wifi code control.
  /// </summary>
  public IRelayCommand WifiCommand
    => _wifiCommand ??= new RelayCommand(NavigationService.NavigateTo<WifiCodeViewModel>);
}
