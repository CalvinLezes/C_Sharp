using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPrincess
{
    class Hall
    {
        private List<Contender> contenders = new();

        public List<Contender> Visited { get; } = new();

        public Hall()
        {
            var names = new List<Contender>();
            string? name;
            int score = 1;
            using StreamReader reader = new("Names.txt");
            while((name = reader.ReadLine())!= null)
            {
                Contender contender = new()
                {
                    Name = name,
                    Score = score
                };
                names.Add(contender);
                score++;
            }
            var rnd = new Random();
            contenders = names.OrderBy(item => rnd.Next()).ToList();
        }

        public Contender GetContender()
        {
            Contender next = contenders.First();
            Visited.Add(next);
            contenders.Remove(next);
            return next;
        }

        public bool IsEmpty()
        {
            return contenders.Count == 0;
        }
    }
}
