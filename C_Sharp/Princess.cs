namespace C_Sharp
{
    /// <summary>
    /// Princess who is trying to find a husband.
    /// She will go on a dates with some contenders and will have to choose one.
    /// </summary>
    class Princess
    {
        /// <summary>
        /// If the Princess still single or not
        /// </summary>
        private bool _iAmSingle = true;

        /// <summary>
        /// Hall, where contenders are.
        /// </summary>
        private readonly Hall _hall;

        /// <summary>
        /// Friend, who Princess uses for help
        /// </summary>
        private readonly Friend _friend;

        /// <summary>
        /// List of names of contenders who visited the Princess
        /// </summary>
        private readonly List<string> _namesOfVisited = new();

        public Princess(Hall hall, Friend friend)
        {
            this._hall = hall;
            this._friend = friend;
        }

        /// <summary>
        /// Princess has a date with a contender, and decides if she marries him or not.
        /// </summary>
        /// <param name="contenderName"></param>
        /// <returns>True if she marries this contender, false if not</returns>
        public bool HaveADate(string contenderName)
        {
            if (_namesOfVisited.Find(previousName => _friend.CompareContenders(contenderName, previousName)) == null)
            {
                _iAmSingle = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Princess is trying to find a husband.
        /// She is having dates with contenders until she fins a husband.
        /// </summary>
        public void FindHusband()
        {
            //Princess skips first 100/e contenders
            const int numberOfContendersToSkip = 36;
            var numberOfDates = 0;
            while (_iAmSingle && !_hall.IsEmpty())
            {
                var contenderName = _hall.GetNextContenderAndTellFriendAboutIt();
                _namesOfVisited.Add(contenderName);
                var doIMarryHim = false;
                if (numberOfDates > numberOfContendersToSkip) 
                {
                    doIMarryHim = HaveADate(contenderName);
                }
                _hall.ReturnContender(doIMarryHim, contenderName);
                numberOfDates++;
            }
        }

        /// <summary>
        /// Get Princess' happiness score
        /// </summary>
        /// <returns>Happiness score</returns>
        public int GetHappiness()
        {
            var score = _hall.GetHusbandScore();

            //If the Princess didn't choose a husband, her happiness score is 10
            const int happinessIfPrincessDintChooseAnybody = 10;

            //If princess chose contender with score less then 51, her happiness is 0
            const int scoreBelowWhichPrincessIsUnhappy = 51;
            const int happinessIfPrincessMadeABadChoice = 0;

            if (score == null)
            {
                return happinessIfPrincessDintChooseAnybody;
                
            }
            if((int)score < scoreBelowWhichPrincessIsUnhappy)
            {
                return happinessIfPrincessMadeABadChoice;
            }
            return (int)score;

        }
        /// <summary>
        /// Get list of visited contenders' names
        /// </summary>
        /// <returns>List of visited contenders' names</returns>
        public List<string> GetVisitedContendersNames()
        {
            return _namesOfVisited;
        }
    }

    
}
