using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Champion : Character
    {
        Random rnd = new Random();

        public Champion(string name) : base(name)
        {
            Opponents = new List<string>
            {
                "Diego",
                "Donald",
                "Wanaporn",
                "Asa",
                "Vladimir",
                "Haakon"
            };
            Opponents.Remove(name);
        }

        public override string NextOpponent()
        {
            if (Opponents!.Count != 0)
            {
                string enemy = Opponents[rnd.Next(Opponents.Count)];
                Opponents.Remove(enemy);
                return enemy;
            }
            return "No opponents left!";
        }
    }
}
