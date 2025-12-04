using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JourneyOfChampions
{
    internal class Computer : Character
    {
        Random rnd = new Random();
        List<int> moveChoices;

        public string MostUsedMove { get; private set; }
        public string LeastUsedMove { get; private set; }
        public string StyleOfPlay { get; private set; }

        // KRAV 2:
        // 1: Overloading av kunstruktorer
        // 2: Skapas en motståndare utifrån de från början bestämde motståndarna, när alla är slagna så görs en overloading på en boss.
        // 3: Overloading som tar in en bool om det är dags att möta bossen.
        // När listan är tom så skapas det en overloading av computer som skapar bossen till spelet.

        public Computer(string name) : base(name)
        {

        }

        public Computer(string name, bool boss) : base(name) 
        {
            SetSnakeStats();
        }

        public override string CalculateMove(Character champion, Character computer, bool firstBattle) 
        {
            if (firstBattle)
            {
                StyleOfPlay = "Balanced";
                MostUsedMove = "High Kick";
                LeastUsedMove = "Low kick";
            }

            else 
            {
                moveChoices = new List<int> { };
                UserMoves(moveChoices, champion);
            }

            string move = BasicMoves();

            return move;
        }

        private void UserMoves(List<int> moves, Character champion)
        {

            int highKick = champion.Moves.HighKicksUsed;
            int lowKick = champion.Moves.LowKicksUsed;
            int highPunch = champion.Moves.HighPunchesUsed;
            int lowPunch = champion.Moves.LowPunchesUsed;
            int block = champion.Moves.BlocksUsed;
            int dodge = champion.Moves.DodgesUsed;
            int recover = champion.Moves.RecoversUsed;

            int attackingMoves = highKick + lowKick + highPunch + lowPunch;
            int defensiveMoves = block + dodge + recover;

            if (attackingMoves > defensiveMoves)
            {
                StyleOfPlay = "Aggressive";
            }
            else if (defensiveMoves > attackingMoves)
            {
                StyleOfPlay = "Defensive";
            }
            else
            {
                StyleOfPlay = "Balanced";
            }


            Dictionary<string, int> moveDict = new Dictionary<string, int>
            {
                { "High Kick", highKick },
                { "Low Kick", lowKick },
                { "High Punch", highPunch },
                { "Low Punch", lowPunch },
                { "Block", block },
                { "Dodge", dodge },
                { "Recover", recover }
            };

            MostUsedMove = moveDict.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            LeastUsedMove = moveDict.Aggregate((l, r) => l.Value < r.Value ? l : r).Key;

        }
        private string BasicMoves()
        {

            List<string> aggressiveMoves = new List<string> { "High Kick", "Low Kick", "High Punch", "Low Punch" };
            List<string> defensiveMoves = new List<string> { "Block", "Dodge", "Recover" };

            int number = rnd.Next(1, 11);
            int index;

            if (StyleOfPlay == "Defensive")
            {

                if (number < 8)
                {
                    index = rnd.Next(aggressiveMoves.Count);
                    return aggressiveMoves[index];
                }
                else
                {
                    index = rnd.Next(defensiveMoves.Count);
                    return defensiveMoves[index];
                }

            }
            else if (StyleOfPlay == "Offensive")
            {

                if (number > 7)
                {
                    index = rnd.Next(aggressiveMoves.Count);
                    return aggressiveMoves[index];
                }
                else
                {
                    index = rnd.Next(defensiveMoves.Count);
                    return defensiveMoves[index];
                }
            }
            else // Balanced
            {
                List<string> allMoves = new List<string> { "High Kick", "Low Kick", "High Punch", "Low Punch", "Block", "Dodge", "Recover" };
                index = rnd.Next(allMoves.Count);
                return allMoves[index];
            }
        }
        private void DiegoMoves(Character champion, List<int> moveChoices)
        {
            

        }


    }
}
