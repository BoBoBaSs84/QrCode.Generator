using BB84.Notifications.Attributes;

using QRCoder;

using WIFI.QRCode.Builder.Models.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace WIFI.QRCode.Builder.Models;

/// <summary>
/// The event qr code model;
/// </summary>
public sealed class EventModel : QrCodeModel
{
  private string _subject;
  private string _description;
  private string _location;
  private DateTime _start;
  private DateTime _end;
  private bool _allDay;
  private EventEncoding _encoding;

  /// <summary>
  /// Initializes an instance of <see cref="EventModel"/> class.
  /// </summary>
  public EventModel()
  {
    _subject = string.Empty;
    _description = string.Empty;
    _location = string.Empty;
    _start = DateTime.Today.AddDays(1).AddHours(6);
    _end = DateTime.Today.AddDays(1).AddHours(18);
    _allDay = false;
    _encoding = EventEncoding.iCalComplete;
  }

  /// <summary>
  /// The subject / title of the calender event.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public string Subject { get => _subject; set => SetProperty(ref _subject, value); }

  /// <summary>
  /// The description of the event.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public string Description { get => _description; set => SetProperty(ref _description, value); }

  /// <summary>
  /// The location (lat:long or address) of the event.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public string Location { get => _location; set => SetProperty(ref _location, value); }

  /// <summary>
  /// The start time of the event.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public DateTime Start { get => _start; set => SetProperty(ref _start, value); }

  /// <summary>
  /// The end time of the event.
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public DateTime End { get => _end; set => SetProperty(ref _end, value); }

  /// <summary>
  /// Is it a full day event?
  /// </summary>
  [NotifyChanged(nameof(PayLoad))]
  public bool AllDay { get => _allDay; set => SetProperty(ref _allDay, value); }

  /// <summary>
  /// Type of encoding (universal or iCal)
  /// </summary>
  /// <remarks>
  /// Apple users you should use <see cref="EventEncoding.iCalComplete"/> instead
  /// of <see cref="EventEncoding.Universal"/> as encoding.
  /// </remarks>
  [NotifyChanged(nameof(PayLoad))]
  public EventEncoding Encoding { get => _encoding; set => SetProperty(ref _encoding, value); }

  /// <inheritdoc cref="QrCodeModel.PayLoad"/>
  public override string PayLoad => GetPayLoad();

  private string GetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(Subject, Description, Location, Start, End, AllDay, Encoding);
    return generator.ToString();
  }
}
