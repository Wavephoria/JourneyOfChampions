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
        public Computer(string name) : base(name)
        {

        }

        // KRAV 2:
        // 1: Overloading av konstruktorn.
        // 2: I spelet så kommer det finnas ett antal som man möter och efter man klarat alla så kommer man möta en boss.
        // 3: För att kunna skapa en boss karaktär när opponentslistan på champion är tom.
        public Computer(string name, string boss) : base(name, boss) 
        {
            Name = name;
            if (name == "Snake")
            {
                SetSnakeStats();
            }
            Stats = new PlayerStats(this);
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
            int highKick = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.HighKick, 0);
            int lowKick = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.LowKick, 0);
            int highPunch = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.HighPunch, 0);  
            int lowPunch = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.LowPunch, 0);
            int block = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.Block, 0);
            int dodge = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.Dodge, 0);
            int recover = champion.Stats.MoveUsage.GetValueOrDefault(MoveType.Recover, 0);

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
    }
}
