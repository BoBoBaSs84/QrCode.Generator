using BB84.Notifications.Interfaces.Commands;

namespace QrCode.Generator.Interfaces.ViewModels;

/// <summary>
/// The generic view model template interface.
/// </summary>
public interface ITemplate<T> where T : class
{
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

  /// <summary>
  /// Loads the template into the current model.
  /// </summary>
  /// <param name="model">The model to load into.</param>
  protected abstract void LoadTemplate(T model);

  /// <summary>
  /// Saves the template from the current model.
  /// </summary>
  /// <param name="model">The model to save from.</param>
  protected abstract void SaveTemplate(T model);
}
