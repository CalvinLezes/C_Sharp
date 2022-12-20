using C_Sharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

const string connectionString = @"Server=localhost;Database=PrincessDB;
                		User Id=postgres;Password=admin";

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