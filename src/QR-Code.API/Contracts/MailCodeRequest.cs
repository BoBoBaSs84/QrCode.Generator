// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.Mail;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a mail QR code.
/// </summary>
public sealed class MailCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the recipient email address.
  /// </summary>
  [Required, EmailAddress] public required string Recipient { get; init; }

  /// <summary>
  /// Gets or sets the subject of the email.
  /// </summary>
  [Required] public required string Subject { get; init; }

  /// <summary>
  /// Gets or sets the body message of the email.
  /// </summary>
  [Required] public required string Message { get; init; }

  /// <summary>
  /// Gets or sets the encoding format for the mail.
  /// </summary>
  public MailEncoding? Encoding { get; init; }
}
