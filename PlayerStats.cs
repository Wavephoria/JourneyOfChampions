using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class PlayerStats
    {
        // KRAV 3:
        // 1: Computed properties
        // 2: När karaktären skapas så har den redan bestämda stats som grund health och stamina. Det kommer under stridens gång att 
        // förändras beroende på vad som händer i striden.
        // 3: Under stidens gång så kommer både health och stamina ändras och det kommer även loggas vad man änvänder för moves så att 
        // datorn kan anpassa sig efter spelarens spelstil.

        public int MaxHealth { get; private set; }
        public int MaxStamina { get; private set; }
        public int Health { get; private set; }
        public int Stamina { get; private set; }
        public bool isAlive { get; private set; }

        public IReadOnlyDictionary<MoveType, int> DamageByMove => _damageByMove;

        public IReadOnlyDictionary<MoveType, int> MoveUsage => _moveUsage;

        // KRAV 1:
        // 1: Inkapsling / Informationsgömning.
        // 2: Vi har gjort den här dictionary privat och readonly för att skydda datan från att ändras utanför klassen.
        // 3: För att säkerställa att datan i dictionaryn inte ändras av misstag från andra delar av koden så har vi gjort den privat och readonly.

        private readonly Dictionary<MoveType, int> _damageByMove = new();
        private readonly Dictionary<MoveType, int> _moveUsage = new();

        public PlayerStats(Character character)
        {
            Health = character.Health;
            Stamina = character.Stamina;
            MaxHealth = character.Health;
            MaxStamina = character.Stamina;
            isAlive = true;

            _damageByMove = new Dictionary<MoveType, int>()
            {
                { MoveType.HighKick, character.HighKickPower },
                { MoveType.LowKick, character.LowKickPower },
                { MoveType.HighPunch, character.HighPunchPower },
                { MoveType.LowPunch, character.LowPunchPower },
                { MoveType.Block, character.BlockPower },
                { MoveType.Dodge, character.DodgeChance },
                { MoveType.Recover, character.RecoveryRate }
            };

        }
        public Dictionary<MoveType, int> StaminaCostByMove { get; } = new()
        {
            { MoveType.HighKick, 12 },
            { MoveType.LowKick, 8 },
            { MoveType.HighPunch, 10 },
            { MoveType.LowPunch, 6 },
            { MoveType.Block, 5 },
            { MoveType.Dodge, 7 },
            { MoveType.SpecialMove, 25 }
        };

        public void SpendStamina(int amount) => Stamina -= amount;
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health <= 0)
            {
                Health = 0;
                isAlive = false;
            }

        }
        public void IncrementUsage(MoveType moveType) => _moveUsage[moveType] = _moveUsage.GetValueOrDefault(moveType) + 1;

        public void RecoverStats()
        {
            Health = MaxHealth;
            Stamina = MaxStamina;
        }
    }
}


