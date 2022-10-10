namespace C_Sharp;

/// <summary>
/// Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
class Hall: IHall
{
    /// <summary>
    /// List of contenders, who wait for their turn to meet the Princess
    /// </summary>
    private List<Contender> _contenders = new();

    /// <summary>
    /// List of contenders, who already met the Princess
    /// </summary>
    public List<Contender> Visited { get; } = new();

    private Contender? _husband;

    /// <summary>
    /// Load names of contenders from a file, and create a list of contenders
    /// </summary>
    public void CreateContendersList()
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
    /// Get the next contender to go on a date with the Princess
    /// </summary>
    /// <returns>Next contender</returns>
    public Contender GetNextContender()
    {
        var next = _contenders.First();
        _contenders.Remove(next);
        return next;
    }

    /// <summary>
    /// Check if hall is empty or not
    /// </summary>
    /// <returns>True if the hall is empty, else false</returns>
    public bool IsEmpty()
    {
        return _contenders.Count == 0;
    }

    /// <summary>
    /// Set husband to a contender, who Princess chose
    /// </summary>
    /// <param name="husband"></param>
    public void SetHusband(Contender husband)
    {
        _husband = husband;
    }

    /// <summary>
    /// Get husband's score
    /// </summary>
    /// <returns>Husbands score</returns>
    public int GetHusbandScore()
    {
        return _husband?.Score ?? 0; //If the Princess didn't choose a husband returns 0
    }
}