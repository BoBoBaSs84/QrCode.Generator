using BB84.Extensions;
using BB84.Notifications.Commands;
using BB84.Notifications.Interfaces.Commands;

using Microsoft.Win32;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Interfaces.ViewModels;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using static QRCoder.PayloadGenerator;
using static QRCoder.PayloadGenerator.Girocode;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The giro code view model class.
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class GiroCodeViewModel(IQrCodeService qrCodeService, ITemplateService<GiroCodeModel> templateService, GiroCodeModel model)
  : QrCodeViewModel(qrCodeService), ITemplate<GiroCodeModel>
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public GiroCodeModel Model { get; } = model;

  /// <summary>
  /// The remittance types to select from.
  /// </summary>
  public Tuple<string, TypeOfRemittance>[] ReferenceTypes
    => Model.Type.GetValues().AsTuple();

  /// <summary>
  /// The giro version types to select from.
  /// </summary>
  public Tuple<string, GirocodeVersion>[] VersionTypes
    => Model.Version.GetValues().AsTuple();

  /// <summary>
  /// The giro encoding types to select from.
  /// </summary>
  public Tuple<string, GirocodeEncoding>[] EncodingTypes
    => Model.Encoding.GetValues().AsTuple();

  /// <inheritdoc />
  public IActionCommand<GiroCodeModel> LoadTemplateCommand
    => new ActionCommand<GiroCodeModel>(LoadTemplate);

  /// <inheritdoc />
  public IActionCommand<GiroCodeModel> SaveTemplateCommand
    => new ActionCommand<GiroCodeModel>(SaveTemplate);

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    Girocode generator = new(Model.IBAN, Model.BIC, Model.Name, Model.Amount, Model.Reference,
      Model.Type, Model.Purpose, Model.Message, Model.Version, Model.Encoding);

    Payload = generator.ToString();
  }

  private void LoadTemplate(GiroCodeModel model)
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
      string fileContent = templateService.Load(fileDialog.FileName);
      GiroCodeModel template = templateService.From(fileContent);

      model.IBAN = template.IBAN;
      model.BIC = template.BIC;
      model.Name = template.Name;
      model.Amount = template.Amount;
      model.Reference = template.Reference;
      model.Type = template.Type;
      model.Purpose = template.Purpose;
      model.Message = template.Message;
      model.Version = template.Version;
      model.Encoding = template.Encoding;
    }
  }

  private void SaveTemplate(GiroCodeModel model)
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
      templateService.Save(fileDialog.FileName, jsonContent);
  }
}
