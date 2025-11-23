// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

using static QRCoder.QRCodeGenerator;

namespace QRCode.API.Contracts.Base;

/// <summary>
/// Represents the base class for code generation requests.
/// </summary>
public abstract class CodeRequestBase
{
  /// <summary>
  /// Gets or sets the error correction level to use.
  /// </summary>
  public ECCLevel? Level { get; init; }

  /// <summary>
  /// Gets or sets the foreground color to use. Should be in hex format (e.g., #000000 for black).
  /// </summary>
  [MaxLength(7)]
  public string? ForegroundColor { get; init; }

  /// <summary>
  /// Gets or sets the background color to use. Should be in hex format (e.g., #FFFFFF for white).
  /// </summary>
  [MaxLength(7)]
  public string? BackgroundColor { get; init; }
}
