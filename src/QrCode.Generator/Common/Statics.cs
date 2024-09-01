using System.Text.Json;
using System.Text.Json.Serialization;

using QrCode.Generator.Converters;

namespace QrCode.Generator.Common;

/// <summary>
/// The application statics.
/// </summary>
internal static class Statics
{
  /// <summary>
  /// The default template path for loading and saving.
  /// </summary>
  public static string DefaultTemplatePath
    => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

  /// <summary>
  /// The default template file filter for loading and saving.
  /// </summary>
  public static string TemplateFileFilter
    => "Template files (*.json)|*.json";

  /// <summary>
  /// The default json serializer options settings.
  /// </summary>
  public static JsonSerializerOptions SerializerOptions => new(JsonSerializerDefaults.General)
  {
    Converters = { new ColorJsonConverter() },
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    IgnoreReadOnlyFields = true,
    IgnoreReadOnlyProperties = true,
    NumberHandling = JsonNumberHandling.WriteAsString,
    PropertyNameCaseInsensitive = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
  };
}
