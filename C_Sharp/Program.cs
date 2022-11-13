using C_Sharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Princess>();
        services.AddScoped<IHall, Hall>();
        services.AddScoped<IFriend, Friend>();
        services.AddScoped<IContenderGenerator, ContenderGenerator>();
    })
    .Build();

host.Run();