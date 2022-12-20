using Microsoft.EntityFrameworkCore;

namespace C_Sharp;

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