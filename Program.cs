using System.Diagnostics;
using System.Threading.Tasks;
using NetCoreAudio;


namespace JourneyOfChampions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {



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





            Console.WriteLine($"(You have chosen {chosenName} as your character!)");
            Console.WriteLine("These are your opponents:");

            foreach (string name in champion.Opponents)
            {
                Console.WriteLine($"- {name}");
            }







            //stats.DisplayStatsDiego();
            //Console.ReadLine();

            //champion.LosingHealth(20);

            //Console.WriteLine($"Diego's health after taking damage: {champion.Health}");

            //champion.Moves.MakingMove("High Kick");
            //Console.WriteLine(champion.Moves.HighKicksUsed);







        }

        //Helt GPT
        static void StartFight(Character player, Character enemy, string enemyName)
        {
            Console.WriteLine($"\nA new fight begins! You vs {enemyName}!");

            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine($"\nYour HP: {player.Health}  |  {enemyName}'s HP: {enemy.Health}");
                Console.WriteLine("Choose your move:");
                Console.WriteLine("1) High Kick");
                Console.WriteLine("2) Low Kick");
                Console.WriteLine("3) Special Move");
                Console.Write("Your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        player.HighKick(enemy);
                        break;
                    case "2":
                        player.LowKick(enemy);
                        break;
                    case "3":
                        player.SpecialMove(enemy);
                        break;
                    default:
                        Console.WriteLine("You hesitated and missed your turn...");
                        break;
                }

                //helt gpt FORTSÄTT??

            }
        }
    }
}