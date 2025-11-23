// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Drawing;

using BB84.Extensions;

using QRCode.API.Abstractions;
using QRCode.API.Contracts;
using QRCode.API.Contracts.Base;

using QRCoder;

using BookmarkData = QRCoder.PayloadGenerator.Bookmark;
using CalendarEventData = QRCoder.PayloadGenerator.CalendarEvent;
using ContactData = QRCoder.PayloadGenerator.ContactData;
using GiroCodeData = QRCoder.PayloadGenerator.Girocode;
using MailCodeData = QRCoder.PayloadGenerator.Mail;
using WiFiData = QRCoder.PayloadGenerator.WiFi;

namespace QRCode.API.Services;

/// <summary>
/// Represents a service for generating QR codes.
/// </summary>
internal sealed class QRCodeService : IQRCodeService
{
  public IResult GetBookmarkCode(BookmarkCodeRequest request)
  {
    BookmarkData generator = new(
      url: request.Url,
      title: request.Title
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  public IResult GetContactCode(ContactCodeRequest request)
  {
    ContactData generator = new(
      outputType: request.OutputType ?? ContactData.ContactOutputType.VCard3,
      firstname: request.FirstName,
      lastname: request.LastName,
      nickname: request.NickName,
      phone: request.Phone,
      mobilePhone: request.MobilePhone,
      workPhone: request.OfficePhone,
      email: request.Email,
      birthday: request.Birthday,
      website: request.WebSite,
      street: request.Street,
      houseNumber: request.HouseNumber,
      city: request.City,
      country: request.Country,
      zipCode: request.ZipCode,
      note: request.Note,
      stateRegion: request.StateRegion,
      addressOrder: request.AdressSortOrder ?? ContactData.AddressOrder.Default,
      org: request.Org,
      orgTitle: request.OrgTitle
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  public IResult GetEventCode(EventCodeRequest request)
  {
    CalendarEventData generator = new(
      subject: request.Subject,
      description: request.Description?.Replace("\r\n", @"\n"),
      location: request.Location?.Replace("\r\n", @"\n"),
      start: request.Start,
      end: request.End,
      allDayEvent: request.AllDay,
      encoding: request.Encoding
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  public IResult GetGiroCode(GiroCodeRequest request)
  {
    GiroCodeData generator = new(
      iban: request.IBAN,
      bic: request.BIC,
      name: request.Name,
      amount: request.Amount,
      remittanceInformation: request.Reference ?? string.Empty,
      typeOfRemittance: request.Type,
      purposeOfCreditTransfer: request.Purpose ?? string.Empty,
      messageToGirocodeUser: request.Message ?? string.Empty,
      version: request.Version,
      encoding: request.Encoding
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  public IResult GetMailCode(MailCodeRequest request)
  {
    MailCodeData generator = new(
      mailReceiver: request.Recipient,
      subject: request.Subject,
      message: request.Message,
      encoding: request.Encoding ?? MailCodeData.MailEncoding.MAILTO
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  public IResult GetWifiCode(WifiCodeRequest request)
  {
    WiFiData generator = new(
      ssid: request.SSID,
      password: request.Password,
      authenticationMode: request.Authentication,
      isHiddenSSID: request.Hidden
      );

    string payload = generator.ToString();

    return GenerateBarCode(request, payload);
  }

  private static IResult GenerateBarCode(CodeRequestBase request, string payload)
  {
    QRCodeGenerator.ECCLevel eccLevel = request.Level ?? QRCodeGenerator.ECCLevel.M;
    byte[] darkColor = request.ForegroundColor?.FromRGBHexString().ToRgbByteArray() ?? Color.Black.ToRgbByteArray();
    byte[] lightColor = request.BackgroundColor?.FromRGBHexString().ToRgbByteArray() ?? Color.White.ToRgbByteArray();

    QRCodeData codeData = new QRCodeGenerator()
      .CreateQrCode(payload, eccLevel);

    byte[] pngBytes = new BitmapByteQRCode(codeData)
      .GetGraphic(20, darkColor, lightColor);

    return Results.Bytes(pngBytes, "image/png");
  }
}
