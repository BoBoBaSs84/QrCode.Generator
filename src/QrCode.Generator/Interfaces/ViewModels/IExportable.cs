// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using BB84.Notifications.Interfaces.Commands;

using QrCode.Generator.Enumerators;

namespace QrCode.Generator.Interfaces.ViewModels;

/// <summary>
/// The generic view model export interface.
/// </summary>
/// <typeparam name="T">The model type to work with.</typeparam>
public interface IExportable<T> : IModel<T> where T : class
{
  /// <summary>
  /// The path to save the export into.
  /// </summary>
  string ExportPath { get; set; }

  /// <summary>
  /// The type to export into.
  /// </summary>
  ExportType ExportType { get; set; }

  /// <summary>
  /// The possible types to export into.
  /// </summary>
  public Tuple<string, ExportType>[] ExportTypes { get; }

  /// <summary>
  /// The command to export the QR code.
  /// </summary>
  IActionCommand ExportCommand { get; }
}
