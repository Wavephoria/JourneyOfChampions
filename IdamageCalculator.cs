using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
   
        interface IDamageCalculator
        {
            int CalculateDamage(int basePower, int attackerStamina, int defenderBlock, int defenderDodgeChance);
        }

        class BasicDamageCalculator : IDamageCalculator
        {
            public int CalculateDamage(int basePower, int attackerStamina, int defenderBlock, int defenderDodgeChance)
            {
                int damage = basePower;

                damage -= defenderBlock / 10;

                if (damage < 0)
                    damage = 0;

            if (damage > 100)
                damage = 0;

                return damage;
            }
        }

    class BossDamageCalculator : IDamageCalculator
    {
        public int CalculateDamage(int basePower, int attackerStamina, int defenderBlock, int defenderDodgeChance)
        {
            int damage = basePower + 30; 
            damage -= defenderBlock / 10; 
            if (damage < 0) damage = 0;
            return damage;
        }
    }
}

