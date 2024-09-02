using FluentAssertions;

using QrCode.Generator.Enumerators;
using QrCode.Generator.Extensions;

namespace QrCode.GeneratorTests.Extensions;

[TestClass]
public sealed class ExportTypeExtensionsTests : UnitTestBase
{
  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void GetFilterFromTypeShouldThrowArgumentOutOfRangeException()
    => ((ExportType)42).GetFilterFromType();

  [TestMethod]
  [ExpectedException(typeof(NotImplementedException))]
  public void GetFilterFromTypeShouldThrowNotImplementedException()
    => ExportType.JPEG.GetFilterFromType();

  [TestMethod]
  [DataRow(ExportType.BMP)]
  [DataRow(ExportType.PNG)]
  [DataRow(ExportType.PDF)]
  [DataRow(ExportType.SVG)]
  public void GetFilterFromTypeShouldNotReturnEmptyString(ExportType type)
    => type.GetFilterFromType().Should().NotBe(string.Empty);
}