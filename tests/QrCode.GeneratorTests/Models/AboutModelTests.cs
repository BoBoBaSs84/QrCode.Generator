using QrCode.Generator.Models;

namespace QrCode.GeneratorTests.Models;

[TestClass]
public class AboutModelTests : UnitTestBase
{
  [TestMethod]
  public void AboutModelTest()
  {
    AboutModel? model;

    model = GetService<AboutModel>();

    Assert.IsNotNull(model);
    Assert.IsNotNull(model.Copyright);
    Assert.IsNotNull(model.Company);
    Assert.IsNotNull(model.Comments);
    Assert.IsNotNull(model.Title);
    Assert.IsNotNull(model.Version);
  }
}