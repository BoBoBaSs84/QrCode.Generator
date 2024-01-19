using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public class WifiModelTests : UnitTestBase
{
  [TestMethod]
  public void WifiModelTest()
  {
    WifiModel? model;

    model = GetService<WifiModel>();

    Assert.IsNotNull(model);
    Assert.AreEqual(Authentication.WPA, model.Authentication);
    Assert.AreEqual(string.Empty, model.SSID);
    Assert.AreEqual(string.Empty, model.Password);
    Assert.AreEqual(false, model.Hidden);
    Assert.AreEqual(false, model.IsValid);
  }

  [TestMethod]
  public void WifiModelValidTest()
  {
    WifiModel? model;

    model = new WifiModel
    {
      SSID = "Hallo",
      Password = "Test123",
      Authentication = Authentication.WEP,
      Hidden = true
    };

    Assert.IsTrue(model.IsValid);
  }
}