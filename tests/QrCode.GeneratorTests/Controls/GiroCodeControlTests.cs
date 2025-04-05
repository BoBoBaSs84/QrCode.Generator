// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class GiroCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    GiroCodeControl control;

    control = GetService<GiroCodeControl>();

    Assert.IsNotNull(control);
  }
}