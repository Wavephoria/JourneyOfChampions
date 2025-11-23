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
        

        private int highKicksUsed;
        private int lowKicksUsed;
        private int highPunchesUsed;
        private int lowPunchesUsed;
        private int blocksUsed;

        // Random rnd = new Random();

        public Champion(string name) : base(name)
        {
            highKicksUsed = 0;

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

        public void MakingMove(string move)
        { 
            switch (move)
            {
                case "High Kick":
                    highKicksUsed++;
                    break;
                case "Low Kick":
                    lowKicksUsed++;
                    break;
                case "High Punch":
                    highPunchesUsed++;
                    break;
                case "Low Punch":
                    lowPunchesUsed++;
                    break;
                case "Block":
                    blocksUsed++;
                    break;
                default:
                    Console.WriteLine("Invalid move.");
                    break;
            }
        }
    }
}
