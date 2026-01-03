using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal static class MoveFactory
    {
        private static readonly Dictionary<int, Func<Move>> _moves = new()
        {
            { 1, () => new HighKick() },
            { 2, () => new LowKick() },
            { 3, () => new HighPunch() },
            { 4, () => new LowPunch() },
            { 5, () => new Block() },
            { 6, () => new Dodge() },
            { 7, () => new Recover() },
            { 8, () => new SpecialMove() },
        };

        private static readonly Dictionary<string, Func<Move>> _movesString = new()
        {
            { "High Kick", () => new HighKick() },
            { "Low Kick", () => new LowKick() },
            { "High Punch", () => new HighPunch() },
            { "Low Punch", () => new LowPunch() },
            { "Block", () => new Block() },
            { "Dodge", () => new Dodge() },
            { "Recover", () => new Recover() },
            { "Special Move", () => new SpecialMove() },
        };

        internal static Move CreateMove(int choice)
        {
            if (_moves.TryGetValue(choice, out var creator))
                return creator();

            throw new ArgumentException("Invalid move selection");
        }
        internal static Move CreateMove(string moveName)
        {
            
            if (_movesString.TryGetValue(moveName, out var creator))
                return creator();

            throw new ArgumentException("Invalid move selection");
        }
    }
}
