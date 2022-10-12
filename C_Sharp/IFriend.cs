namespace C_Sharp;

/// <summary>
/// Friend, who compares 2 contestants, but only if they both already met the Princess
/// </summary>
interface IFriend
{
    /// <summary>
    /// Add contender to visited list
    /// </summary>
    /// <param name="contender"></param>
    public void AddContenderInVisited(Contender contender);

    /// <summary>
    /// Check if contestants met the princess and compare them
    /// </summary>
    /// <param name="currentName"></param>
    /// <param name="previousName"></param>
    /// <returns>If current is worse then previous then true, else false</returns>
    public bool CompareContenders(string currentName, string previousName);
}