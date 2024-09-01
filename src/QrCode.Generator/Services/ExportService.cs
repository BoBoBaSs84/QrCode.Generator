using Microsoft.Extensions.Logging;

using QrCode.Generator.Enumerators;
using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;

namespace QrCode.Generator.Services;

/// <summary>
/// The export service class.
/// </summary>
/// <typeparam name="T">The model type to work with.</typeparam>
/// <param name="loggerService">The logger service instance to use.</param>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="fileProvider">The file provider instance to use.</param>
internal sealed class ExportService<T>(ILoggerService<ExportService<T>> loggerService, IQrCodeService qrCodeService, IFileProvider fileProvider) : IExportService<T> where T : QrCodeModel
{
  private static Action<ILogger, Exception?> LogException
    => LoggerMessage.Define(LogLevel.Critical, 0, string.Empty);

  public void Export(string exportPath, ExportType type, string payload, T model)
  {
    try
    {
      byte[] fileContent = GetFileContent(type, payload, model);
      fileProvider.WriteAllBytes(exportPath, fileContent);
    }
    catch (Exception ex)
    {
      loggerService.Log(LogException, ex);
      throw;
    }
  }

  private byte[] GetFileContent(ExportType type, string payload, T model)
  {
    return type switch
    {
      ExportType.BMP => qrCodeService.CreateBmp(payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection),
      ExportType.PNG => qrCodeService.CreatePng(payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection),
      ExportType.JPEG => throw new NotImplementedException(),
      ExportType.SVG => qrCodeService.CreateSvg(payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection),
      ExportType.PDF => qrCodeService.CreatePdf(payload, 20, model.ForegroundColor, model.BackgroundColor, model.ErrorCorrection),
      _ => throw new ArgumentOutOfRangeException(nameof(type))
    };
  }
}
