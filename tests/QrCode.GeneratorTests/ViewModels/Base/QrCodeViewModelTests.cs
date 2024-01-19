using Microsoft.VisualStudio.TestTools.UnitTesting;

using QrCode.Generator.Interfaces.Services;
using QrCode.Generator.ViewModels.Base;
using QrCode.GeneratorTests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCode.Generator.ViewModels.Base.Tests;

[TestClass]
public sealed class QrCodeViewModelTests : UnitTestBase
{
  [WpfTestMethod]
  public void QrCodeViewModelTest()
  {
    IQrCodeService service = GetService<IQrCodeService>();
    TestModel? model;

    model = new(service);

    Assert.IsNotNull(model);
    Assert.IsTrue(model.ErrorCorrectionLevels.Length != 0);    
	}

  private sealed class TestModel(IQrCodeService service) : QrCodeViewModel(service)
  {
    protected override void SetPayLoad()
      => Payload = "UnitTest";
  }
}