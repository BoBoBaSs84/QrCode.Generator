using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Media;

using BB84.Extensions;

namespace QrCode.Generator.Converters;

/// <summary>
/// The color json converter class.
/// </summary>
internal sealed class ColorJsonConverter : JsonConverter<Color>
{
  /// <inheritdoc/>
  public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    string? value = reader.GetString();

    if (value is null)
      return Colors.Transparent;

    System.Drawing.Color colorValue = value.FromARGBHexString();
    return Color.FromArgb(colorValue.A, colorValue.R, colorValue.G, colorValue.B);
  }

  /// <inheritdoc/>
  public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
  {
    System.Drawing.Color colorValue = System.Drawing.Color.FromArgb(value.A, value.R, value.G, value.B);
    writer.WriteStringValue(colorValue.ToARGBHexString());
  }
}
