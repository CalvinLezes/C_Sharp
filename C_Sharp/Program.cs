using C_Sharp;

var hall = new Hall();
hall.LoadContenders();
var friend = new Friend(hall);
var princess = new Princess(hall, friend);
var husband = princess.FindHusband();
using StreamWriter file = new("result.txt");
file.WriteLine("Princess had " + hall.Visited.Count + " dates:");
foreach (var contender in hall.Visited)
{
    file.WriteLine($"{contender.Name} {contender.Score}");
}

if(husband != null)
{
    var happiness = husband.Score < 51 ?  0 : husband.Score;
    file.WriteLine($"\nHow happy is the princess: {happiness}");
    
}
else
{
    file.WriteLine("\nPrincess didn't choose a husband");
    file.WriteLine("\nHow happy is the princess: 10");
}
