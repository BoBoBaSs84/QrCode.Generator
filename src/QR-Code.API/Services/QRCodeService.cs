using System.Drawing;

using BB84.Extensions;

using QRCode.API.Abstractions;
using QRCode.API.Contracts;
using QRCode.API.Contracts.Base;

using QRCoder;

namespace QRCode.API.Services;

/// <summary>
/// Represents a service for generating QR codes.
/// </summary>
internal sealed class QRCodeService : IQRCodeService
{
  public IResult GetEventCode(EventCodeRequest request)
  {
    PayloadGenerator.CalendarEvent generator = new(
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

  public IResult GetWifiCode(WifiCodeRequest request)
  {
    PayloadGenerator.WiFi generator = new(
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
    QRCodeGenerator codeGenerator = new();
    QRCodeData codeData = codeGenerator.CreateQrCode(payload, eccLevel);
    BitmapByteQRCode bitmapCoder = new(codeData);
    byte[] pngBytes = bitmapCoder.GetGraphic(20, darkColor, lightColor);
    return Results.Bytes(pngBytes, "image/png");
  }
}
