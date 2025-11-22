using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.Mail;

namespace QRCode.API.Contracts;

public sealed class MailCodeRequest : CodeRequestBase
{
  [Required, EmailAddress] public required string Recipient { get; init; }

  [Required] public required string Subject { get; init; }

  [Required] public required string Message { get; init; }

  public MailEncoding? Encoding { get; init; }
}
