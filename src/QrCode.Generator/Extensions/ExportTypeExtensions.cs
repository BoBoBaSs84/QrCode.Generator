// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.Enumerators;

namespace QrCode.Generator.Extensions;

/// <summary>
/// The extensions class for the <see cref="ExportType"/> enumerator.
/// </summary>
public static class ExportTypeExtensions
{
  /// <summary>
  /// Returns the file type filter base on the provided <paramref name="type"/> enumerator value.
  /// </summary>
  /// <param name="type">The enumerator value to use.</param>
  /// <returns>The file type filter.</returns>
  /// <exception cref="NotImplementedException"></exception>
  /// <exception cref="ArgumentOutOfRangeException"></exception>
  public static string GetFilterFromType(this ExportType type)
  {
    return type switch
    {
      ExportType.BMP => $"{type.GetDescription()} (*.bmp)|*.bmp",
      ExportType.PNG => $"{type.GetDescription()} (*.png)|*.png",
      ExportType.JPEG => throw new NotImplementedException(),
      ExportType.SVG => $"{type.GetDescription()} (*.svg)|*.svg",
      ExportType.PDF => $"{type.GetDescription()} (*.pdf)|*.pdf",
      _ => throw new ArgumentOutOfRangeException(nameof(type)),
    };
  }
}
