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
        private readonly List<Contender> _visited = new();

        public void AddContenderInVisited(Contender contender)
        {
            _visited.Add(contender);
        }

        /// <summary>
        /// Check if both contestants already visited the Princess and compare them
        /// </summary>
        /// <param name="currentName"></param>
        /// <param name="previousName"></param>
        /// <returns>If current is worse then previous then true, else false</returns>
        /// <exception cref="Exception"></exception>
        public bool CompareContenders(string currentName, string previousName)
        {
            var current = _visited.Find(contender => contender.Name.Equals(currentName));
            var previous = _visited.Find(contender => contender.Name.Equals(previousName));
            if (current==null || previous==null)
            {
                throw new Exception("Trying to compare contenders, who princess didn't meet yet");
            }
            return current.Score < previous.Score;
        }

    }
}
