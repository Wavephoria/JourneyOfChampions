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
        public List<string> Opponents { get; protected set; } //HMMMMMM
        public MovesUsed Moves { get; protected set; }  //HMMMMM

        protected string origin;
        public int Health { get; protected set; }
        private int stamina;
        private int highKickPower;  // high damage, high stamina cost
        private int lowKickPower;   // medium damage, medium stamina cost
        private int highPunchPower; // medium damage, medium stamina cost
        private int lowPunchPower;  // low damage, low stamina cost
        private int blockPower;     // reduces damage taken, low stamina gain
        private int dodgeChance;    // chance to completely avoid an attack, medium stamina gain
        private int recoveryRate;  // recovers stamina while doing nothing, high stamina gain, takes full damage

        // Character movements will affect stamina and health differently based on their power levels
        // Moves: High Kick, Low Kick, High Punch, Low Punch, Block, Dodge, Recover


        private IDamageCalculator calculator; //HMMMM

       
       
        public string Origin => origin;
        public bool IsAlive => Health > 0;

       
        public int BlockPower => blockPower;
        public int DodgeChance => dodgeChance;
        public int Stamina => stamina;


        public Character(string name) 
        {
            Opponents = new List<string>();
            Moves = new MovesUsed();

            switch (name)
            {
                case "Diego":
                    SetDiegoStats();
                    break;
                

                case "Donald":
                    SetDonaldStats();
                    break;

                case "Wanaporn":
                    SetWanapornStats();
                    break;

                case "Asa":
                    SetAsaStats();
                    break;

                case "Vladimir":
                    SetVladimirStats();
                    break;

                case "Haakon":
                    SetHaakonStats();
                    break;

                default:
                    throw new ArgumentException("Unknown character name", nameof(name));

            }

        }

        public virtual void SpecialMove(Character target)
        {
            switch (name)
            {
                case Characters.Diego:
                    Console.WriteLine("Diego Uses brazilian spin kick");
                    target.LosingHealth(highKickPower * 2);
                    stamina -= 30;
                    break;

                case Characters.Donald:
                    Console.WriteLine("Atomic strike");
                    target.LosingHealth(highPunchPower * 2);
                    stamina -= 25;
                    break;

                case Characters.Wanaporn:
                    Console.WriteLine("Wanaporn uses Muay Thai Fury!");
                    target.LosingHealth(lowKickPower * 3);
                    stamina -= 20;
                    break;

                case Characters.Asa:
                    Console.WriteLine("Åsa uses FrostHeal");
                    target.LosingHealth(lowPunchPower * 2);
                    Health += 10; // lite heal
                    stamina -= 10;
                    break;

                case Characters.Vladimir:
                    Console.WriteLine("Vladimir uses Bear Hug!");
                    target.LosingHealth(highPunchPower * 3);
                    stamina -= 40;
                    break;

                case Characters.Haakon:
                    Console.WriteLine("Haakon uses Fjord Smash!");
                    target.LosingHealth(highKickPower * 2 + lowKickPower);
                    stamina -= 30;
                    break;
            }

            if (stamina < 0) stamina = 0;
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

        private void SetDonaldStats()
        {
            name = Characters.Donald;
            origin = "USA";
            Health = 1;
            stamina = 1;
            highKickPower = 1;
            lowKickPower = 1;
            highPunchPower = 1;
            lowPunchPower = 1;
            blockPower = 1;
            dodgeChance = 1;
            recoveryRate = 1;
        }

        private void SetWanapornStats()
        {
            name = Characters.Wanaporn;
            origin = "Thailand";
            Health = 1;
            stamina = 1;
            highKickPower = 1;
            lowKickPower = 1;
            highPunchPower = 1;
            lowPunchPower = 1;
            blockPower = 1;
            dodgeChance = 1;
            recoveryRate = 1;
        }

        private void SetAsaStats()
        {
            name = Characters.Asa;
            origin = "Sweden";
            Health = 1;
            stamina = 1;
            highKickPower = 1;
            lowKickPower = 1;
            highPunchPower = 1;
            lowPunchPower = 1;
            blockPower = 1;
            dodgeChance = 1;
            recoveryRate = 1;
        }

        private void SetVladimirStats()
        {
            name = Characters.Vladimir;
            origin = "Russia";
            Health = 1;
            stamina = 1;
            highKickPower = 1;
            lowKickPower = 1;
            highPunchPower = 1;
            lowPunchPower = 1;
            blockPower = 1;
            dodgeChance = 1;
            recoveryRate = 1;
        }

        private void SetHaakonStats()
        {
            name = Characters.Haakon;
            origin = "Norway";
            Health = 1;
            stamina = 1;
            highKickPower = 1;
            lowKickPower = 1;
            highPunchPower = 1;
            lowPunchPower = 1;
            blockPower = 1;
            dodgeChance = 1;
            recoveryRate = 1;
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

        public virtual void HighKick(Character target)
        {
            int damage = highKickPower;
            target.LosingHealth(damage);
            Moves.MakingMove("High Kick");
            stamina -= 20;
        }

        public virtual void LowKick(Character target)
        {
            int damage = lowKickPower;
            target.LosingHealth(damage);
            Moves.MakingMove("High Kick");
            stamina -= 10;
        }

        public virtual void HighPunch(Character target)
        {
            
        }

        public virtual void LowPunch(Character target)
        {
            
        }

        public virtual void Block()
        {
           
        }

        public virtual void Dodge()
        {
            
        }

        public virtual void Recover()
        {
            
        }

    }
}
