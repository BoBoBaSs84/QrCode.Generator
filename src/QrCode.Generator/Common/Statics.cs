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
}
