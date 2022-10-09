using SmartPrincess;
var hall = new Hall();
hall.LoadContenders();
var friend = new Friend();
var princess = new Princess(hall, friend);

int happiness = princess.FindHusband();

using StreamWriter file = new("result.txt");
file.WriteLine("Princess had " + hall.Visited.Count + " dates:");
foreach (var contender in hall.Visited)
{
    file.WriteLine(contender.Name + " " + contender.Score);
}
;
file.WriteLine("\nHow happy is the princess: " + happiness);
