// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows.Media;

namespace QrCode.Generator.Extensions;

/// <summary>
/// The color extensions class.
/// </summary>
internal static class ColorExtensions
{
  /// <summary>
  /// Returns the hex representation (i.e. <b>#00ffff</b>) of the provided <see cref="Color"/>.
  /// </summary>
  /// <param name="value">The color to convert.</param>
  /// <returns>The hex string.</returns>
  public static string AsHexString(this Color value)
    => $"#{value.R:X2}{value.G:X2}{value.B:X2}";

  /// <summary>
  /// Returns the byte array representation of the provided <see cref="Color"/>.
  /// </summary>
  /// <param name="value">The color to convert.</param>
  /// <returns>The byte array.</returns>
  public static byte[] AsByteArray(this Color value)
    => [value.R, value.G, value.B, value.A];
}
