using FluentAssertions;

using Microsoft.Extensions.Logging;

using Moq;

using QrCode.Generator.Interfaces.Provider;
using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Services;

namespace QrCode.GeneratorTests.Services;

[TestClass]
[SuppressMessage("Style", "IDE0058", Justification = "Not relevant here, unit testing.")]
public sealed class TemplateServiceTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";
  private Mock<ILoggerService<TemplateService<TestClass>>> _loggerServiceMock = default!;
  private Mock<IFileProvider> _fileProviderMock = default!;

  [TestMethod]
  public void FromExceptionTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();

    Assert.ThrowsException<ArgumentNullException>(() => sut.From(null!));

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Once);
  }

  [TestMethod]
  public void FromSuccessTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    string json = "{\r\n\"name\":\"UnitTest\"\r\n}";

    TestClass testClass = sut.From(json);

    testClass.Should().NotBeNull();
    testClass.Name.Should().Be(UnitTest);
  }

  [TestMethod()]
  public void LoadTest()
  {
    Assert.Fail();
  }

  [TestMethod()]
  public void SaveTest()
  {
    Assert.Fail();
  }

  [TestMethod]
  public void ToExceptionTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();

    Assert.ThrowsException<ArgumentNullException>(() => sut.To(null!));

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Once);
  }

  [TestMethod]
  public void ToSuccessTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    TestClass testClass = new(UnitTest);

    string json = sut.To(testClass);

    json.Should().NotBeNull();
  }

  private TemplateService<TestClass> CreateMockedInstance()
  {
    _loggerServiceMock = new();
    _fileProviderMock = new();
    return new TemplateService<TestClass>(_loggerServiceMock.Object, _fileProviderMock.Object);
  }

  public sealed class TestClass(string name)
  {
    public string Name { get; set; } = name;
  }
}