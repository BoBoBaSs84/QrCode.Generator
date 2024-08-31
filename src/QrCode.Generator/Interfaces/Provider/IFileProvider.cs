using System.IO;

namespace QrCode.Generator.Interfaces.Provider;

/// <summary>
/// The file provider interface.
/// Serves for the abstraction of <see cref="File"/> methods.
/// </summary>
public interface IFileProvider
{
  /// <inheritdoc cref="File.ReadAllText(string)"/>
  string ReadAllText(string path);

  /// <inheritdoc cref="File.WriteAllBytes(string, byte[])"/>
  void WriteAllBytes(string path, byte[] bytes);

  /// <inheritdoc cref="File.WriteAllText(string, string?)"/>
  void WriteAllText(string path, string? contents);
}
