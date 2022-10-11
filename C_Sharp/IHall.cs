namespace C_Sharp;
/// <summary>
/// Hall, where all contestants wait for their turn, 
/// and where they return after a date with the Princess 
/// </summary>
interface IHall
{
    public List<Contender> Visited { get; }
    /// <summary>
    /// Create a list of contenders
    /// </summary>
    public void CreateContendersList();

    /// <summary>
    /// Get the next contender to go on a date with the Princess
    /// </summary>
    /// <returns></returns>
    public Contender GetNextContender();

    /// <summary>
    /// Check if the hall is empty
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty();

    /// <summary>
    /// Set husband to a contender, who Princess chose
    /// </summary>
    /// <param name="husband"></param>
    public void SetHusband(Contender husband);

    /// <summary>
    /// Get husband's score
    /// </summary>
    /// <returns>Husband's score</returns>
    public int GetHusbandScore();
}