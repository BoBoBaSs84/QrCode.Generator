using BB84.Notifications;

using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.ViewModels.Base;

namespace WIFI.QRCode.Builder.Services;

/// <summary>
/// The navigation service class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="NavigationService"/> class.
/// </remarks>
/// <param name="viewModelFactory"></param>
internal sealed class NavigationService(Func<Type, ViewModel> viewModelFactory) : NotificationObject, INavigationService
{
  private ViewModel _currentView = default!;

  public ViewModel CurrentView
  {
    get => _currentView;
    private set => SetProperty(ref _currentView, value);
  }

  public void NavigateTo<T>() where T : ViewModel
    => CurrentView = viewModelFactory.Invoke(typeof(T));
}
