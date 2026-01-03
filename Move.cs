using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Move
    {
        internal virtual MoveType Type { get; }

        public MoveOutcome Execute(Character attacker, Character defender, Move move)
        {
            int damage = 0;

            bool staminaSpent = attacker.TrySpendStaminaFor(move);
            if (staminaSpent)
            {
                attacker.UseMove(move);
                damage = attacker.CalculateDamage(move);
                defender.TakeDamage(damage);
            }

            return new MoveOutcome
            {
                Attacker = attacker,
                Defender = defender,
                MoveUsed = move,
                DamageDealt = damage,
                StaminaSpent = staminaSpent
            };
        }

        public string MoveExplain
        {
            get
            {
                return Type switch
                {
                    MoveType.HighKick => "High Kick",
                    MoveType.LowKick => "Low Kick",
                    MoveType.HighPunch => "High Punch",
                    MoveType.LowPunch => "Low Punch",
                    MoveType.Block => "Block",
                    MoveType.Dodge => "Dodge",
                    MoveType.SpecialMove => "Special Move",
                    MoveType.Recover => "Recover",
                    _ => "an Unknown Move",
                };
            }
        }

    }

    // KRAV 7:
    // 1: Polymorfism.
    // 2: För att bestämma vilket move som används och kunna använda den vidare i Playerstats och Battle klassen.
    // 3: Att använda enum och polymorfism gör det enkelt att lägga till nya moves i framtiden utan att behöva ändra i existerande kod.
    internal class HighKick : Move
    {
        internal override MoveType Type => MoveType.HighKick;
    }

    internal class LowKick : Move
    {
        internal override MoveType Type => MoveType.LowKick;
    }
    internal class HighPunch : Move
    {
        internal override MoveType Type => MoveType.HighPunch;

    }
    internal class LowPunch : Move
    {
        internal override MoveType Type => MoveType.LowPunch;

    }
    internal class Block : Move
    {
        internal override MoveType Type => MoveType.Block;

    }
    internal class Dodge : Move
    {
        internal override MoveType Type => MoveType.Dodge;

    }
    internal class SpecialMove : Move
    {
        internal override MoveType Type => MoveType.SpecialMove;

    }
    internal class Recover : Move
    {
        internal override MoveType Type => MoveType.Recover;


    }
}
