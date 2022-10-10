using C_Sharp;

var hall = new Hall();
hall.CreateContendersList();
var friend = new Friend(hall);
var princess = new Princess(hall, friend);
princess.FindHusband();
using StreamWriter file = new("result.txt");
file.WriteLine("Princess had " + hall.Visited.Count + " dates:");
foreach (var contender in hall.Visited)
{
    file.WriteLine($"{contender.Name} {contender.Score}");
}
var happiness = princess.GetHappiness();
if (happiness.Equals(10))
{
    file.WriteLine("\nPrincess didn't choose a husband");
}
file.WriteLine($"\nHow happy is the princess: {happiness}");
