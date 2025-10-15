// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows.Media;

using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.WiFi;
using static QRCoder.QRCodeGenerator;

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
    Assert.IsFalse(model.Hidden);
    Assert.IsFalse(model.IsValid);
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

  [TestMethod]
  public void WifiModelFromTemplateTest()
  {
    WifiCodeModel model = new();
    WifiCodeModel template = new()
    {
      SSID = "Hallo",
      Password = "Test123",
      Authentication = Authentication.WPA2,
      Hidden = true,
      ErrorCorrection = ECCLevel.M,
      ForegroundColor = Colors.Black,
      BackgroundColor = Colors.White
    };

    model.FromTemplate(template);

    Assert.IsTrue(model.IsValid);
    Assert.AreEqual(template.SSID, model.SSID);
    Assert.AreEqual(template.Password, model.Password);
    Assert.AreEqual(template.Authentication, model.Authentication);
    Assert.AreEqual(template.Hidden, model.Hidden);
    Assert.AreEqual(template.ErrorCorrection, model.ErrorCorrection);
    Assert.AreEqual(template.ForegroundColor, model.ForegroundColor);
    Assert.AreEqual(template.BackgroundColor, model.BackgroundColor);
  }
}