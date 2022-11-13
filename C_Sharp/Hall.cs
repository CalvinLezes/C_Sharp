﻿namespace C_Sharp;

/// <summary>
/// Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
public class Hall: IHall
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
    private readonly IFriend _friend;

    /// <summary>
    /// Contender Generator creates list of contenders
    /// </summary>
    private readonly IContenderGenerator _contenderGenerator;

    public Hall(IFriend friend, IContenderGenerator contenderGenerator)
    {
        _friend = friend;
        _contenderGenerator = contenderGenerator;
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
    /// Call for contenderGenerator to create list of contenders
    /// </summary>
    public void CreateContendersList()
    {
        _contenders = _contenderGenerator.CreateContendersList();
    }

    /// <summary>
    /// Get the next contender's name to visit the Princess
    /// </summary>
    /// <returns>Next contender's name</returns>
    public string GetNextContenderName()
    {
        if (IsEmpty())
        {
            throw new Exception("Trying to get contender from empty hall");
        }
        return _contenders[_nextContenderIndex].Name;
    }

    /// <summary>
    /// Add current contender in Visited list
    /// </summary>
    public void AddContenderInVisited()
    {
        _friend.AddContenderInVisited(_contenders[_nextContenderIndex]);
        _nextContenderIndex++;
    }

    /// <summary>
    /// Check if hall is empty or not
    /// </summary>
    /// <returns>True if the hall is empty, else false</returns>
    public bool IsEmpty()
    {
        return _nextContenderIndex == NumberOfContenders|| _contenders.Count==0;
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