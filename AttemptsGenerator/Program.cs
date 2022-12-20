using C_Sharp;
using Microsoft.EntityFrameworkCore;

var contenderGenerator = new ContenderGenerator();
const string connectionString = @"Server=localhost;Database=PrincessDB;
                		User Id=postgres;Password=admin";
var options = new DbContextOptionsBuilder<ApplicationContext>()
    .UseNpgsql(connectionString)
    .Options;
using var context = new ApplicationContext(options);
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
for (var i = 0; i < 100; i++)
{
    var contenders = contenderGenerator.CreateContendersList();
    var attempt = new Attempt { Contenders = contenders };
    context.Attempts.Add(attempt);
}

context.SaveChanges();