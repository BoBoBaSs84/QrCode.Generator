using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.Girocode;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a Girocode QR code for SEPA credit transfers.
/// </summary>
public sealed class GiroCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the account number of the beneficiary. Only IBAN is allowed.
  /// </summary>
  [Required]
  [RegularExpression(@"^[a-zA-Z]{2}[0-9]{2}([a-zA-Z0-9]?){16,30}$")]
  public required string IBAN { get; init; }

  /// <summary>
  /// Gets or sets the BIC of the beneficiary bank.
  /// </summary>
  [Required]
  [RegularExpression(@"^[A-Z0-9]{4}[A-Z]{2}[A-Z0-9]{2}(?:[A-Z0-9]{3})?$")]
  public required string BIC { get; init; }

  /// <summary>
  /// Gets or sets the name of the beneficiary.
  /// </summary>
  [Required]
  public required string Name { get; init; }

  /// <summary>
  /// Gets or sets the amount of the credit transfer in Euro.
  /// </summary>
  /// <remarks>
  /// Amount must be more than 0.01 and less than 999999999.99
  /// </remarks>
  [Range(0.01, 999999999.99)]
  public decimal Amount { get; init; } = 0.01M;

  /// <summary>
  /// Gets or sets the remittance information (purpose/reference text).
  /// </summary>
  [StringLength(140)]
  public string? Reference { get; init; }

  /// <summary>
  /// Gets or sets the type of remittance information.
  /// </summary>
  /// <remarks>
  /// Either structured and max. 35 chars or unstructured and max. 140 chars (e.g. ISO 11649 RF Creditor Reference).
  /// </remarks>
  [Required]
  public required TypeOfRemittance Type { get; init; }

  /// <summary>
  /// Gets or sets the purpose of the credit transfer (optional).
  /// </summary>
  public string? Purpose { get; init; }

  /// <summary>
  /// Gets or sets the beneficiary to originator information (optional).
  /// </summary>
  public string? Message { get; init; }

  /// <summary>
  /// Gets or sets the Girocode version.
  /// </summary>
  [Required]
  public required GirocodeVersion Version { get; init; }

  /// <summary>
  /// Gets or sets the encoding of the Girocode payload.
  /// </summary>
  [Required]
  public required GirocodeEncoding Encoding { get; init; }
}