using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
     class MovesUsed
    {
        public int HighKicksUsed { get; private set; }
        public int LowKicksUsed { get; private set; }
        public int HighPunchesUsed { get; private set; }   
        public int LowPunchesUsed { get; private set; }
        public int BlocksUsed { get; private set; }
        public int DodgesUsed { get; private set; }

        public int SpecialMovesUsed { get; private set; }

        public void MakingMove(string move)
        {
            switch (move)
            {
                case "High Kick":
                    HighKicksUsed++;
                    break;
                case "Low Kick":
                    LowKicksUsed++;
                    break;
                case "High Punch":
                    HighPunchesUsed++;
                    break;
                case "Low Punch":
                    LowPunchesUsed++;
                    break;
                case "Block":
                    BlocksUsed++;
                    break;
                case "Dodge":
                    DodgesUsed++;
                    break;
                default:
                    Console.WriteLine("Invalid move.");
                    break;

                case "Special Move":
                    SpecialMovesUsed++;
                    break;
            }
        }
    }
}
