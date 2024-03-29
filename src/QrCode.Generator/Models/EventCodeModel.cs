﻿using System.ComponentModel.DataAnnotations;

using BB84.Extensions;
using BB84.Notifications.Attributes;

using QrCode.Generator.Models.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace QrCode.Generator.Models;

/// <summary>
/// The event qr code model;
/// </summary>
public sealed class EventCodeModel : QrCodeModel
{
  private string _subject;
  private string _description;
  private string _location;
  private DateTime _start;
  private DateTime _end;
  private bool _allDay;
  private EventEncoding _encoding;

  /// <summary>
  /// Initializes an instance of <see cref="EventCodeModel"/> class.
  /// </summary>
  public EventCodeModel()
  {
    _subject = string.Empty;
    _description = string.Empty;
    _location = string.Empty;
    _start = DateTime.Today.StartOfWeek().AddHours(6);
    _end = DateTime.Today.EndOfWeek().AddHours(18);
    _allDay = false;
    _encoding = EventEncoding.iCalComplete;
  }

  /// <summary>
  /// The subject / title of the calender event.
  /// </summary>
  [Required(AllowEmptyStrings = false), StringLength(100, MinimumLength = 1)]
  [NotifyChanged(nameof(IsValid))]
  public string Subject
  {
    get => _subject;
    set => SetPropertyAndValidate(ref _subject, value);
  }

  /// <summary>
  /// The description of the event.
  /// </summary>
  public string Description
  {
    get => _description;
    set => SetProperty(ref _description, value);
  }

  /// <summary>
  /// The location (lat:long or address) of the event.
  /// </summary>
  public string Location
  {
    get => _location;
    set => SetProperty(ref _location, value);
  }

  /// <summary>
  /// The start time of the event.
  /// </summary>
  [Required]
  [NotifyChanged(nameof(IsValid))]
  public DateTime Start
  {
    get => _start;
    set => SetPropertyAndValidate(ref _start, value);
  }

  /// <summary>
  /// The end time of the event.
  /// </summary>
  [Required]
  [NotifyChanged(nameof(IsValid))]
  public DateTime End
  {
    get => _end;
    set => SetPropertyAndValidate(ref _end, value);
  }

  /// <summary>
  /// Is it a full day event?
  /// </summary>
  public bool AllDay
  {
    get => _allDay;
    set => SetProperty(ref _allDay, value);
  }

  /// <summary>
  /// Type of encoding (universal or iCal)
  /// </summary>
  /// <remarks>
  /// Apple users you should use <see cref="EventEncoding.iCalComplete"/> instead
  /// of <see cref="EventEncoding.Universal"/> as encoding.
  /// </remarks>
  [Required]
  [NotifyChanged(nameof(IsValid))]
  public EventEncoding Encoding
  {
    get => _encoding;
    set => SetProperty(ref _encoding, value);
  }
}
