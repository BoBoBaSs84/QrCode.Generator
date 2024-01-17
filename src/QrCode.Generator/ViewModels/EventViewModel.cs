using BB84.Extensions;

using QRCoder;

using WIFI.QRCode.Builder.Extensions;
using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.ViewModels.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The calendar qr code view model;
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class EventViewModel(IQrCodeService qrCodeService, EventModel model) : QrCodeViewModel(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public EventModel Model { get; } = model;

  /// <summary>
  /// The event encoding types to select from.
  /// </summary>
  public static Tuple<string, EventEncoding>[] GetEncodingTypes
    => EventEncoding.Universal.GetValues().AsTuple();

  /// <inheritdoc />
  protected override void SetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(Model.Subject, Model.Description, Model.Location, Model.Start, Model.End, Model.AllDay, Model.Encoding);
    Payload = generator.ToString();
  }
}
