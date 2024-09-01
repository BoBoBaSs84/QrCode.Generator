using System.Windows.Media;

using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.ContactData;
using static QRCoder.QRCodeGenerator;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public sealed class ContactDataModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";

  [TestMethod]
  public void ContactDataModelTest()
  {
    ContactDataModel? model;

    model = GetService<ContactDataModel>();

    Assert.IsNotNull(model);
    Assert.AreEqual(ContactOutputType.VCard3, model.OutputType);
    Assert.AreEqual(string.Empty, model.FirstName);
    Assert.AreEqual(string.Empty, model.LastName);
    Assert.AreEqual(null, model.NickName);
    Assert.AreEqual(null, model.Phone);
    Assert.AreEqual(null, model.MobilePhone);
    Assert.AreEqual(null, model.OfficePhone);
    Assert.AreEqual(null, model.Email);
    Assert.AreEqual(null, model.Birthday);
    Assert.AreEqual(null, model.WebSite);
    Assert.AreEqual(null, model.Street);
    Assert.AreEqual(null, model.HouseNumber);
    Assert.AreEqual(null, model.City);
    Assert.AreEqual(null, model.Country);
    Assert.AreEqual(null, model.ZipCode);
    Assert.AreEqual(null, model.Note);
    Assert.AreEqual(null, model.StateRegion);
    Assert.AreEqual(AddressOrder.Default, model.AddressOrder);
    Assert.AreEqual(null, model.Org);
    Assert.AreEqual(null, model.OrgTitle);
    Assert.IsFalse(model.IsValid);
  }

  [TestMethod]
  public void ContactDataModelIsValidTest()
  {
    ContactDataModel? model;

    model = new()
    {
      OutputType = ContactOutputType.MeCard,
      FirstName = UnitTest,
      LastName = UnitTest,
      NickName = UnitTest,
      Phone = "+1 505-644-9930",
      MobilePhone = "+1 203-337-9287",
      OfficePhone = "+1 505-288-3106",
      Email = "UnitTest@UnitTest.org",
      Birthday = DateTime.Today,
      WebSite = "http://www.UnitTest.org",
      Street = UnitTest,
      HouseNumber = UnitTest,
      City = UnitTest,
      Country = UnitTest,
      ZipCode = UnitTest,
      Note = UnitTest,
      StateRegion = UnitTest,
      AddressOrder = AddressOrder.Reversed,
      Org = UnitTest,
      OrgTitle = UnitTest
    };

    Assert.IsTrue(model.IsValid);
  }

  [TestMethod]
  public void EventModelFromTemplateTest()
  {
    ContactDataModel model = new();
    ContactDataModel template = new()
    {
      OutputType = ContactOutputType.MeCard,
      FirstName = UnitTest,
      LastName = UnitTest,
      NickName = UnitTest,
      Phone = "+1 505-644-9930",
      MobilePhone = "+1 203-337-9287",
      OfficePhone = "+1 505-288-3106",
      Email = "UnitTest@UnitTest.org",
      Birthday = DateTime.Today,
      WebSite = "http://www.UnitTest.org",
      Street = UnitTest,
      HouseNumber = UnitTest,
      City = UnitTest,
      Country = UnitTest,
      ZipCode = UnitTest,
      Note = UnitTest,
      StateRegion = UnitTest,
      AddressOrder = AddressOrder.Reversed,
      Org = UnitTest,
      OrgTitle = UnitTest,
      ErrorCorrection = ECCLevel.M,
      ForegroundColor = Colors.Black,
      BackgroundColor = Colors.White
    };

    model.FromTemplate(template);

    Assert.IsTrue(model.IsValid);
    Assert.AreEqual(template.OutputType, model.OutputType);
    Assert.AreEqual(template.FirstName, model.FirstName);
    Assert.AreEqual(template.LastName, model.LastName);
    Assert.AreEqual(template.NickName, model.NickName);
    Assert.AreEqual(template.Phone, model.Phone);
    Assert.AreEqual(template.MobilePhone, model.MobilePhone);
    Assert.AreEqual(template.OfficePhone, model.OfficePhone);
    Assert.AreEqual(template.Email, model.Email);
    Assert.AreEqual(template.Birthday, model.Birthday);
    Assert.AreEqual(template.WebSite, model.WebSite);
    Assert.AreEqual(template.Street, model.Street);
    Assert.AreEqual(template.HouseNumber, model.HouseNumber);
    Assert.AreEqual(template.City, model.City);
    Assert.AreEqual(template.Country, model.Country);
    Assert.AreEqual(template.ZipCode, model.ZipCode);
    Assert.AreEqual(template.Note, model.Note);
    Assert.AreEqual(template.StateRegion, model.StateRegion);
    Assert.AreEqual(template.AddressOrder, model.AddressOrder);
    Assert.AreEqual(template.Org, model.Org);
    Assert.AreEqual(template.OrgTitle, model.OrgTitle);
    Assert.AreEqual(template.ErrorCorrection, model.ErrorCorrection);
    Assert.AreEqual(template.ForegroundColor, model.ForegroundColor);
    Assert.AreEqual(template.BackgroundColor, model.BackgroundColor);
  }
}