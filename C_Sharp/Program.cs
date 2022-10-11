using C_Sharp;

var friend = new Friend();
var hall = new Hall(friend);
hall.CreateContendersList();

var princess = new Princess(hall, friend);
princess.FindHusband();
using StreamWriter file = new("result.txt");
var visitedNames = princess.GetVisitedNames();
file.WriteLine("Princess had " + visitedNames.Count + " dates:");
foreach (var contender in visitedNames)
{
    file.WriteLine(contender);
}

var happiness = princess.GetHappiness();
if (happiness.Equals(10))
{
    file.WriteLine("\nPrincess didn't choose a husband");
}
file.WriteLine($"\nHow happy is the princess: {happiness}");
