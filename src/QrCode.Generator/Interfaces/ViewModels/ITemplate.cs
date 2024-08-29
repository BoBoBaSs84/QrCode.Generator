using BB84.Notifications.Interfaces.Commands;

namespace QrCode.Generator.Interfaces.ViewModels;

/// <summary>
/// The generic view model template interface.
/// </summary>
public interface ITemplate<T> where T : class
{
  /// <summary>
  /// The command the load a template into the current model.
  /// </summary>
  IActionCommand<T> LoadTemplateCommand { get; }

  /// <summary>
  /// The command the create a template from the current model.
  /// </summary>
  IActionCommand<T> SaveTemplateCommand { get; }
}
