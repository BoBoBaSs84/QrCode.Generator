// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Windows.Media;

using QrCode.Generator.Models.Base;

using static QRCoder.QRCodeGenerator;

namespace QrCode.GeneratorTests.Models.Base;

[TestClass]
public class QrCodeModelTests
{
  [TestMethod]
  public void QrCodeModelTest()
  {
    TestModel? model;

    model = new()
    {
      BackgroundColor = Colors.Red,
      ErrorCorrection = ECCLevel.H,
      ForegroundColor = Colors.Lime
    };

    Assert.IsNotNull(model);
    Assert.AreEqual(ECCLevel.H, model.ErrorCorrection);
    Assert.AreEqual(Colors.Lime, model.ForegroundColor);
    Assert.AreEqual(Colors.Red, model.BackgroundColor);
    Assert.IsTrue(model.IsValid);
  }

  private sealed class TestModel : QrCodeModel
  { }
}