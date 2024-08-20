using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.CalendarEvent;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public sealed class EventCodeModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";

  [TestMethod]
  public void EventModelTest()
  {
    EventCodeModel? model;

    model = GetService<EventCodeModel>();

    Assert.IsNotNull(model);
    Assert.AreEqual(string.Empty, model.Subject);
    Assert.AreEqual(string.Empty, model.Description);
    Assert.AreEqual(string.Empty, model.Location);
    Assert.AreNotEqual(DateTime.Today, model.Start);
    Assert.AreNotEqual(DateTime.Today, model.End);
    Assert.AreEqual(false, model.AllDay);
    Assert.AreEqual(EventEncoding.iCalComplete, model.Encoding);
  }

  [TestMethod]
  public void EventModelIsValidTest()
  {
    EventCodeModel? model;

    model = new()
    {
      Subject = UnitTest,
      Description = UnitTest,
      Location = UnitTest,
      Start = DateTime.Today,
      End = DateTime.Today,
      AllDay = true,
      Encoding = EventEncoding.Universal
    };

    Assert.IsTrue(model.IsValid);
  }
}