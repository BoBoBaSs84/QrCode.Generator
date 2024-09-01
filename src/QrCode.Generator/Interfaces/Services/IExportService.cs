using QrCode.Generator.Enumerators;

namespace QrCode.Generator.Interfaces.Services;

/// <summary>
/// The export service interface
/// </summary>
/// <typeparam name="T">The model type to work with.</typeparam>
public interface IExportService<T> where T : class
{
  /// <summary>
  /// Exports the qr code.
  /// </summary>
  /// <param name="exportPath"></param>
  /// <param name="type"></param>
  /// <param name="payLoad"></param>
  /// <param name="model"></param>
  void Export(string exportPath, ExportType type, string payLoad, T model);
}
