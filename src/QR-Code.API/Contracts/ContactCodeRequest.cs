using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.ContactData;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a contact QR code.
/// </summary>
public sealed class ContactCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the payload output type.
  /// </summary>
  public ContactOutputType? OutputType { get; init; } = ContactOutputType.VCard3;

  /// <summary>
  /// Gets or sets the first name.
  /// </summary>
  [Required] public required string FirstName { get; init; }

  /// <summary>
  /// Gets or sets the last name.
  /// </summary>
  [Required] public required string LastName { get; init; }

  /// <summary>
  /// Gets or sets the display name.
  /// </summary>
  public string? NickName { get; init; }

  /// <summary>
  /// Gets or sets the normal phone number.
  /// </summary>
  [Phone] public string? Phone { get; init; }

  /// <summary>
  /// Gets or sets the mobile phone number.
  /// </summary>
  [Phone] public string? MobilePhone { get; init; }

  /// <summary>
  /// Gets or sets the office phone number.
  /// </summary>
  [Phone] public string? OfficePhone { get; init; }

  /// <summary>
  /// Gets or sets the email address.
  /// </summary>
  [EmailAddress] public string? Email { get; init; }

  /// <summary>
  /// Gets or sets the date of birth.
  /// </summary>
  public DateTime? Birthday { get; init; }

  /// <summary>
  /// Gets or sets the website / homepage.
  /// </summary>
  [Url] public string? WebSite { get; init; }

  /// <summary>
  /// Gets or sets the street.
  /// </summary>
  public string? Street { get; init; }

  /// <summary>
  /// Gets or sets the house number.
  /// </summary>
  public string? HouseNumber { get; init; }

  /// <summary>
  /// Gets or sets the city.
  /// </summary>
  public string? City { get; init; }

  /// <summary>
  /// Gets or sets the country.
  /// </summary>
  public string? Country { get; init; }

  /// <summary>
  /// Gets or sets the postal zip code.
  /// </summary>
  public string? ZipCode { get; init; }

  /// <summary>
  /// Gets or sets the memo text / notes.
  /// </summary>
  public string? Note { get; init; }

  /// <summary>
  /// Gets or sets the state / region.
  /// </summary>
  public string? StateRegion { get; init; }

  /// <summary>
  /// Gets or sets the address order.
  /// </summary>
  /// <remarks>
  /// Specifies in which format the address is rendered.
  /// </remarks>
  public AddressOrder? AdressSortOrder { get; init; } = AddressOrder.Default;

  /// <summary>
  /// Gets or sets the organization / company.
  /// </summary>
  public string? Org { get; init; }

  /// <summary>
  /// Gets or sets the organization / company title.
  /// </summary>
  public string? OrgTitle { get; init; }
}
