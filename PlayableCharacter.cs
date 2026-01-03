using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class PlayableCharacter
    {
        public List<string> CharactersList { get; private set; }
        public PlayableCharacter()
        {
            CharactersList = new List<string>
            {
                "Diego",
                "Donald",
                "Wanaporn",
                "Asa",
                "Vladimir",
                "Haakon"
            };
        }
        public void DisplayCharacters()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Available Characters:");
            foreach (var character in CharactersList)
            {
                Console.WriteLine($"- {character}");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public void DisplayStats(Character character)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine($"Displaying stats for {character.Name}:");
            Console.Write($"Character: {character.Name} -- ");
            Console.Write($"Origin: {character.Origin} -- ");
            Console.Write($"Health: {character.Health} -- ");
            Console.WriteLine($"Stamina: {character.Stamina}");

            Console.WriteLine("(Detailed attack stats are hidden in the character class...)");

            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public string SelectCharacter()
        {
            string chosenName;

            while (true)
            {
                Console.Write("Choose a character: ");
                chosenName = Console.ReadLine()?.Trim()!; // remove leading/trailing spaces

                // Check for null or empty input
                if (string.IsNullOrEmpty(chosenName))
                {
                    Console.WriteLine("Error: Name cannot be empty. Try again.");
                    continue;
                }

                // Check if input matches one of the available names (case-insensitive)
                if (!CharactersList.Any(n => n.Equals(chosenName, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Error: Invalid character name. Available options are:");
                    Console.WriteLine(string.Join(", ", CharactersList));
                    continue;
                }

                // Make sure chosenName exactly matches the casing from the array
                chosenName = CharactersList.First(n => n.Equals(chosenName, StringComparison.OrdinalIgnoreCase));
                break;
            }

            return chosenName;
        }
    }
}
