// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel;
using System.Reflection;

namespace QrCode.Generator.Caches;

/// <summary>
/// The description attribute cache class.
/// </summary>
/// <typeparam name="T">Should be a <see cref="Enum"/> value.</typeparam>
internal static class DescriptionAttributeCache<T> where T : struct, IComparable, IFormattable, IConvertible
{
  private static readonly Dictionary<T, string> Descriptions;

  /// <summary>
  /// Initializes a instance of the description attribute cache class.
  /// </summary>
  static DescriptionAttributeCache()
  {
    Descriptions = [];

    Type type = typeof(T);
    foreach (T value in Enum.GetValues(type).Cast<T>())
    {
      string valueName = value.ToString()!;
      Descriptions.Add(value, type.GetMember(valueName)[0].GetCustomAttribute<DescriptionAttribute>()?.Description ?? valueName);
    }
  }

  /// <summary>
  /// Returns the description of the <see cref="Enum"/> <paramref name="value"/> from the cache.
  /// </summary>
  /// <param name="value">The enum type value.</param>
  /// <returns>The enumerator description.</returns>
  internal static string GetDescription(T value)
    => Descriptions[value];
}
