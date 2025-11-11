using QRCode.API.Extensions;

namespace QRCode.API;

internal sealed class Program
{
  [MTAThread]
  public static async Task Main(string[] args)
  {
    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
    builder.Services.RegisterServices();
    WebApplication app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.AddContactCodeEndpoint()
      .AddEventCodeEndpoint()
      .AddGiroCodeEndpoint()
      .AddWifiCodeEndpoint();

    await app.RunAsync()
      .ConfigureAwait(false);
  }
}
