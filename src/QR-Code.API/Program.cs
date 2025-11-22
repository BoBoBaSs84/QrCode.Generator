// -----------------------------------------------------------------------------
// Copyright:	Robert Peter Meyer
// License:		MIT
//
// This source code is licensed under the MIT license found in the
// LICENSE file in the root directory of this source tree.
// -----------------------------------------------------------------------------
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
