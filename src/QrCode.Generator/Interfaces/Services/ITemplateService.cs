namespace QrCode.Generator.Interfaces.Services;

/// <summary>
/// The generic template service interface.
/// </summary>
/// <typeparam name="T">The class to work with.</typeparam>
public interface ITemplateService<T> where T : class
{
  /// <summary>
  /// Retrieves the information from a template.
  /// </summary>
  /// <param name="template">The template information to retrieve.</param>
  /// <returns>The retrieved tempalte information.</returns>
  T From(string template);

  /// <summary>
  /// Transforms the information into a template.
  /// </summary>
  /// <param name="template">The template information to transform.</param>
  /// <returns>The transformed template information.</returns>
  string To(T template);
}