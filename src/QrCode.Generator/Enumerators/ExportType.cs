// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel;

namespace QrCode.Generator.Enumerators;

/// <summary>
/// The export type enumerator.
/// </summary>
public enum ExportType
{
  /// <summary>
  /// Windows Bitmap Graphics
  /// </summary>
  [Description("Windows Bitmap Graphics")]
  BMP = 0,
  /// <summary>
  /// Portable Network Graphics
  /// </summary>
  [Description("Portable Network Graphics")]
  PNG = 1,
  /// <summary>
  /// Joint Photographic Experts Group
  /// </summary>
  [Description("Joint Photographic Experts Group")]
  JPEG = 2,
  /// <summary>
  /// Scalable Vector Graphics
  /// </summary>
  [Description("Scalable Vector Graphics")]
  SVG = 3,
  /// <summary>
  /// Portable Document Format
  /// </summary>
  [Description("Portable Document Format")]
  PDF = 4
}
