using System.Diagnostics.CodeAnalysis;
using System.IO;

using QrCode.Generator.Interfaces.Provider;

namespace QrCode.Generator.Provider;

/// <summary>
/// The file provider class.
/// </summary>
[ExcludeFromCodeCoverage(Justification = "Wrapper/Astraction class")]
internal sealed class FileProvider : IFileProvider
{
  public string ReadAllText(string path)
    => File.ReadAllText(path);

  public void WriteAllBytes(string path, byte[] bytes)
    => File.WriteAllBytes(path, bytes);

  public void WriteAllText(string path, string? contents)
    => File.WriteAllText(path, contents);
}
