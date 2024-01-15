using QRCoder;

using WIFI.QRCode.Builder.Interfaces.Services;
using WIFI.QRCode.Builder.Models;
using WIFI.QRCode.Builder.ViewModels.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace WIFI.QRCode.Builder.ViewModels;

/// <summary>
/// The calendar qr code view model;
/// </summary>
public sealed class EventViewModel : QrCodeViewModel
{
  private readonly IQrCodeService _qrCodeService;

  /// <summary>
  /// Initializes an instance of <see cref="EventViewModel"/> class.
  /// </summary>
  /// <param name="qrCodeService">The qr code service instance to use.</param>
  /// <param name="model">The model instance to use.</param>
  public EventViewModel(IQrCodeService qrCodeService, EventModel model) : base(qrCodeService)
  {
    _qrCodeService = qrCodeService;
    Model = model;
  }

  /// <summary>
  /// The model instance to use.
  /// </summary>
  public EventModel Model { get; }

  /// <summary>
  /// The event encoding types to select from.
  /// </summary>
  public Tuple<string, EventEncoding>[] EventEncodingTypes
    => [new("iCalComplete", EventEncoding.iCalComplete), new("Universal", EventEncoding.Universal)];

  /// <inheritdoc />
  protected override void SetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(Model.Subject, Model.Description, Model.Location, Model.Start, Model.End, Model.AllDay, Model.Encoding);
    Payload = generator.ToString();
  }
}
