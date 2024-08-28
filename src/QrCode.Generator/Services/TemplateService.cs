using System.Text.Json;
using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

using QrCode.Generator.Converters;
using QrCode.Generator.Interfaces.Services;

namespace QrCode.Generator.Services;

/// <summary>
/// The generic template service implementation.
/// </summary>
/// <typeparam name="T">The class to work with.</typeparam>
internal sealed class TemplateService<T> : ITemplateService<T> where T : class
{
  private readonly JsonSerializerOptions _serializerOptions = new(JsonSerializerDefaults.General)
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

  public T From(string template)
    => template.FromJson<T>(_serializerOptions);

  public string To(T template)
    => template.ToJson(_serializerOptions);
}
