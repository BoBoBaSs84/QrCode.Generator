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
    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Never);
  }

  [TestMethod]
  public void LoadExceptionTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    _fileProviderMock.Setup(x => x.ReadAllText(UnitTest))
      .Throws<Exception>();

    Assert.ThrowsException<Exception>(() => sut.Load(UnitTest));

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Once);
  }

  [TestMethod]
  public void LoadSuccessTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    string jsonContent = "{\r\n\"name\":\"UnitTest\"\r\n}";
    _fileProviderMock.Setup(x => x.ReadAllText(UnitTest))
      .Returns(jsonContent);

    string result = sut.Load(UnitTest);

    result.Should().Be(jsonContent);
    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Never);
  }

  [TestMethod]
  public void SaveExceptionTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    string jsonContent = "{\r\n\"name\":\"UnitTest\"\r\n}";
    _fileProviderMock.Setup(x => x.WriteAllText(UnitTest, jsonContent))
      .Throws<Exception>();

    Assert.ThrowsException<Exception>(() => sut.Save(UnitTest, jsonContent));

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Once);
  }

  [TestMethod]
  public void SaveSuccessTest()
  {
    TemplateService<TestClass> sut = CreateMockedInstance();
    string jsonContent = "{\r\n\"name\":\"UnitTest\"\r\n}";
    _fileProviderMock.Setup(x => x.WriteAllText(UnitTest, jsonContent));

    sut.Save(UnitTest, jsonContent);

    _loggerServiceMock.Verify(x => x.Log(It.IsAny<Action<ILogger, Exception?>>(), It.IsAny<Exception>()), Times.Never);
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