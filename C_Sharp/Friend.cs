namespace C_Sharp
{
    /// <summary>
    /// Friend, who compares two contestants for the Princess, but only if they both already met the Princess.
    /// </summary>
    class Friend: IFriend
    {
        /// <summary>
        /// Hall, where the friend asks if the princess met a contender or not.
        /// </summary>
        private readonly Hall _hall;

        public Friend(Hall hall)
        {
            _hall = hall;
        }

        /// <summary>
        /// Check if both contestants already visited the Princess and compare them
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <returns>If current is worse then previous then true, else false</returns>
        /// <exception cref="Exception"></exception>
        public bool CompareContenders(Contender current, Contender previous)
        {
            if (_hall.Visited.Find(contender => contender.Equals(current))==null 
                || _hall.Visited.Find(contender => contender.Equals(previous)) == null)
            {
                throw new Exception("Trying to compare contenders, who princess didn't meet yet");
            }
            return current.Score < previous.Score;
        }
    }
}
