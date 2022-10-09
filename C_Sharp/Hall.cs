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
        public void LoadContenders()
        {
            var names = new List<Contender>();
            string? name;
            using StreamReader reader = new("Names.txt");
            for (int i = 0; i < 100; i++)
            {
                name = reader.ReadLine();
                Contender contender = new()
                {
                    Name = name,
                    Score = i,
                };
                names.Add(contender);
            }
            var rnd = new Random();
            contenders = names.OrderBy(item => rnd.Next()).ToList();
        }

        public Contender GetNextContender()
        {
            var next = contenders.First();
            contenders.Remove(next);
            return next;
        }

        public bool IsEmpty()
        {
            return contenders.Count == 0;
        }
    }
}
