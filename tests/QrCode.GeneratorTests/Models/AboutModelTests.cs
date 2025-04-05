// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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
    Assert.IsNotNull(model.FrameworkName);
    Assert.IsNotNull(model.Repository);
  }
}