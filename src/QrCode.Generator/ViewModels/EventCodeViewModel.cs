using BB84.Extensions;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using QRCoder;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The calendar qr code view model;
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class EventCodeViewModel(IQrCodeService qrCodeService, EventCodeModel model) : QrCodeViewModel(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public EventCodeModel Model { get; } = model;

  /// <summary>
  /// The event encoding types to select from.
  /// </summary>
  public Tuple<string, EventEncoding>[] GetEncodingTypes
    => Model.Encoding.GetValues().AsTuple();

  /// <inheritdoc />
  protected override void SetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(Model.Subject, Model.Description, Model.Location, Model.Start, Model.End, Model.AllDay, Model.Encoding);
    Payload = generator.ToString();
  }
}
