using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a bookmark QR code.
/// </summary>
public sealed class BookmarkCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the URL of the bookmark.
  /// </summary>
  [Required, Url] public required string Url { get; init; }

  /// <summary>
  /// Gets or sets the title of the bookmark.
  /// </summary>
  [Required] public required string Title { get; init; }
}
