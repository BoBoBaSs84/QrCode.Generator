using Microsoft.Extensions.DependencyInjection;

using QrCode.Generator.Extensions;

namespace QrCode.GeneratorTests;

[TestClass]
public abstract class UnitTestBase
{
  private static TestContext? s_context;
  private static IServiceProvider? s_serviceProvider;

  [AssemblyInitialize]
  public static void AssemblyInitialize(TestContext context)
  {
    s_context = context;
    s_serviceProvider = GetServiceProvider();
  }

  [TestInitialize]
  public void TestInitialize()
    => s_context?.WriteLine($"Initialize {s_context.TestName} ..");

  [TestCleanup]
  public void TestCleanup()
    => s_context?.WriteLine($"Cleanup {s_context.TestName} ..");

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

  private static ServiceProvider GetServiceProvider()
  {
    IServiceCollection services = new ServiceCollection();

    _ = services.RegisterModels();
    _ = services.RegisterServices();
    _ = services.RegisterViewModels();

    return services.BuildServiceProvider();
  }
}

public class WpfTestMethodAttribute : TestMethodAttribute
{
  public override TestResult[] Execute(ITestMethod testMethod)
  {
    if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
      return Invoke(testMethod);

    TestResult[] result = [];
    var thread = new Thread(() => result = Invoke(testMethod));
    thread.SetApartmentState(ApartmentState.STA);
    thread.Start();
    thread.Join();
    return result;
  }

  private static TestResult[] Invoke(ITestMethod testMethod)
    => new[] { testMethod.Invoke(null) };
}