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
        // 1: Subtypspolymorfism
        // 2: En supertyp som styr hur karaktärer i spelet fungerar och sedan subtyper som är specifika karaktärer som ärver från supertypen.
        // 3: I spelet så kommer det finnas möjlighet att antingen spela mot en annan spelare eller mot datorn. Därför har vi en supertyp
        // som styr den grundläggande logiken och sen subtyper för spelare och dator då de skiljer sig åt i vissa delar.
        // När man skapar sin spelare och spelar mot en dator så skapas en lista på vilka motståndare men har kvar att möta. Den listan töms efter varje
        // vunnen match. En dator använder den listan för att bestämma nästa motståndare och dessutom använder datorn spelarens statistik för att
        // anpassa sin spelstil.
        public List<string>? Opponents { get; protected set; }
        public PlayerStats Stats { get; init; }
        public string? Name { get; protected set; }
        public int Health { get; set; }
        public bool IsAlive => Stats!.isAlive;
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
        public string Origin => origin!;
        private string? origin;

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

            // KRAV 4:
            // 1: Objectkomposition
            // 2: När man skapar en karaktär i spelet så måste den också hämta in stats för den specifika karaktären och hålla
            // koll på när statsen ändrar sig, därför har varje karaktär en egen playerstats där man förändrar alla data genom.
            // 3: För att vara karaktär i spelet har olika stats och under stridens gång ändras även statistiken för karaktären.

            Stats = new PlayerStats(this);
        }
        public Character(string name, string boss) 
        {

        }

        public void UseMove(Move move) => Stats.IncrementUsage(move.Type);

        public bool TrySpendStaminaFor(Move move)
        {
            if (Stats.StaminaCostByMove.TryGetValue(move.Type, out int cost) && Stats.Stamina >= cost)
            {
                Stats.SpendStamina(cost);
                return true;
            }
            return false;
        }

        public int CalculateDamage(Move move) => Stats.DamageByMove.GetValueOrDefault(move.Type);

        public void TakeDamage(int amount) => Stats.TakeDamage(amount);





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
        protected void SetDiegoStats()
        {
            name = Characters.Diego;
            origin = "Brazil";
            Health = 150;
            Stamina = 150;
            highKickPower = 200;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 10;
            blockPower = 15;
            dodgeChance = 85;
            recoveryRate = 10;
        }
        protected void SetDonaldStats()
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
        protected void SetWanapornStats()
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
        protected void SetAsaStats()
        {
            name = Characters.Asa;
            origin = "Sweden";
            Health = 150;
            Stamina = 175;
            highKickPower = 15;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 15;
            blockPower = 10;
            dodgeChance = 75;
            recoveryRate = 20;
        }
        protected void SetVladimirStats()
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
        protected void SetHaakonStats()
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
        public virtual string CalculateMove(Character champion, Character computer, bool firstBattle) { return ""; }



    }
}
