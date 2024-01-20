using System.Diagnostics;

using QrCode.Generator.Models.Base;

namespace QrCode.Generator.Models;

/// <summary>
/// The about model.
/// </summary>
public sealed class AboutModel : ModelBase
{
  private readonly FileVersionInfo _fileVersionInfo;

  /// <summary>
  /// Initializes an instance of <see cref="AboutModel"/> class.
  /// </summary>
  public AboutModel()
  {
    _fileVersionInfo = FileVersionInfo.GetVersionInfo(typeof(AboutModel).Assembly.Location);

    Title = _fileVersionInfo.ProductName;
    Version = _fileVersionInfo.FileVersion;
    Comments = _fileVersionInfo.Comments;
    Company = _fileVersionInfo.CompanyName;
    Copyright = _fileVersionInfo.LegalCopyright;
  }

  /// <summary>
  /// The title of the application.
  /// </summary>
  public string? Title { get; }

  /// <summary>
  /// The version of the application.
  /// </summary>
  public string? Version { get; }

  /// <summary>
  /// The comments of the application.
  /// </summary>
  public string? Comments { get; }

  /// <summary>
  /// The company of the application.
  /// </summary>
  public string? Company { get; }

  /// <summary>
  /// The copyright of the application.
  /// </summary>
  public string? Copyright { get; }
}
