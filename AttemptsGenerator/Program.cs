using C_Sharp;
var contenderGenerator = new ContenderGenerator();
using var context = new ApplicationContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
for (var i = 0; i < 100; i++)
{
    var contenders = contenderGenerator.CreateContendersList();
    var attempt = new Attempt { Contenders = contenders };
    context.Attempts.Add(attempt);
}
context.SaveChanges();