namespace C_Sharp;

/// <summary>
/// Friend, who compares 2 contestants, but only if they both already met the Princess
/// </summary>
interface IFriend
{
    /// <summary>
    /// Check if contestants met the princess and compare them
    /// </summary>
    /// <param name="current"></param>
    /// <param name="previous"></param>
    /// <returns>If current is worse then previous then true, else false</returns>
    public bool CompareContenders(Contender current, Contender previous);
}