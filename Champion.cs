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

            // KRAV 5:
            // 1: Beroendeinjektion
            // 2: Skapar ett objekt av klassed MovesUsed som är direkt kopplad till karaktären.
            // 3: För att AI ska kunna använda sig av en uträkning på vilka moves som använts mest och anpassa sin strategi efter det.
            
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
        public override string NextOpponent()
        {
            if (Opponents.Count != 0)
            {
                string enemy = Opponents[rnd.Next(Opponents.Count)];
                Opponents.Remove(enemy);
                return enemy;
            }

            return "No opponents left!";

        }
        public override string NextOpponent(bool boss) 
        {
            return "Snake";
        }
    }
}
