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
public sealed class ContactDataViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    ContactDataViewModel? viewModel;

    viewModel = GetService<ContactDataViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.Model);
    Assert.IsTrue(viewModel.AddressOrderTypes.Length != 0);
    Assert.IsTrue(viewModel.ContactOutputTypes.Length != 0);
  }

  [WpfTestMethod]
  public void SetPayLoadTest()
  {
    Mock<IQrCodeService> qrCodeServiceMock = new();
    Mock<IExportService<ContactDataModel>> exportServiceMock = new();
    Mock<ITemplateService<ContactDataModel>> templateServiceMock = new();
    ContactDataViewModel viewModel = new(qrCodeServiceMock.Object, exportServiceMock.Object, templateServiceMock.Object, new());

    viewModel.CreateCommand.Execute(viewModel.Model);

    Assert.AreNotEqual(string.Empty, viewModel.Payload);
  }
}