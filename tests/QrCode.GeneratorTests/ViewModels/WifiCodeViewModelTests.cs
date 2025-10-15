// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using Moq;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.Models;
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class WifiCodeViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    WifiCodeViewModel? viewModel;

    viewModel = GetService<WifiCodeViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsNotEmpty(viewModel.AuthenticationTypes);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<IExportService<WifiCodeModel>> exportServiceMock = new();
    Mock<ITemplateService<WifiCodeModel>> templateServiceMock = new();
    WifiCodeViewModel viewModel = new(qrCodeServiceMock.Object, exportServiceMock.Object, templateServiceMock.Object, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}