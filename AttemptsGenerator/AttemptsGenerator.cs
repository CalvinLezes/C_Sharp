namespace AttemptsGenerator;
using C_Sharp;
using Microsoft.EntityFrameworkCore;

/// <summary>
///  Attempts Generator generates 100 attempts and saves them in DB
/// </summary>
public class AttemptsGenerator
{
    private const int NumberOfAttempts = 100;

    /// <summary>
    /// generate 100 attempts and save them in DB
    /// </summary>
    public void Generate100Attempts()
    {
        var contenderGenerator = new ContenderGenerator();
        const string connectionString = @"Server=localhost;Database=PrincessDB;
                		User Id=postgres;Password=admin";
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseNpgsql(connectionString)
            .Options;
        using var context = new ApplicationContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        for (var i = 0; i < NumberOfAttempts; i++)
        {
            var contenders = contenderGenerator.CreateContendersList();
            var attempt = new Attempt { Contenders = contenders };
            context.Attempts.Add(attempt);
        }

        context.SaveChanges();
    }
}