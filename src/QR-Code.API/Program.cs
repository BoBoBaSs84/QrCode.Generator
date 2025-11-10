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

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
      app.UseSwagger();
      app.UseSwaggerUI();
    }

    app.AddEventCodeEndpoint()
      .AddWifiCodeEndpoint();

    await app.RunAsync()
      .ConfigureAwait(false);
  }
}
