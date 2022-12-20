using Microsoft.EntityFrameworkCore;

namespace C_Sharp;

/// <summary>
/// DB Context with list of attempts
/// </summary>
public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Attempt> Attempts { get; set; }
}