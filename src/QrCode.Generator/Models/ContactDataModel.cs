// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

using QrCode.Generator.Models.Base;

using static QRCoder.PayloadGenerator.ContactData;

namespace QrCode.Generator.Models;

/// <summary>
/// The contact data model class.
/// </summary>
public sealed class ContactDataModel : QrCodeModel
{
  private ContactOutputType _outputType;
  private string _firstName;
  private string _lastName;
  private AddressOrder _addressOrder;

  /// <summary>
  /// Initializes an instance of <see cref="ContactDataModel"/> class.
  /// </summary>
  public ContactDataModel()
  {
    _outputType = ContactOutputType.VCard3;
    _firstName = string.Empty;
    _lastName = string.Empty;
    _addressOrder = AddressOrder.Default;
  }

  /// <summary>
  /// The payload output type.
  /// </summary>
  public ContactOutputType OutputType
  {
    get => _outputType;
    set => SetProperty(ref _outputType, value);
  }

  /// <summary>
  /// The first name.
  /// </summary>
  [Required]
  public string FirstName
  {
    get => _firstName;
    set => SetPropertyAndValidate(ref _firstName, value);
  }

  /// <summary>
  /// The last name.
  /// </summary>
  [Required]
  public string LastName
  {
    get => _lastName;
    set => SetPropertyAndValidate(ref _lastName, value);
  }

  /// <summary>
  /// The display name.
  /// </summary>
  public string? NickName
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The normal phone number.
  /// </summary>
  [Phone]
  public string? Phone
  {
    get;
    set => SetPropertyAndValidate(ref field, value);
  }

  /// <summary>
  /// The mobile phone number.
  /// </summary>
  [Phone]
  public string? MobilePhone
  {
    get;
    set => SetPropertyAndValidate(ref field, value);
  }

  /// <summary>
  /// The office phone number.
  /// </summary>
  [Phone]
  public string? OfficePhone
  {
    get;
    set => SetPropertyAndValidate(ref field, value);
  }

  /// <summary>
  /// The E-Mail address.
  /// </summary>
  [EmailAddress]
  public string? Email
  {
    get;
    set => SetPropertyAndValidate(ref field, value);
  }

  /// <summary>
  /// The date of birth.
  /// </summary>
  public DateTime? Birthday
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  ///	Website / Homepage
  /// </summary>
  [Url]
  public string? WebSite
  {
    get;
    set => SetPropertyAndValidate(ref field, value);
  }

  /// <summary>
  /// The street.
  /// </summary>
  public string? Street
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The house number.
  /// </summary>
  public string? HouseNumber
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The city.
  /// </summary>
  public string? City
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The counrty.
  /// </summary>
  public string? Country
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The postal zip code.
  /// </summary>
  public string? ZipCode
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  ///	Memo text / notes.
  /// </summary>
  public string? Note
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// State / Region.
  /// </summary>
  public string? StateRegion
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// Defines the address order.
  /// </summary>
  /// <remarks>
  /// Specifies in which format the address is rendered.
  /// </remarks>
  public AddressOrder AddressOrder
  {
    get => _addressOrder;
    set => SetProperty(ref _addressOrder, value);
  }

  /// <summary>
  /// The organization / company.
  /// </summary>
  public string? Org
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <summary>
  /// The organization / company title.
  /// </summary>
  public string? OrgTitle
  {
    get;
    set => SetProperty(ref field, value);
  }

  /// <inheritdoc/>
  public override void FromTemplate(QrCodeModel template)
  {
    if (template is ContactDataModel contactDataModel)
    {
      OutputType = contactDataModel.OutputType;
      FirstName = contactDataModel.FirstName;
      LastName = contactDataModel.LastName;
      NickName = contactDataModel.NickName;
      Phone = contactDataModel.Phone;
      MobilePhone = contactDataModel.MobilePhone;
      OfficePhone = contactDataModel.OfficePhone;
      Email = contactDataModel.Email;
      Birthday = contactDataModel.Birthday;
      WebSite = contactDataModel.WebSite;
      Street = contactDataModel.Street;
      HouseNumber = contactDataModel.HouseNumber;
      City = contactDataModel.City;
      Country = contactDataModel.Country;
      ZipCode = contactDataModel.ZipCode;
      Note = contactDataModel.Note;
      StateRegion = contactDataModel.StateRegion;
      AddressOrder = contactDataModel.AddressOrder;
      Org = contactDataModel.Org;
      OrgTitle = contactDataModel.OrgTitle;
    }

    base.FromTemplate(template);
  }
}
