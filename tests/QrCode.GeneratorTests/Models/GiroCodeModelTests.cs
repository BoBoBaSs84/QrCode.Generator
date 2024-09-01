using System.Windows.Media;

using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.Girocode;
using static QRCoder.QRCodeGenerator;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public sealed class GiroCodeModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";

  [TestMethod]
  public void GiroCodeModelTest()
  {
    GiroCodeModel? model;

    model = GetService<GiroCodeModel>();

    Assert.IsNotNull(model);
    Assert.AreEqual(string.Empty, model.IBAN);
    Assert.AreEqual(string.Empty, model.BIC);
    Assert.AreEqual(string.Empty, model.Name);
    Assert.AreEqual(0.01M, model.Amount);
    Assert.AreEqual(string.Empty, model.Reference);
    Assert.AreEqual(TypeOfRemittance.Structured, model.Type);
    Assert.AreEqual(string.Empty, model.Purpose);
    Assert.AreEqual(string.Empty, model.Message);
    Assert.AreEqual(GirocodeVersion.Version1, model.Version);
    Assert.AreEqual(GirocodeEncoding.ISO_8859_1, model.Encoding);
    Assert.IsFalse(model.IsValid);
  }

  [TestMethod]
  public void GiroCodeModelIsValidTest()
  {
    GiroCodeModel? model;

    model = new()
    {
      IBAN = "DE33100205000001194700",
      BIC = "BFSWDE33BER",
      Name = "Wikimedia",
      Amount = 14.99m,
      Reference = UnitTest,
      Type = TypeOfRemittance.Unstructured,
      Purpose = UnitTest,
      Message = UnitTest,
      Version = GirocodeVersion.Version2,
      Encoding = GirocodeEncoding.ISO_8859_2
    };

    Assert.IsTrue(model.IsValid);
  }

  [TestMethod]
  public void GiroCodeModelFromTemplateTest()
  {
    GiroCodeModel model = new();
    GiroCodeModel template = new()
    {
      IBAN = "DE33100205000001194700",
      BIC = "BFSWDE33BER",
      Name = "Wikimedia",
      Amount = 14.99m,
      Reference = UnitTest,
      Type = TypeOfRemittance.Unstructured,
      Purpose = UnitTest,
      Message = UnitTest,
      Version = GirocodeVersion.Version2,
      Encoding = GirocodeEncoding.ISO_8859_2,
      ErrorCorrection = ECCLevel.M,
      ForegroundColor = Colors.Black,
      BackgroundColor = Colors.White
    };

    model.FromTemplate(template);

    Assert.IsTrue(model.IsValid);
    Assert.AreEqual(template.IBAN, model.IBAN);
    Assert.AreEqual(template.BIC, model.BIC);
    Assert.AreEqual(template.Name, model.Name);
    Assert.AreEqual(template.Amount, model.Amount);
    Assert.AreEqual(template.Reference, model.Reference);
    Assert.AreEqual(template.Type, model.Type);
    Assert.AreEqual(template.Purpose, model.Purpose);
    Assert.AreEqual(template.Message, model.Message);
    Assert.AreEqual(template.Version, model.Version);
    Assert.AreEqual(template.Encoding, model.Encoding);
    Assert.AreEqual(template.ErrorCorrection, model.ErrorCorrection);
    Assert.AreEqual(template.ForegroundColor, model.ForegroundColor);
    Assert.AreEqual(template.BackgroundColor, model.BackgroundColor);
  }
}