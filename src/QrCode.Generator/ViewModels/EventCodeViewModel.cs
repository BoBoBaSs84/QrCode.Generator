using System.IO;

using BB84.Extensions;
using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using Microsoft.Win32;

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
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed partial class EventCodeViewModel(IQrCodeService qrCodeService, ITemplateService<EventCodeModel> templateService, EventCodeModel model) : QrCodeViewModel(qrCodeService)
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

  /// <summary>
  /// The command the load a template into the current model.
  /// </summary>
  public IActionCommand<EventCodeModel> LoadTemplateCommand
    => new ActionCommand<EventCodeModel>(LoadTemplate);

  /// <summary>
  /// The command the create a template from the current model.
  /// </summary>
  public IActionCommand<EventCodeModel> SaveTemplateCommand
    => new ActionCommand<EventCodeModel>(SaveTemplate);

  /// <inheritdoc />
  protected override void SetPayLoad()
  {
    PayloadGenerator.CalendarEvent generator = new(
      subject: Model.Subject,
      description: Model.Description.Replace("\r\n", @"\n"),
      location: Model.Location.Replace("\r\n", @"\n"),
      start: Model.Start,
      end: Model.End,
      allDayEvent: Model.AllDay,
      encoding: Model.Encoding
      );

    Payload = generator.ToString();
  }

  private void SaveTemplate(EventCodeModel model)
  {
    string jsonContent = templateService.To(model);

    SaveFileDialog fileDialog = new()
    {
      Title = "Save template ...",
      Filter = "template files (*.json)|*.json",
      InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    };

    bool? result = fileDialog.ShowDialog();

    if (result.HasValue && result.Value.IsTrue())
      File.WriteAllText(fileDialog.FileName, jsonContent);
  }

  private void LoadTemplate(EventCodeModel model)
  {
    OpenFileDialog fileDialog = new()
    {
      Title = "Load template ...",
      Filter = "template files (*.json)|*.json",
      InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
    };

    bool? result = fileDialog.ShowDialog();

    if (result.HasValue && result.Value.IsTrue())
    {
      string fileContent = File.ReadAllText(fileDialog.FileName);
      EventCodeModel template = templateService.From(fileContent);

      model.Subject = template.Subject;
      model.Description = template.Description;
      model.Location = template.Location;
      model.Start = template.Start;
      model.End = template.End;
      model.AllDay = template.AllDay;
      model.Encoding = template.Encoding;
      model.ErrorCorrection = template.ErrorCorrection;
      model.BackgroundColor = template.BackgroundColor;
      model.ForegroundColor = template.ForegroundColor;

      model.Validate();
    }
  }
}
