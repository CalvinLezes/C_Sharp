namespace C_Sharp
{
    /// <summary>
    /// Contender, who wants to marry the Princess
    /// </summary>
    public class Contender
    {
        public int Id { get; set; }
        
        /// <summary>
        /// Score of a contender (from 1 to 100)
        /// </summary>
        public int Score { get; init; }

        /// <summary>
        /// Name of a contender
        /// </summary>
        public string Name { get; init; }
    }
}