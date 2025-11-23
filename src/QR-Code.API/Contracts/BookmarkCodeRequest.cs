// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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
