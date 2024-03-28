using BB84.Notifications;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.Services;

/// <summary>
/// The navigation service class.
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="NavigationService"/> class.
/// </remarks>
/// <param name="viewModelFactory"></param>
internal sealed class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : NotifiableObject, INavigationService
{
  private ViewModelBase _currentView = default!;

  public ViewModelBase CurrentView
  {
    get => _currentView;
    private set => SetProperty(ref _currentView, value);
  }

  public void NavigateTo<T>() where T : ViewModelBase
    => CurrentView = viewModelFactory.Invoke(typeof(T));
}
