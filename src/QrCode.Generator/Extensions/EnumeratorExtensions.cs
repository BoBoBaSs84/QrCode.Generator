// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.Caches;

namespace QrCode.Generator.Extensions;

/// <summary>
/// The enumerator extensions class.
/// </summary>
internal static class EnumeratorExtensions
{
  /// <summary>
  /// Returns a tuple of all provided enumerator values.
  /// </summary>
	/// <typeparam name="T">The type of the enumerator.</typeparam>
	/// <param name="values">The values of the enumerator.</param>
  /// <returns>The tuple.</returns>
  public static Tuple<string, T>[] AsTuple<T>(this IEnumerable<T> values) where T : struct, IComparable, IFormattable, IConvertible
  {
    List<Tuple<string, T>> tuples = [];
    foreach (T value in values)
      tuples.Add(new(value.GetDescription(), value));
    return [.. tuples];
  }

  /// <summary>
  /// Returns the description of the <typeparamref name="T"/> enumerator.
  /// </summary>
  /// <typeparam name="T">The enmuerator type.</typeparam>
  /// <param name="value">The enumerator value.</param>
  /// <returns>The description or the enum name.</returns>
  public static string GetDescription<T>(this T value) where T : struct, IComparable, IFormattable, IConvertible
    => DescriptionAttributeCache<T>.GetDescription(value);
}
