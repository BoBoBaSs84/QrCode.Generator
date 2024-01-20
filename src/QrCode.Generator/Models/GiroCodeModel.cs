﻿using System.ComponentModel.DataAnnotations;

using BB84.Extensions;

using QrCode.Generator.Models.Base;

using static QRCoder.PayloadGenerator.Girocode;

namespace QrCode.Generator.Models;

/// <summary>
/// The giro code model class.
/// </summary>
public sealed class GiroCodeModel : QrCodeModel
{
  private string _iban;
  private string _bic;
  private string _name;
  private decimal _amount;
  private string _reference;
  private TypeOfRemittance _type;
  private string _purpose;
  private string _message;
  private GirocodeVersion _version;
  private GirocodeEncoding _encoding;
  private bool _isValid;

  /// <summary>
  /// Initializes an instance of <see cref="GiroCodeModel"/> class.
  /// </summary>
  public GiroCodeModel()
  {
    _iban = string.Empty;
    _bic = string.Empty;
    _name = string.Empty;
    _amount = 0.01M;
    _reference = string.Empty;
    _purpose = string.Empty;
    _message = string.Empty;
    _encoding = GirocodeEncoding.ISO_8859_1;

    PropertyChanged += (s, e) => IsValid = HasErrors.IsFalse();
  }

  /// <summary>
  /// Account number of the Beneficiary. Only IBAN is allowed.
  /// </summary>
  [Required]
  public string IBAN
  {
    get => _iban;
    set => SetProperty(ref _iban, value);
  }

  /// <summary>
  /// BIC of the Beneficiary Bank.
  /// </summary>
  [Required]
  public string BIC
  {
    get => _bic;
    set => SetProperty(ref _bic, value);
  }

  /// <summary>
  /// Name of the Beneficiary.
  /// </summary>
  [Required]
  public string Name
  {
    get => _name;
    set => SetProperty(ref _name, value);
  }

  /// <summary>
  /// Amount of the Credit Transfer in Euro.
  /// </summary>
  /// <remarks>
  /// Amount must be more than 0.01 and less than 999999999.99
  /// </remarks>
  [Range(0.01, 999999999.99)]
  public decimal Amount
  {
    get => _amount;
    set => SetProperty(ref _amount, value);
  }

  /// <summary>
  /// Remittance Information (Purpose-/reference text).
  /// </summary>  
  [StringLength(140)]
  public string Reference
  {
    get => _reference;
    set => SetProperty(ref _reference, value);
  }

  /// <summary>
  /// Type of remittance information. Either structured and max. 35 chars or unstructured and max. 140 chars.
  /// </summary>
  /// <remarks>
  /// (e.g. ISO 11649 RF Creditor Reference)
  /// </remarks>
  public TypeOfRemittance Type
  {
    get => _type;
    set => SetProperty(ref _type, value);
  }

  /// <summary>
  /// Purpose of the Credit Transfer (optional)
  /// </summary>
  public string Purpose
  {
    get => _purpose;
    set => SetProperty(ref _purpose, value);
  }

  /// <summary>
  /// Beneficiary to originator information. (optional)
  /// </summary>
  public string Message
  {
    get => _message;
    set => SetProperty(ref _message, value);
  }

  /// <summary>
  /// Girocode version.
  /// </summary>
  [Required]
  public GirocodeVersion Version
  {
    get => _version;
    set => SetProperty(ref _version, value);
  }

  /// <summary>
  /// Encoding of the Girocode payload.
  /// </summary>
  [Required]
  public GirocodeEncoding Encoding
  {
    get => _encoding;
    set => SetProperty(ref _encoding, value);
  }

  /// <inheritdoc/>
  public override bool IsValid
  {
    get => _isValid;
    protected set => SetProperty(ref _isValid, value);
  }
}
