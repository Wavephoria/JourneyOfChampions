using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JourneyOfChampions
{
    abstract class Character
    {
        public List<string> Opponents { get; protected set; }
        public MovesUsed Moves { get; protected set; }
        public string Name { get; protected set; }
        public int Health { get; set; }
        public bool IsAlive => Health > 0;      
        public int Stamina { get; set; }
        private int highKickPower;
        public int HighKickPower => highKickPower;
        private int lowKickPower;   
        public int LowKickPower => lowKickPower;
        private int highPunchPower;
        public int HighPunchPower => highPunchPower;
        private int lowPunchPower;  
        public int LowPunchPower => lowPunchPower;
        private int blockPower;
        public int BlockPower => blockPower;
        private int dodgeChance;
        public int DodgeChance => dodgeChance;
        private int recoveryRate; 
        public int RecoveryRate => recoveryRate;
        public string Origin => origin;
        private string origin;

        public Character(string name) 
        {
            Name = name;
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
            Stamina = 150;
            highKickPower = 25;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 10;
            blockPower = 15;
            dodgeChance = 85;
            recoveryRate = 10;
        }
        private void SetDonaldStats()
        {
            name = Characters.Donald;
            origin = "USA";
            Health = 150;
            Stamina = 125;
            highKickPower = 30;
            lowKickPower = 10;
            highPunchPower = 25;
            lowPunchPower = 5;
            blockPower = 20;
            dodgeChance = 60;
            recoveryRate = 10;
        }
        private void SetWanapornStats()
        {
            name = Characters.Wanaporn;
            origin = "Thailand";
            Health = 150;
            Stamina = 200;
            highKickPower = 40;
            lowKickPower = 20;
            highPunchPower = 10;
            lowPunchPower = 5;
            blockPower = 10;
            dodgeChance = 85;
            recoveryRate = 20;
        }
        private void SetAsaStats()
        {
            name = Characters.Asa;
            origin = "Sweden";
            Health = 150;
            Stamina = 175;
            highKickPower = 20;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 15;
            blockPower = 10;
            dodgeChance = 75;
            recoveryRate = 20;
        }
        private void SetVladimirStats()
        {
            name = Characters.Vladimir;
            origin = "Russia";
            Health = 150;
            Stamina = 100;
            highKickPower = 15;
            lowKickPower = 10;
            highPunchPower = 30;
            lowPunchPower = 25;
            blockPower = 20;
            dodgeChance = 55;
            recoveryRate = 15;
        }
        private void SetHaakonStats()
        {
            name = Characters.Haakon;
            origin = "Norway";
            Health = 150;
            Stamina = 125;
            highKickPower = 20;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 15;
            blockPower = 15;
            dodgeChance = 70;
            recoveryRate = 25;
        }
        public virtual string NextOpponent() { return ""; }
        public virtual string CalculateMove(Character champion, Character computer, bool firstBattle) { return ""; }



    }
}
