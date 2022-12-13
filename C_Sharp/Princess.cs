using C_Sharp.Properties;
using Microsoft.Extensions.Hosting;

namespace C_Sharp
{
    /// <summary>
    /// Princess who is trying to find a husband.
    /// She will go on a dates with some contenders and will have to choose one.
    /// Loads 100 attempts from db and counts average happiness
    /// </summary>
    public class Princess: IHostedService
    {
        /// <summary>
        /// If the Princess still single or not
        /// </summary>
        private bool _iAmSingle = true;

        /// <summary>
        /// Hall, where contenders are.
        /// </summary>
        private readonly IHall _hall;

        /// <summary>
        /// Friend, who Princess uses for help
        /// </summary>
        private readonly IFriend _friend;

        /// <summary>
        /// List of names of contenders who visited the Princess
        /// </summary>
        private readonly List<string> _namesOfVisited = new();

        IHostApplicationLifetime _lifeTime;
        
        /// <summary>
        /// DBContext to access attempts database
        /// </summary>
        private readonly ApplicationContext _applicationContext;
        public Princess(IHall hall, IFriend friend, IHostApplicationLifetime lifeTime, ApplicationContext applicationContext)
        {
            _hall = hall;
            _friend = friend;
            _lifeTime = lifeTime;
            _applicationContext = applicationContext;
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
            _iAmSingle = true;
            //Princess skips first 100/e contenders
            const int numberOfContendersToSkip = 36;
            var numberOfDates = 0;
            while (_iAmSingle && !_hall.IsEmpty())
            {
                var contenderName = _hall.GetNextContenderName();
                _namesOfVisited.Add(contenderName);
                _hall.AddContenderInVisited();
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
            const int firstContenderScore = 100;
            const int thirdContenderScore = 98;
            const int fifthContenderScore = 96;
            const int firstContenderHappiness = 20;
            const int thirdContenderHappiness = 50;
            const int fifthContenderHappiness = 100;
            const int otherContenderHappiness = 0;
            //If the Princess didn't choose a husband, her happiness score is 10
            const int noHusbandHappiness = 10;
            return score switch
            {
                null => noHusbandHappiness,
                firstContenderScore => firstContenderHappiness,
                thirdContenderScore => thirdContenderHappiness,
                fifthContenderScore => fifthContenderHappiness,
                _ => otherContenderHappiness
            };
        }

        /// <summary>
        /// Print result of finding husband
        /// </summary>
        public void PrintResult()
        {
            using StreamWriter file = new("result.txt");
            file.WriteLine($"Princess had {_namesOfVisited.Count} dates:");
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
            const int numberOfAttempts = 100;
            var totalHappiness = 0;
            for (var i = 0; i < numberOfAttempts; i++)
            {
                _namesOfVisited.Clear();
                _hall.LoadContendersList(i+1, _applicationContext);
                FindHusband();
                totalHappiness += GetHappiness();
            }
            var averageHappiness = totalHappiness / numberOfAttempts;
            Console.WriteLine(Resources.AvarageHappinessOutput, averageHappiness);
            _lifeTime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}