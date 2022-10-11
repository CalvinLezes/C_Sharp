namespace C_Sharp;
/// <summary>
/// Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
interface IHall
{
    /// <summary>
    /// Create a list of contenders
    /// </summary>
    public void CreateContendersList();

    /// <summary>
    /// Get the next contender to visit the Princess
    /// </summary>
    /// <returns></returns>
    public string GetNextContenderToVisitPrincess();

    /// <summary>
    /// Check if the hall is empty
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty();

    /// <summary>
    /// Get husband's score
    /// </summary>
    /// <returns>Husband's score</returns>
    public int? GetHusbandScore();
}