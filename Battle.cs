using NetCoreAudio;
using NetCoreAudio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Battle
    {

        // KRAV 5:
        // 1: Beroendeinjektion
        // 2: Battle använder sig direkt av Move klassen för att kunna exekvera moves.
        // 3: För att säkerhetställa att Battle kan exekvera moves så injiceras Move klassen in i Battle klassen via konstruktorn.

        private readonly Move _moveExecutor;
        public Battle(Move moveExecutor)
        {
            _moveExecutor = moveExecutor;
        }

        public void StartFight(Character player1, Character player2)
        {
            Move Player1Move;
            Move Player2Move;

            Console.WriteLine($"\nA new fight begins! {player1.Name} vs {player2.Name}!");

            while (player1.IsAlive && player2.IsAlive)
            {

                Console.WriteLine($"\n{player1.Name}: {player1.Stats.Health} HP and Stamina: {player1.Stats.Stamina}");
                Console.WriteLine($"Vs.");
                Console.WriteLine($"{player2.Name}: {player2.Stats.Health} HP and Stamina: {player2.Stats.Stamina}");
                Console.WriteLine();
                
                Player1Move = GetPlayerMove();



                Console.WriteLine($"\nYou chose to do {Player1Move.MoveExplain}!");

                if (player2 is Computer)
                {
                    string move = ComputerMove(player1, player2, false);
                    Player2Move = GetPlayerMove(move);
                    Console.WriteLine($"\nComputer chose to do {Player2Move.MoveExplain}!");
                }
                else 
                { 
                    Player2Move = GetPlayerMove();
                    Console.WriteLine($"\nYou chose to do {Player2Move.MoveExplain}!");
                }

                var outcome = MakeMove(player1, Player1Move, player2, Player2Move);

                Console.WriteLine($"{outcome.player1Outcome.Attacker.Name} dealt {outcome.player1Outcome.DamageDealt} damage!");
                Console.WriteLine($"{outcome.player2Outcome.Attacker.Name} dealt {outcome.player2Outcome.DamageDealt} damage!");
            }

            

            if (player1.IsAlive)
            {
                Console.WriteLine($"\n{player2.Name} has been defeated.");
                Console.WriteLine($"\n{player1.Name} wins the fight!");
                player1.Stats.RecoverStats();
            }
            else
            {
                Console.WriteLine($"\n{player2.Name} wins the fight!");
            }

        }
        public (MoveOutcome player1Outcome, MoveOutcome player2Outcome) MakeMove( Character player1, Move player1Move, Character player2, Move player2Move)
        {
            var player1Outcome = _moveExecutor.Execute(player1, player2, player1Move);
            var player2Outcome = _moveExecutor.Execute(player2, player1, player2Move);

            return (player1Outcome, player2Outcome);
        }

        public static void ShowMoveMenu()
        {
            Console.WriteLine("Choose your move:");
            Console.WriteLine("1 - High Kick");
            Console.WriteLine("2 - Low Kick");
            Console.WriteLine("3 - High Punch");
            Console.WriteLine("4 - Low Punch");
            Console.WriteLine("5 - Block");
            Console.WriteLine("6 - Dodge");
            Console.WriteLine("7 - Recover");
            Console.WriteLine("8 - Special Move");
        }

        public static Move GetPlayerMove()
        {
            while (true)
            {
                ShowMoveMenu();
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    try
                    {
                        return MoveFactory.CreateMove(choice);
                    }
                    catch
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number.");
                }
            }
        }
        public static Move GetPlayerMove(string move)
        {

            return MoveFactory.CreateMove(move);

        }

        public string ComputerMove(Character player, Character computer, bool firstBattle)
        {
            return computer.CalculateMove(player, computer, firstBattle);
        }

    }
}
