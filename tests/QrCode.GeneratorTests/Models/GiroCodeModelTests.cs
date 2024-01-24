using QrCode.Generator.Models;

using static QRCoder.PayloadGenerator.Girocode;

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
    Assert.IsTrue(model.IsValid);
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
}