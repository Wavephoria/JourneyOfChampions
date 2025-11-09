using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Character
    {
        private string origin = "Sweden";
        private int health;
        private int stamina;
        private int highKickPower;
        private int lowKickPower;
        private int highPunchPower;
        private int lowPunchPower;
        private int blockPower;

        // private int speed;

        public Character(string name) 
        {
            switch (name)
            {
                case "Jorge":
                    SetJorgeStats();
                    break;
                default:
                    break;
            }

        }

        public void DisplayStatsJorge()
        {
            Console.WriteLine($"Character: {name}");
            Console.WriteLine($"Origin: Brazil");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Stamina: {stamina}");
            Console.WriteLine($"High Kick Power: {highKickPower}");
            Console.WriteLine($"Low Kick Power: {lowKickPower}");
            Console.WriteLine($"High Punch Power: {highPunchPower}");
            Console.WriteLine($"Low Punch Power: {lowPunchPower}");
            Console.WriteLine($"Block Power: {blockPower}");
        }

        private Characters name;
        enum Characters
        {
            Jorge,
            Donald,
            Wanaporn,
            Asa,
            Vladimir,

        }

        private void SetJorgeStats()
        {
            name = Characters.Jorge;
            origin = "Brazil";
            health = 150;
            stamina = 100;
            highKickPower = 25;
            lowKickPower = 15;
            highPunchPower = 20;
            lowPunchPower = 10;
            blockPower = 30;
        }

    }
}
