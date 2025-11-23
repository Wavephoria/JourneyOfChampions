using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    abstract class Character : IMove
    {
        public List<string> Opponents { get; protected set; }

        protected string origin = "Sweden";
        public int Health { get; protected set; }
        protected int stamina;
        protected int highKickPower;  // high damage, high stamina cost
        protected int lowKickPower;   // medium damage, medium stamina cost
        protected int highPunchPower; // medium damage, medium stamina cost
        protected int lowPunchPower;  // low damage, low stamina cost
        protected int blockPower;     // reduces damage taken, low stamina gain
        protected int dodgeChance;    // chance to completely avoid an attack, medium stamina gain
        protected int recoveryRate;  // recovers stamina while doing nothing, high stamina gain, takes full damage

        // Character movements will affect stamina and health differently based on their power levels
        // Moves: High Kick, Low Kick, High Punch, Low Punch, Block, Dodge, Recover


        public Character(string name) 
        {
            switch (name)
            {
                case "Diego":
                    SetDiegoStats();
                    break;
                default:
                    break;
            }

        }

        private Characters name;
        enum Characters
        {
            Diego,
            Donald,
            Wanaporn,
            Asa,
            Vladimir,
            Haakon

        }

        private void SetDiegoStats()
        {
            name = Characters.Diego;
            origin = "Brazil";
            Health = 150;
            stamina = 100;
            highKickPower = 25;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 10;
            blockPower = 30;
        }

        public virtual void NextOpponent() { }
        public void LosingHealth(int damage) 
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}
