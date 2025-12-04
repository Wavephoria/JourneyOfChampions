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
        // KRAV 6:
        // 1: Subtypspolymorfism/Arv
        // 2: Klasserna Champion och Computer ärver direkt från Character-klassen.
        // 3: Character-klassen innehåller properties och metoder som är gemensamma för båda subklasserna.
        // Men hur man spelar skiljer sig om det är en spelare eller dator som gör draget.

        // KRAV 1:
        // 1: Inkapsling/Informationskapsling
        // 2: Användning av protected för properties och fields som ska ärvas.
        // 3: När man skapar sin karaktär i Champion-klassen så kan man använda sig av dessa properties.

        public List<string> Opponents { get; protected set; }
        public MovesUsed Moves { get; protected set; }
        public string Name { get; protected set; }

        // KRAV 3:
        // 1: Computed Properties
        // 2: Health har ett värde som ändras i klassen Battle när man tar skada.
        // 3: För att räkna ut om man fortfarande är vid liv.
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

                case "Snake":
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
            Haakon,
            Snake
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
            highKickPower = 150;
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

        protected void SetSnakeStats()
        {
            name = Characters.Snake;
            origin = "Unknown";
            Health = 1000;
            Stamina = 1000;
            highKickPower = 100;
            lowKickPower = 80;
            highPunchPower = 40;
            lowPunchPower = 80;
            blockPower = 40;
            dodgeChance = 99;
            recoveryRate = 50;

        }


        public virtual string NextOpponent() { return ""; }
        public virtual string NextOpponent(bool boss) { return ""; }
        public virtual string CalculateMove(Character champion, Character computer, bool firstBattle) { return ""; }



    }
}
