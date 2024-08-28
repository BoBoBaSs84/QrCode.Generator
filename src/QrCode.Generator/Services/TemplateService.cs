using System.Text.Json;
using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

using QrCode.Generator.Converters;
using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;

namespace QrCode.Generator.Services;

/// <summary>
/// The generic template service implementation.
/// </summary>
/// <typeparam name="T">The class to work with.</typeparam>
/// <param name="fileProvider">The file provider instance to use.</param>
internal sealed class TemplateService<T>(IFileProvider fileProvider) : ITemplateService<T> where T : class
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

  public string Load(string filePath)
    => fileProvider.ReadAllText(filePath);

  public void Save(string filePath, string fileContent)
    => fileProvider.WriteAllText(filePath, fileContent);

  public string To(T template)
    => template.ToJson(_serializerOptions);
}
