using System.Diagnostics;
using System.Threading.Tasks;
using NetCoreAudio;


namespace JourneyOfChampions
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Move executer = new Move();
            Battle battle = new Battle(executer);
            DisplayingOptions displaying = new DisplayingOptions();
            string enemyName;

            Console.Title = "Journey of Champions";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Magenta;

            // var musicPlayer = new Player();
            // await musicPlayer.Play(@"sounds\QuirkyRunner.mp3")

            Console.WriteLine("Your journey to be a champion starts now!");
            Console.WriteLine("Get ready...");
            Console.WriteLine("Your first decision is to choose which character you wanna use:");

            displaying.DisplayAvailableCharacters();


            Console.Write("Choose a character: ");
            string chosenName = Console.ReadLine();

            Character champion = new Champion(chosenName);

            displaying.DisplayStats(champion, chosenName);

            Console.WriteLine("Do you want to play against computer or another player? (Type 'computer' or 'player')");
            string opponentType = Console.ReadLine().ToLower();
            if (opponentType == "player")
            {
                Console.Write("Enter the name of your opponent: ");
                enemyName = Console.ReadLine();
                Character opponent = new Champion(enemyName);
                battle.StartFight(champion, opponent);
                return;
            }

            else 
            {
                while (champion.Opponents.Count != 0 && champion.IsAlive == true)
                {
                    Character computer = new Computer(champion.NextOpponent());
                    battle.StartFight(champion, computer);

                    foreach (var moveUsages in champion.Stats.MoveUsage)
                    {
                        Console.WriteLine($"{moveUsages.Key}: used {moveUsages.Value} times.");
                    }
                }

                if (champion.Opponents.Count == 0 && champion.IsAlive == true)
                {

                    Console.WriteLine("Congratulations! You have defeated all opponents in the world circuit!");
                    Console.WriteLine("Now is the time for the ultimate challenge");

                    Character finalBoss = new Computer("Snake", "boss");
                    battle.StartFight(champion, finalBoss);

                }


            }


            if (champion.IsAlive)
            {
                Console.WriteLine("Congratulations! You are the Journey of Champions winner!");
            }
            else
            {
                Console.WriteLine("You have been defeated. Better luck next time!");
            }
        }

        
    }
}