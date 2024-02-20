using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The about view model
/// </summary>
/// <param name="model">The model instance to use.</param>
public sealed class AboutViewModel(AboutModel model) : ViewModel
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public AboutModel Model { get; } = model;
}
