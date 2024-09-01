using BB84.Extensions.Serialization;

using Microsoft.Extensions.Logging;

using QrCode.Generator.Common;
using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;

namespace QrCode.Generator.Services;

/// <summary>
/// The generic template service implementation.
/// </summary>
/// <typeparam name="T">The class to work with.</typeparam>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="fileProvider">The file provider instance to use.</param>
internal sealed class TemplateService<T>(ILoggerService<TemplateService<T>> loggerService, IFileProvider fileProvider) : ITemplateService<T> where T : class
{
  private static Action<ILogger, Exception?> LogException
    => LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

  public T From(string template)
  {
    try
    {
      return template.FromJson<T>(Statics.SerializerOptions);
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
      if (template is null)
        throw new ArgumentNullException(nameof(template));

      return template.ToJson(Statics.SerializerOptions);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }
}
