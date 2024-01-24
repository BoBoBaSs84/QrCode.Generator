using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.WiFi;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public class WifiCodeModelTests : UnitTestBase
{
  [TestMethod]
  public void WifiModelTest()
  {
    WifiCodeModel? model;

    model = GetService<WifiCodeModel>();

    Assert.IsNotNull(model);
    Assert.AreEqual(Authentication.WPA, model.Authentication);
    Assert.AreEqual(string.Empty, model.SSID);
    Assert.AreEqual(string.Empty, model.Password);
    Assert.AreEqual(false, model.Hidden);
    Assert.IsTrue(model.IsValid);
  }

  [TestMethod]
  public void WifiModelValidTest()
  {
    WifiCodeModel? model;

    model = new WifiCodeModel
    {
      SSID = "Hallo",
      Password = "Test123",
      Authentication = Authentication.WEP,
      Hidden = true
    };

    Assert.IsTrue(model.IsValid);
  }
}