using System.Configuration;
using C_Sharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var connectionString = ConfigurationManager.ConnectionStrings["PrincessDB"].ConnectionString;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Princess>();
        services.AddScoped<IHall, Hall>();
        services.AddScoped<IFriend, Friend>();
        services.AddScoped<IContenderGenerator, ContenderGenerator>();
        services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connectionString));
    })
    .Build();

host.Run();