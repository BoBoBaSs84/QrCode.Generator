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
public sealed class WifiCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    WifiCodeControl control;

    control = GetService<WifiCodeControl>();

    Assert.IsNotNull(control);
  }
}