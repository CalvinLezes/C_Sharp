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
    /// Contender, who the Princess chose to marry
    /// </summary>
    private Contender? _husband;

    /// <summary>
    /// Princess' friend, who remembers who visited princess
    /// </summary>
    private readonly Friend _friend;

    public Hall(Friend friend)
    {
        _friend = friend;
    }

    /// <summary>
    /// Index of next contender to have a date with the Princess
    /// </summary>
    private int _nextContenderIndex = 0;

    /// <summary>
    /// Total number of contenders, who want to marry the Princess
    /// </summary>
    private const int NumberOfContenders = 100;

    /// <summary>
    /// Load names of contenders from a file, and create a list of contenders
    /// </summary>
    public void CreateContendersList()
    {
        
        var contendersAdded = 0;
        var currentScore = 1;
        var names = new List<Contender>();
        //Text file with 100 unique names
        using StreamReader reader = new("Names.txt"); 
        while(reader.ReadLine() is { } name && contendersAdded != NumberOfContenders)
        {
            Contender contender = new()
            {
                Name = name,
                Score = currentScore,
            };
            names.Add(contender);
            contendersAdded++;
            currentScore++;
        }
        if (contendersAdded < NumberOfContenders)
        {
            throw new Exception("Added less then 100 contenders, not enough names in Names.txt");
        }
        var rnd = new Random();
        _contenders = names.OrderBy(item => rnd.Next()).ToList();
    }

    /// <summary>
    /// Get the next contender to visit the Princess and tell friend about it
    /// </summary>
    /// <returns>Next contender's name</returns>
    public string GetNextContenderAndTellFriendAboutIt()
    {
        var next = _contenders[_nextContenderIndex];
        _nextContenderIndex++;
        _friend.AddContenderInVisited(next);
        return next.Name;
    }

    /// <summary>
    /// Check if hall is empty or not
    /// </summary>
    /// <returns>True if the hall is empty, else false</returns>
    public bool IsEmpty()
    {
        return _nextContenderIndex == NumberOfContenders;
    }

    /// <summary>
    /// Set husband to a contender the Princess chose to marry
    /// </summary>
    /// <param name="husbandName"></param>
    public void SetHusband(string husbandName)
    {
        _husband = _contenders.Find(contender => contender.Name.Equals(husbandName));
    }

    /// <summary>
    /// Get husband's score
    /// </summary>
    /// <returns>Husbands score, null if no husband</returns>
    public int? GetHusbandScore()
    {
        return _husband?.Score; 
    }
}