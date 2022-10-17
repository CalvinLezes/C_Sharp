using Microsoft.Extensions.Hosting;

namespace C_Sharp
{
    /// <summary>
    /// Princess who is trying to find a husband.
    /// She will go on a dates with some contenders and will have to choose one.
    /// </summary>
    class Princess: IHostedService
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

        IHostApplicationLifetime _lifeTime;

        public Princess(Hall hall, Friend friend, IHostApplicationLifetime lifeTime)
        {
            this._hall = hall;
            this._friend = friend;
            _lifeTime = lifeTime;
        }

        /// <summary>
        /// Princess has a date with a contender, and decides if she marries him or not.
        /// </summary>
        /// <param name="contenderName"></param>
        /// <returns>True if she marries this contender, false if not</returns>
        public void HaveADate(string contenderName)
        {
            //Princess asks friend to compare current contender with everyone she already met
            //If he is the best, she decides to marry him
            if (_namesOfVisited.Find(previousName => _friend.CompareContenders(contenderName, previousName)) == null)
            {
                _iAmSingle = false;
                _hall.SetHusband(contenderName);
            }
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
                if (numberOfDates > numberOfContendersToSkip) 
                {
                    HaveADate(contenderName);
                }
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

        /// <summary>
        /// Print result offinding husband
        /// </summary>
        public void PrintResult()
        {
            using StreamWriter file = new("result.txt");
            file.WriteLine("Princess had " + _namesOfVisited.Count + " dates:");
            foreach (var contender in _namesOfVisited)
            {
                file.WriteLine(contender);
            }
            var happiness = GetHappiness();
            if (_iAmSingle)
            {
                file.WriteLine("\nPrincess didn't choose a husband");
            }
            file.WriteLine($"\nHow happy is the princess: {happiness}");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(RunAsync, cancellationToken);
            return Task.CompletedTask;
        }

        public void RunAsync()
        {
            _hall.CreateContendersList();
            FindHusband();
            PrintResult();
            _lifeTime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}