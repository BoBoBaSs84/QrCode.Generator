// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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
