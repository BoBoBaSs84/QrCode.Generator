using BB84.Notifications.Interfaces.Commands;

namespace QrCode.Generator.Interfaces.ViewModels;

/// <summary>
/// The generic view model template interface.
/// </summary>
public interface ITemplatable<T> where T : class
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  T Model { get; }

  /// <summary>
  /// The path to load the templates from.
  /// </summary>
  string LoadPath { get; set; }

  /// <summary>
  /// The path to save the templates into.
  /// </summary>
  string SavePath { get; set; }

  /// <summary>
  /// The command the load a template into the current model.
  /// </summary>
  IActionCommand<T> LoadTemplateCommand { get; }

  /// <summary>
  /// The command the create a template from the current model.
  /// </summary>
  IActionCommand<T> SaveTemplateCommand { get; }
}
