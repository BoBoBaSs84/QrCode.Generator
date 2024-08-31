using System.ComponentModel;

namespace QrCode.Generator.Enumerators;

/// <summary>
/// The export type enumerator.
/// </summary>
public enum ExportType
{
  /// <summary>
  /// Portable Network Graphics
  /// </summary>
  [Description("Portable Network Graphics")]
  PNG = 1,
  /// <summary>
  /// Joint Photographic Experts Group
  /// </summary>
  [Description("Joint Photographic Experts Group")]
  JPEG = 2,
  /// <summary>
  /// Scalable Vector Graphics
  /// </summary>
  [Description("Scalable Vector Graphics")]
  SVG = 3,
}
