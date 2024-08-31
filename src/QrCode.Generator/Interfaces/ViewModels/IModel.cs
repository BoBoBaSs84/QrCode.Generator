namespace QrCode.Generator.Interfaces.ViewModels;

/// <summary>
/// The generic view model model interface.
/// </summary>
/// <typeparam name="T">The model type to work with.</typeparam>
public interface IModel<T> where T : class
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  T Model { get; }
}
