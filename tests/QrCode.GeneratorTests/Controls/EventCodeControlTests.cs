﻿using QrCode.Generator.Controls;

namespace QrCode.GeneratorTests.Controls;

[TestClass]
public sealed class EventCodeControlTests : UnitTestBase
{
  [WpfTestMethod]
  public void ConstructorTest()
  {
    EventCodeControl control;

    control = GetService<EventCodeControl>();

    Assert.IsNotNull(control);
  }
}