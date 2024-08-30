using BB84.Extensions;

using QrCode.Generator.Extensions;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels.Base;

using QRCoder;

using static QRCoder.PayloadGenerator.ContactData;

namespace QrCode.Generator.ViewModels;

/// <summary>
/// The contact data view model class.
/// </summary>
/// <param name="qrCodeService"></param>
/// <param name="templateService">The template service instance to use.</param>
/// <param name="model">The model instance to use.</param>
public sealed class ContactDataViewModel(IQrCodeService qrCodeService, ITemplateService<ContactDataModel> templateService, ContactDataModel model)
  : QrCodeViewModel<ContactDataModel>(qrCodeService)
{
  /// <summary>
  /// The model instance to use.
  /// </summary>
  public ContactDataModel Model { get; } = model;

  /// <summary>
  /// The address order types to select from.
  /// </summary>
  public Tuple<string, AddressOrder>[] AddressOrderTypes
    => Model.AddressOrder.GetValues().AsTuple();

  /// <summary>
  /// The contact output types to select from.
  /// </summary>
  public Tuple<string, ContactOutputType>[] ContactOutputTypes
    => Model.OutputType.GetValues().AsTuple();

  /// <inheritdoc/>
  public override void LoadTemplate(ContactDataModel model)
  {
    string fileContent = templateService.Load(LoadPath);
    ContactDataModel template = templateService.From(fileContent);
    model.FromTemplate(template);
  }

  /// <inheritdoc/>
  public override void SaveTemplate(ContactDataModel model)
  {
    string jsonContent = templateService.To(model);
    templateService.Save(SavePath, jsonContent);
  }

  /// <inheritdoc/>
  protected override void SetPayLoad()
  {
    PayloadGenerator.ContactData generator = new(
      Model.OutputType, Model.FirstName, Model.LastName, Model.NickName, Model.Phone,
      Model.MobilePhone, Model.OfficePhone, Model.Email, Model.Birthday, Model.WebSite,
      Model.Street, Model.HouseNumber, Model.City, Model.ZipCode, Model.Country,
      Model.Note, Model.StateRegion, Model.AddressOrder, Model.Org, Model.OrgTitle
      );

    Payload = generator.ToString();
  }
}
