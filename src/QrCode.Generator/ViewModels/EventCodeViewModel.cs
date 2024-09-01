using BB84.Extensions;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using QRCoder;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The event / calendar code view model;
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="exportService">The export service instance to use.</param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class EventCodeViewModel(IQrCodeService qrCodeService, IExportService<EventCodeModel> exportService, ITemplateService<EventCodeModel> templateService, EventCodeModel model)
  : QrCodeViewModel<EventCodeModel>(qrCodeService, exportService, templateService, model)
{
  /// <summary>
  /// The event encoding types to select from.
  /// </summary>
  public Tuple<string, EventEncoding>[] GetEncodingTypes
    => Model.Encoding.GetValues().AsTuple();

  /// <inheritdoc />
  protected override void SetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(
      subject: Model.Subject,
      description: Model.Description?.Replace("\r\n", @"\n"),
      location: Model.Location?.Replace("\r\n", @"\n"),
      start: Model.Start,
      end: Model.End,
      allDayEvent: Model.AllDay,
      encoding: Model.Encoding
      );

    Payload = generator.ToString();
  }
}
