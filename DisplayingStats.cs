using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JourneyOfChampions
{
    internal class DisplayingStats
    {

        public void DisplayStatsDiego()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for Diego:");
            Console.Write($"Character: Diego -- ");
            Console.Write($"Origin: Brazil -- ");
            Console.Write($"Health: 150 -- ");
            Console.WriteLine($"Stamina: 20");
            Console.Write($"High Kick Power: 15 -- ");
            Console.Write($"Low Kick Power: 10 -- ");
            Console.Write($"High Punch Power: 10 -- ");
            Console.Write($"Low Punch Power: 5 -- ");
            Console.WriteLine($"Block Power: 10");
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void DisplayStatsÅsa()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for x:");
            Console.Write($"Character: x -- ");
            Console.Write($"Origin: Iceland -- ");
            Console.Write($"Health: 1 -- ");
            Console.WriteLine($"Stamina: 1");
            Console.Write($"High Kick Power: 1 -- ");
            Console.Write($"Low Kick Power: 1 -- ");
            Console.Write($"High Punch Power: 1 -- ");
            Console.Write($"Low Punch Power: 1 -- ");
            Console.WriteLine($"Block Power: 1");
            Console.ForegroundColor = ConsoleColor.Yellow;

        }

        public void DisplayStatsDonald()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for x:");
            Console.Write($"Character: x -- ");
            Console.Write($"Origin: Iceland -- ");
            Console.Write($"Health: 1 -- ");
            Console.WriteLine($"Stamina: 1");
            Console.Write($"High Kick Power: 1 -- ");
            Console.Write($"Low Kick Power: 1 -- ");
            Console.Write($"High Punch Power: 1 -- ");
            Console.Write($"Low Punch Power: 1 -- ");
            Console.WriteLine($"Block Power: 1");
            Console.ForegroundColor = ConsoleColor.Yellow;

        }

        public void DisplayStatsWanaporn()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for x:");
            Console.Write($"Character: x -- ");
            Console.Write($"Origin: Iceland -- ");
            Console.Write($"Health: 1 -- ");
            Console.WriteLine($"Stamina: 1");
            Console.Write($"High Kick Power: 1 -- ");
            Console.Write($"Low Kick Power: 1 -- ");
            Console.Write($"High Punch Power: 1 -- ");
            Console.Write($"Low Punch Power: 1 -- ");
            Console.WriteLine($"Block Power: 1");
            Console.ForegroundColor = ConsoleColor.Yellow;

        }

        public void DisplayStatsHaakon()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for x:");
            Console.Write($"Character: x -- ");
            Console.Write($"Origin: Iceland -- ");
            Console.Write($"Health: 1 -- ");
            Console.WriteLine($"Stamina: 1");
            Console.Write($"High Kick Power: 1 -- ");
            Console.Write($"Low Kick Power: 1 -- ");
            Console.Write($"High Punch Power: 1 -- ");
            Console.Write($"Low Punch Power: 1 -- ");
            Console.WriteLine($"Block Power: 1");
            Console.ForegroundColor = ConsoleColor.Yellow;

        }

      
        public void DisplayStatsVladimir()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Displaying stats for x:");
            Console.Write($"Character: x -- ");
            Console.Write($"Origin: Iceland -- ");
            Console.Write($"Health: 1 -- ");
            Console.WriteLine($"Stamina: 1");
            Console.Write($"High Kick Power: 1 -- ");
            Console.Write($"Low Kick Power: 1 -- ");
            Console.Write($"High Punch Power: 1 -- ");
            Console.Write($"Low Punch Power: 1 -- ");
            Console.WriteLine($"Block Power: 1");
            Console.ForegroundColor = ConsoleColor.Yellow;

        }

        public void DisplayStats(Character character, string name)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"Displaying stats for {name}:");
            Console.Write($"Character: {name} -- ");
            Console.Write($"Origin: {character.Origin} -- ");
            Console.Write($"Health: {character.Health} -- ");
            Console.WriteLine($"Stamina: {character.Stamina}");

            Console.WriteLine("(Detailed attack stats are hidden in the character class...)");

            Console.ForegroundColor = ConsoleColor.Yellow;           //göra något sånt här istället för att anpassa till uppgiften bättre kanske
        }
    }
}
