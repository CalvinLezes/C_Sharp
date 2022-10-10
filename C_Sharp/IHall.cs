namespace C_Sharp;
/// <summary>
/// Hall
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
}