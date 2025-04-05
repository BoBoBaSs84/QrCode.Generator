// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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

  /// <summary>
  /// Loads the template from the provided <paramref name="filePath"/>.
  /// </summary>
  /// <param name="filePath">The location of the template to load.</param>
  /// <returns>The content of the teamplate file.</returns>
  string Load(string filePath);

  /// <summary>
  /// Saves the template to the provided <paramref name="filePath"/>.
  /// </summary>
  /// <param name="filePath">The location of the template to save.</param>
  /// <param name="fileContent">The template file content to save.</param>
  void Save(string filePath, string fileContent);
}