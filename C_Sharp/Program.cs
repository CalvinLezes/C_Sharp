using SmartPrincess;
var princess = new Princess();
var hall = new Hall();
var friend = new Friend();
int happiness = princess.FindHusband(hall, friend);

using StreamWriter file = new("result.txt");
file.WriteLine("Princess had " + hall.Visited.Count + " dates:");
foreach (var contender in hall.Visited)
{
    file.WriteLine(contender.Name + " " + contender.Score);
}
;
file.WriteLine("\nHow happy is the princess: " + happiness);
