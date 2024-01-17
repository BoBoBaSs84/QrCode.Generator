namespace WIFI.QRCode.Builder.Extensions;

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
      tuples.Add(new($"{value}", value));
    return [.. tuples];
  }
}
