namespace C_Sharp;

/// <summary>
/// Attempt is a list of 100 contenders in particular order
/// </summary>
public class Attempt
{
    public int Id { get; set; }

    /// <summary>
    /// List of contenders
    /// </summary>
    public List<Contender>? Contenders { get; set; }
}