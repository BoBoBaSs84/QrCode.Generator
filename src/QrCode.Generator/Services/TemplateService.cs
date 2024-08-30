using System.Text.Json;
using System.Text.Json.Serialization;

using BB84.Extensions.Serialization;

using Microsoft.Extensions.Logging;

using QrCode.Generator.Converters;
using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;

namespace QrCode.Generator.Services;

/// <summary>
/// The generic template service implementation.
/// </summary>
/// <typeparam name="T">The class to work with.</typeparam>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="fileProvider">The file provider instance to use.</param>
public sealed class TemplateService<T>(ILoggerService<TemplateService<T>> loggerService, IFileProvider fileProvider) : ITemplateService<T> where T : class
{
  private static readonly Action<ILogger, Exception?> LogException =
    LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

  private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.General)
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
  {
    try
    {
      return template.FromJson<T>(SerializerOptions);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }

  public string Load(string filePath)
  {
    try
    {
      return fileProvider.ReadAllText(filePath);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }

  public void Save(string filePath, string fileContent)
  {
    try
    {
      fileProvider.WriteAllText(filePath, fileContent);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }

  public string To(T template)
  {
    try
    {
      return template.ToJson(SerializerOptions);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }
}
