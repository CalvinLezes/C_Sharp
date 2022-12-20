namespace C_Sharp;

/// <summary>
/// Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
public interface IHall
{
    /// <summary>
    /// Create a list of contenders
    /// </summary>
    public void CreateContendersList();

    public void LoadContendersList(int attemptId, ApplicationContext applicationContext);

    /// <summary>
    /// Get the next contender to visit the Princess and tell friend about it
    /// </summary>
    /// <returns>Next contender's name</returns>
    public string GetNextContenderName();

    /// <summary>
    /// Add current contender in Visited list
    /// </summary>
    public void AddContenderInVisited();

    /// <summary>
    /// Check if the hall is empty
    /// </summary>
    /// <returns>True, if hall is empty, else false</returns>
    public bool IsEmpty();

    /// <summary>
    /// Set husband to a contender the Princess chose to marry
    /// </summary>
    /// <param name="husbandName"></param>
    public void SetHusband(string husbandName);

    /// <summary>
    /// Get husband's score
    /// </summary>
    /// <returns>Husband's score, null if no husband</returns>
    public int? GetHusbandScore();
}