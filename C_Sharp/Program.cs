using C_Sharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Princess>();
        services.AddScoped<Hall>();
        services.AddScoped<Friend>();
        services.AddScoped<ContenderGenerator>();
    })
    .Build();

host.Run();