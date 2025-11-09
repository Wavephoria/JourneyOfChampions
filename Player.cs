using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Player : Character
    {
        private int highKicksUsed { set { } get { return highKicksUsed; } }
        private int lowKicksUsed;
        private int highPunchesUsed;
        private int lowPunchesUsed;
        private int blocksUsed;

        public Player(string name) : base(name)
        {
            
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
