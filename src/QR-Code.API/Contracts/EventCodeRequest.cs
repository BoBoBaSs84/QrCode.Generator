using System.ComponentModel.DataAnnotations;

using QRCode.API.Contracts.Base;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace QRCode.API.Contracts;

/// <summary>
/// Represents a request to generate a calendar event QR code.
/// </summary>
public sealed class EventCodeRequest : CodeRequestBase
{
  /// <summary>
  /// Gets or sets the subject / title of the calendar event.
  /// </summary>
  [Required, StringLength(100, MinimumLength = 1)]
  public required string Subject { get; init; }

  /// <summary>
  /// Gets or sets the description of the event.
  /// </summary>
  public string? Description { get; init; }

  /// <summary>
  /// Gets or sets the location of the event.
  /// </summary>
  public string? Location { get; init; }

  /// <summary>
  /// Gets or sets the start date and time of the event.
  /// </summary>
  [Required] public required DateTime Start { get; init; }

  /// <summary>
  /// Gets or sets the end date and time of the event.
  /// </summary>
  [Required] public required DateTime End { get; init; }

  /// <summary>
  /// Gets or sets a value indicating whether the event lasts all day.
  /// </summary>
  public bool AllDay { get; init; }

  /// <summary>
  /// Gets or sets the encoding format for the calendar event.
  /// </summary>
  [Required] public required EventEncoding Encoding { get; init; }
}
