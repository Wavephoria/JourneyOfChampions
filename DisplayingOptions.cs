using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JourneyOfChampions
{
    internal class DisplayingOptions
    {
        string[] availableCharacters =
        {
                "Diego",
                "Donald",
                "Wanaporn",
                "Asa",
                "Vladimir",
                "Haakon"
        };
        public void DisplayAvailableCharacters()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Available Characters:");
            foreach (var character in availableCharacters)
            {
                Console.WriteLine($"- {character}");
            }
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

            Console.ForegroundColor = ConsoleColor.Yellow;
        }
    }
}
