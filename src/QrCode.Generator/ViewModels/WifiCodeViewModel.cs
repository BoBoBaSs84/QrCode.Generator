using BB84.Extensions;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using QRCoder;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The wifi qr code view model class.
/// </summary>
/// <param name="qrCodeService">The qr code service instance to use.</param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class WifiCodeViewModel(IQrCodeService qrCodeService, ITemplateService<WifiCodeModel> templateService, WifiCodeModel model) : QrCodeViewModel<WifiCodeModel>(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public WifiCodeModel Model { get; } = model;

  /// <summary>
  /// The authentication types to select from.
  /// </summary>
  public Tuple<string, Authentication>[] AuthenticationTypes
    => Model.Authentication.GetValues().AsTuple();

  /// <inheritdoc/>
  public override void LoadTemplate(WifiCodeModel model)
  {
    string fileContent = templateService.Load(LoadPath);
    WifiCodeModel template = templateService.From(fileContent);
    model.FromTemplate(template);
  }

  /// <inheritdoc/>
  public override void SaveTemplate(WifiCodeModel model)
  {
    string jsonContent = templateService.To(model);
    templateService.Save(SavePath, jsonContent);
  }

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    PayloadGenerator.WiFi generator = new(Model.SSID, Model.Password, Model.Authentication, Model.Hidden);
    Payload = generator.ToString();
  }
}
