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
            Console.WriteLine("Your first decision is to choose which character you wanna use");
            Console.WriteLine("You have the following options: Jorge, Donald, Wanaporn, Asa, Vladimir, Haakon");

            Character champion = new Champion("Diego");

            Console.WriteLine("You have chosen Diego as your character!");
            Console.WriteLine("Here are his stats:");

            foreach (string name in champion.Opponents)
            {
                Console.WriteLine($"- {name}");
            }
    
            

            stats.DisplayStatsDiego();
            Console.ReadLine();

            champion.LosingHealth(20);

            Console.WriteLine($"Diego's health after taking damage: {champion.Health}");







        }

        

    }
}
