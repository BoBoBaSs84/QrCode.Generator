using System.Windows.Media;

using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.CalendarEvent;
using static QRCoder.QRCodeGenerator;

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

  [TestMethod]
  public void EventModelFromTemplateTest()
  {
    EventCodeModel model = GetService<EventCodeModel>();
    EventCodeModel template = new()
    {
      Subject = UnitTest,
      Description = UnitTest,
      Location = UnitTest,
      Start = DateTime.Today,
      End = DateTime.Today,
      AllDay = true,
      Encoding = EventEncoding.Universal,
      ErrorCorrection = ECCLevel.M,
      ForegroundColor = Colors.Black,
      BackgroundColor = Colors.White,
    };

    model.FromTemplate(template);

    Assert.IsTrue(model.IsValid);
    Assert.AreEqual(template.Subject, model.Subject);
    Assert.AreEqual(template.Description, model.Description);
    Assert.AreEqual(template.Location, model.Location);
    Assert.AreEqual(template.Start, model.Start);
    Assert.AreEqual(template.End, model.End);
    Assert.AreEqual(template.AllDay, model.AllDay);
    Assert.AreEqual(template.Encoding, model.Encoding);
    Assert.AreEqual(template.ErrorCorrection, model.ErrorCorrection);
    Assert.AreEqual(template.ForegroundColor, model.ForegroundColor);
    Assert.AreEqual(template.BackgroundColor, model.BackgroundColor);
  }
}