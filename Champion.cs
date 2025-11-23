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
        // Random rnd = new Random();

        public Champion(string name) : base(name)
        {
            Moves = new MovesUsed();
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
        public override void NextOpponent()
        {
            // rnd.Next(opponents.Count);  
        }
    }
}
