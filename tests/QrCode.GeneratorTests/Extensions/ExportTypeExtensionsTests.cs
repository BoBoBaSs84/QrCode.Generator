// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using FluentAssertions;

using QrCode.Generator.Enumerators;
using QrCode.Generator.Extensions;

namespace QrCode.GeneratorTests.Extensions;

[TestClass]
public sealed class ExportTypeExtensionsTests : UnitTestBase
{
  [TestMethod]
  public void GetFilterFromTypeShouldThrowArgumentOutOfRangeException()
    => Assert.Throws<ArgumentOutOfRangeException>(() => ((ExportType)int.MaxValue).GetFilterFromType());

  [TestMethod]
  public void GetFilterFromTypeShouldThrowNotImplementedException()
    => Assert.Throws<NotImplementedException>(() => ExportType.JPEG.GetFilterFromType());

  [TestMethod]
  [DataRow(ExportType.BMP)]
  [DataRow(ExportType.PNG)]
  [DataRow(ExportType.PDF)]
  [DataRow(ExportType.SVG)]
  public void GetFilterFromTypeShouldNotReturnEmptyString(ExportType type)
    => type.GetFilterFromType().Should().NotBe(string.Empty);
}