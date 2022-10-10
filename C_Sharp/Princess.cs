namespace C_Sharp
{
    /// <summary>
    /// This class represents the Princess who is trying to find a husband.
    /// She will go on a dates with some contenders and will have to choose one.
    /// Her happiness will be determined by a score of a contender she chose to be her husband,
    /// Princess doesn't have access to contenders' scores, but she can ask her Friend to tell her
    /// if one contender is better then the other.
    /// If Princess doesn't choose anybody, her level of happiness will be 10.
    /// </summary>
    class Princess
    {
        /// <summary>
        /// Princess will skip first 100/e contestants
        /// </summary>
        private const int NumberOfContendersToSkip = 36;

        /// <summary>
        /// This field is a husband, who the Princess chose
        /// </summary>
        private Contender? _husband;

        /// <summary>
        /// This field is the hall, where contenders are.
        /// </summary>
        private readonly Hall _hall;

        /// <summary>
        /// This field is a friend, who Princess uses for help
        /// </summary>
        private readonly Friend _friend;

        public Princess(Hall hall, Friend friend)
        {
            this._hall = hall;
            this._friend = friend;
        }

        /// <summary>
        /// This method is a princess having a date with a contender,
        /// she asks her friend to compare this contender with all contenders
        /// that she already seen and only if he is better then everyone
        /// she decides to marry him.
        /// </summary>
        /// <param name="contender"></param>
        public void HaveADate(Contender contender)
        {
            if (_hall.Visited.Find(previous => _friend.CompareContenders(contender, previous)) == null)
            {
                _husband = contender;
            }
        }

        /// <summary>
        /// This method is the Princess trying to find a husband.
        /// She asks a hall to give her the next contender,
        /// then this contender adds to visited list,
        /// and then they have a date.
        /// If the Princess decided to marry a contender or if hall is empty, then the search stops.
        /// The Princess skips first 100/e contenders.
        /// </summary>
        /// <returns>The husband</returns>
        public Contender? FindHusband()
        {
            var numContenders = 0;
            while (_husband == null && !_hall.IsEmpty())
            {
                var contender = _hall.GetNextContender();
                _hall.Visited.Add(contender);
                if (numContenders > NumberOfContendersToSkip)
                {
                    HaveADate(contender);
                }
                numContenders++;
            }
            return _husband;
        }
    }
}
