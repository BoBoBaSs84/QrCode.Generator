using System.Text.Json;
using System.Windows.Media;

using BB84.Extensions.Serialization;

using FluentAssertions;

using QrCode.Generator.Converters;

namespace QrCode.GeneratorTests.Converters;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit testing.")]
public sealed class ColorJsonConverterTests : UnitTestBase
{
  private readonly JsonSerializerOptions _serializerOptions = new() { Converters = { new ColorJsonConverter() } };

  [TestMethod]
  public void ReadTest()
  {
    string testJson = "{\"Color\":\"#FF0000FF\"}";

    TestClass testClass = testJson.FromJson<TestClass>(_serializerOptions);

    testClass.Color.Should().Be(Colors.Blue);
  }

  [TestMethod]
  public void WriteTest()
  {
    TestClass testClass = new() { Color = Colors.Blue };

    string json = testClass.ToJson(_serializerOptions);

    json.Should().Contain("#FF0000FF");
  }

  private sealed class TestClass()
  {
    public Color Color { get; set; }
  }
}