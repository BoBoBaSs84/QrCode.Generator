using System.Text.Json;
using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

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
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    IgnoreReadOnlyFields = true,
    PropertyNameCaseInsensitive = true,
    NumberHandling = JsonNumberHandling.WriteAsString,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
  };

  public T From(string template)
    => template.FromJson<T>(_serializerOptions);

  public string To(T template)
    => template.ToJson(_serializerOptions);
}
