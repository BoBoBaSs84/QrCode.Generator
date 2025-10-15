// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
using System.Runtime.CompilerServices;

using Microsoft.Extensions.DependencyInjection;

using QrCode.Generator.Extensions;

namespace QrCode.GeneratorTests;

[TestClass]
public abstract class UnitTestBase
{
  private static IServiceProvider? s_serviceProvider;

  [AssemblyInitialize]
  public static void AssemblyInitialize(TestContext context)
  {
    s_serviceProvider = GetServiceProvider();
  }

  /// <summary>
  /// Returns the requested registered service.
  /// </summary>
  /// <typeparam name="T">The requested service.</typeparam>
  /// <returns>The registered service.</returns>
  /// <exception cref="ArgumentException">If the service is not registered.</exception>
  public static T GetService<T>() where T : class
  {
    s_serviceProvider ??= GetServiceProvider();
    return s_serviceProvider.GetRequiredService(typeof(T)) is not T service
      ? throw new ArgumentException($"{typeof(T)} needs to be registered.")
      : service;
  }

  [SuppressMessage("Style", "IDE0058", Justification = "Not relevant here.")]
  private static ServiceProvider GetServiceProvider()
  {
    IServiceCollection services = new ServiceCollection();

    services.RegisterControls();
    services.RegisterModels();
    services.RegisterServices();
    services.RegisterProviders();
    services.RegisterViewModels();
    services.RegisterWindows();

    return services.BuildServiceProvider();
  }
}

public class WpfTestMethodAttribute([CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = -1)
  : TestMethodAttribute(callerFilePath, callerLineNumber)
{
  public override async Task<TestResult[]> ExecuteAsync(ITestMethod testMethod)
  {
    if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
      return await Invoke(testMethod);

    TestResult[] result = [];
    Thread thread = new(async () => result = await Invoke(testMethod));
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    thread.Join();
    return result;
  }

  private static async Task<TestResult[]> Invoke(ITestMethod testMethod)
    => [await testMethod.InvokeAsync(null)];
}