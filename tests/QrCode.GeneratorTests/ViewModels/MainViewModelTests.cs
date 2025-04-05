// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using QrCode.Generator.ViewModels;

namespace QrCode.GeneratorTests.ViewModels;

[TestClass]
public sealed class MainViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void MainViewModelTest()
  {
    MainViewModel? viewModel;

    viewModel = GetService<MainViewModel>();

    Assert.IsNotNull(viewModel);
    Assert.IsNotNull(viewModel.AboutCommand);
    Assert.IsNotNull(viewModel.ContactCommand);
    Assert.IsNotNull(viewModel.EventCommand);
    Assert.IsNotNull(viewModel.ExitCommand);
    Assert.IsNotNull(viewModel.GiroCommand);
    Assert.IsNotNull(viewModel.NavigationService);
    Assert.IsNotNull(viewModel.WifiCommand);
  }
}