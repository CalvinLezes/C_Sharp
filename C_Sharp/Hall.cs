namespace C_Sharp;

/// <summary>
/// This class represents Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
class Hall: IHall
{
    /// <summary>
    /// This field is a list of contenders, who wait for their turn to meet the Princess
    /// </summary>
    private List<Contender> _contenders = new();

    /// <summary>
    /// This field is a list of contenders, who already met the Princess
    /// </summary>
    public List<Contender> Visited { get; } = new();

    /// <summary>
    /// This method loads 100 names from a file, and creates a list of contenders
    /// </summary>
    public void LoadContenders()
    {
        var names = new List<Contender>();
        string? name;
        using StreamReader reader = new("Names.txt");
        for (int i = 1; i < 101; i++)
        {
            name = reader.ReadLine();
            Contender contender = new()
            {
                Name = name,
                Score = i,
            };
            names.Add(contender);
        }
        var rnd = new Random();
        _contenders = names.OrderBy(item => rnd.Next()).ToList();
    }

    /// <summary>
    /// This method gets the next contender to go on a date with the Princess
    /// </summary>
    /// <returns>Next contender</returns>
    public Contender GetNextContender()
    {
        var next = _contenders.First();
        _contenders.Remove(next);
        return next;
    }

    /// <summary>
    /// This method is used to find out if hall is empty or not
    /// </summary>
    /// <returns>A boolean</returns>
    public bool IsEmpty()
    {
        return _contenders.Count == 0;
    }
}