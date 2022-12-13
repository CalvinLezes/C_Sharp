using Microsoft.EntityFrameworkCore;

namespace C_Sharp;

public class ApplicationContext : DbContext
{
    public DbSet<Attempt> Attempts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string connectionString = @"Server=localhost;Database=PrincessDB;
                		User Id=postgres;Password=admin";
        optionsBuilder.UseNpgsql(connectionString);
    }
}