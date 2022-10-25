namespace C_Sharp
{
    /// <summary>
    /// Contender Generator creates list of contenders
    /// </summary>
    public class ContenderGenerator
    {
        /// <summary>
        /// Create a list of 100 contenders with unique names
        /// </summary>
        /// <returns>List of contenders</returns>
        /// <exception cref="Exception"></exception>
        public List<Contender> CreateContendersList()
        {
            const int numberOfContenders = 100;
            var contendersAdded = 0;
            var currentScore = 1;
            var names = new List<Contender>();
            //Text file with 100 unique names
            using StreamReader reader = new("Names.txt");
            while (reader.ReadLine() is { } name && contendersAdded != numberOfContenders)
            {
                Contender contender = new()
                {
                    Name = name,
                    Score = currentScore,
                };
                names.Add(contender);
                contendersAdded++;
                currentScore++;
            }
            if (contendersAdded < numberOfContenders)
            {
                throw new Exception("Added less then 100 contenders, not enough names in Names.txt");
            }
            var rnd = new Random();
            return names.OrderBy(item => rnd.Next()).ToList();
        }
    }
}
