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
  public static string GetHexString(this Color value)
    => $"#{value.R:X2}{value.G:X2}{value.B:X2}";
}
