using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

namespace QRCode.API.Contracts;

public sealed class BookmarkCodeRequest : CodeRequestBase
{
  [Required, Url] public required string Url { get; init; }

  [Required] public required string Title { get; init; }
}
