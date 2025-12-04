using System.Diagnostics;
using System.Threading.Tasks;
using NetCoreAudio;


namespace JourneyOfChampions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Battle battle = new Battle();
            string enemyName;

            Console.Title = "Journey of Champions";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Magenta;

            var musicPlayer = new Player();
            await musicPlayer.Play(@"sounds\QuirkyRunner.mp3");

            DisplayingStats stats = new DisplayingStats();

            Console.WriteLine("Your journey to be a champion starts now!");
            Console.WriteLine("Get ready...");
            Console.WriteLine("Your first decision is to choose which character you wanna use:");
            var s = "SNAAAAAAAAKE"; var cols = new[] { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta, ConsoleColor.White }; for (int i = 0; i < s.Length; i++) { Console.ForegroundColor = cols[i % cols.Length]; Console.SetCursorPosition(i, 10 + (int)(Math.Sin(i / 1.5) * 2)); Console.Write(s[i]); }
            Console.ResetColor();

            string[] availableCharacters =
            {
                "Diego",
                "Donald",
                "Wanaporn",
                "Asa",
                "Vladimir",
                "Haakon"
            };

            Console.WriteLine("You have the following options:");
            foreach (string name in availableCharacters)
            {
                Console.WriteLine($"- {name}");
            }





            Console.Write("Choose a character: ");
            string chosenName = Console.ReadLine();

            Character champion = new Champion(chosenName);

            Console.WriteLine(champion.Name);
            Console.WriteLine(champion.Origin);

            champion.Moves.AddingMoves();

            Console.WriteLine($"(You have chosen {chosenName} as your character!)");

            while (champion.Opponents.Count > 0) 
            {
                enemyName = champion.NextOpponent();
                Console.WriteLine($"Your first opponent is {enemyName}");

                Character enemyChampion = new Computer(enemyName);

                await musicPlayer.Play(@"sounds\TheJazzMan.mp3");
                battle.StartFight(champion, enemyChampion);

            }

            enemyName = champion.NextOpponent(true);

            Character enemyBoss = new Computer(enemyName, true);

            await musicPlayer.Play(@"sounds\QuietTension.mp3");
            Console.WriteLine($"A new challenger awaits {enemyName}, last boss of this journey");

            battle.StartFight(champion, enemyBoss);

            Console.ReadLine();

            
        }

        
    }
}