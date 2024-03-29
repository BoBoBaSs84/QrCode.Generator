﻿using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models.Base;
using QrCode.Generator.ViewModels.Base;

namespace QrCode.GeneratorTests.ViewModels.Base;

[TestClass]
public sealed class QrCodeViewModelTests : UnitTestBase
{
  private const string UnitTest = "UnitTest";

  [WpfTestMethod]
  public void ConstructorTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel? viewModel;

    viewModel = new(service);

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.CreateCommand);
    Assert.IsNotNull(viewModel.CopyCommand);
    Assert.IsTrue(viewModel.ErrorCorrectionLevels.Length != 0);
  }

  [WpfTestMethod]
  public void CreateCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service);

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  [WpfTestMethod]
  public void CopyCommandTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestViewModel viewModel = new(service);

    viewModel.CopyCommand.Execute(viewModel.Model);

    Assert.AreEqual(UnitTest, viewModel.Payload);
  }

  private sealed class TestViewModel(IQrCodeService service) : QrCodeViewModel(service)
  {
    public TestModel Model { get; } = new();

    protected override void SetPayLoad()
      => Payload = UnitTest;
  }

  private sealed class TestModel : QrCodeModel
  { }
}