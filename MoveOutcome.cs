using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class MoveOutcome
    {
        public required Character Attacker { get; init; }
        public required Character Defender { get; init; }
        public required Move MoveUsed { get; init; }
        public int DamageDealt { get; init; }
        public bool StaminaSpent { get; init; }
    }
}
