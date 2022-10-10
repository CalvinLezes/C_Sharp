namespace C_Sharp
{
    /// <summary>
    /// This class represents the Friend, who compares two contestants for the Princess,
    /// but can only compare two contestants, who Princess already met.
    /// </summary>
    class Friend: IFriend
    {
        /// <summary>
        /// This field is the hall, where the friend asks if the princess met a contender or not.
        /// </summary>
        private Hall hall;

        public Friend(Hall hall)
        {
            this.hall = hall;
        }

        /// <summary>
        /// This method compares two contestants, and checks if they both already visited the Princess
        /// </summary>
        /// <param name="current"></param>
        /// <param name="previous"></param>
        /// <returns>A boolean</returns>
        /// <exception cref="Exception"></exception>
        public bool CompareContenders(Contender current, Contender previous)
        {
            if (!hall.Visited.Contains(current) || !hall.Visited.Contains(previous))
            {
                throw new Exception("Trying to compare contenders, who princess didn't meet yet");
            }
            return current.Score < previous.Score;
        }
    }
}
