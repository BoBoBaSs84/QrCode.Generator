using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.ViewModels.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The calendar qr code view model;
/// </summary>
/// <remarks>
/// Initializes an instance of <see cref="EventViewModel"/> class.
/// </remarks>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class EventViewModel(IQrCodeService qrCodeService, EventModel model) : QrCodeViewModel(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public EventModel Model { get => model; set => SetProperty(ref model, value); }

  /// <summary>
  /// The event encoding types to select from.
  /// </summary>
  public Tuple<string, EventEncoding>[] EventEncodingTypes
    => [new("iCalComplete", EventEncoding.iCalComplete), new("Universal", EventEncoding.Universal)];
}
