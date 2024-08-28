using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.ContactData;

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
}