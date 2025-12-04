using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyOfChampions
{
    internal class Battle : IBattleCalculator
    {
        Moves moves = new Moves();

        private int PlayerDamage { get; set; }
        private int EnemyDamage { get; set; }
        private string PlayerMove { get; set; }
        private string EnemyMove { get; set; }


        public void CalculateDamage(Character player, Character enemy)
        {
            if (EnemyMove == "Block")
            {
                AttackAgainstBlock();
                PlayerDamage -= enemy.BlockPower;
            }
            else if (EnemyMove == "Dodge")
            {
                AttackAgainstDodge();
                PlayerDamage = 0;
            }
            else if (PlayerMove == "Block") 
            { 
                AttackAgainstBlock();
                EnemyDamage -= player.BlockPower;
            }
            else if (PlayerMove == "Dodge") 
            { 
                AttackAgainstBlock();
                EnemyDamage = 0;
            }

            LosingHealth(player, enemy);
            StaminaChange(player, enemy);
        }
        public void CalculateDamageBoss(Character player, Character boss)
        { }
        public void LosingHealth(Character player, Character enemy) 
        { 
            player.Health -= EnemyDamage;
            enemy.Health -= PlayerDamage;
        }
        public void StaminaChange(Character player, Character enemy) 
        { 

            Dictionary<string, int> staminaChanges = new Dictionary<string, int>
            {
                { "High Kick", -20 },
                { "Low Kick", -15 },
                { "High Punch", -15 },
                { "Low Punch", -10 },
                { "Block", -5 },
                { "Dodge", -10 },
                { "Recover", +20 },
                { "Special Move", -30 }
            };

            player.Stamina += staminaChanges.GetValueOrDefault(PlayerMove, 0);
            enemy.Stamina += staminaChanges.GetValueOrDefault(EnemyMove, 0);

        }
        public void AttackAgainstBlock() { }
        public void AttackAgainstDodge() { }


        public void StartFight(Character player, Character enemy)
        {
            Console.WriteLine($"\nA new fight begins! {player.Name} vs {enemy.Name}!");

            while (player.IsAlive && enemy.IsAlive)
            {
                string choice;

                if (player.Stamina <= 0)
                {
                    Console.WriteLine("You ran out of stamina");
                    Console.WriteLine("You can only do recovery");
                    choice = "Recover";
                }

                else
                {
                    Console.WriteLine($"\n{player.Name}: {player.Health} HP and Stamina: {player.Stamina}");
                    Console.WriteLine($"Vs.");
                    Console.WriteLine($"{enemy.Name}: {enemy.Health} HP and Stamina: {enemy.Stamina}");
                    Console.WriteLine();
                    Console.WriteLine("Choose your move:");
                    Console.WriteLine("1) High Kick");
                    Console.WriteLine("2) Low Kick");
                    Console.WriteLine("3) High Punch");
                    Console.WriteLine("4) Low Punch");
                    Console.WriteLine("5) Block");
                    Console.WriteLine("6) Dodge");
                    Console.WriteLine("7) Recover");
                    Console.WriteLine("8) Special Move");
                    Console.Write("Your choice (Write number): ");
                    choice = Console.ReadLine()!;
                }

                
                
                switch (choice)
                {
                    case "1":
                        PlayerMove = "High Kick";
                        player.Moves.MakingMove("High Kick");
                        PlayerDamage = player.HighKickPower;
                        break;
                    case "2":
                        PlayerMove = "Low Kick";
                        player.Moves.MakingMove("Low Kick");
                        PlayerDamage = player.LowKickPower;
                        break;
                    case "3":
                        PlayerMove = "High Punch";
                        player.Moves.MakingMove("High Punch");
                        PlayerDamage = player.HighKickPower;    
                        break;
                    case "4":
                        PlayerMove = "Low Punch";
                        player.Moves.MakingMove("Low Punch");
                        PlayerDamage = player.LowPunchPower;
                        break;
                    case "5":
                        PlayerMove = "Block";
                        player.Moves.MakingMove("Block");
                        PlayerDamage = 0;
                        break;
                    case "6":
                        PlayerMove = "Dodge";
                        player.Moves.MakingMove("Dodge");
                        PlayerDamage = 0;
                        break;
                    case "7":
                        PlayerMove = "Recover";
                        player.Moves.MakingMove("Recover");
                        PlayerDamage = 0;
                        break;
                    case "8":
                        PlayerMove = "Special Move";
                        player.Moves.MakingMove("Special Move");
                        PlayerDamage = player.HighKickPower * 2;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;

                    
                }

                Console.WriteLine($"\nYou chose to do {PlayerMove}!");

                ComputerMove(player, enemy, false);

                CalculateDamage(player, enemy);


            }

            if (player.IsAlive)
            {
                Console.WriteLine($"\n{player.Name} wins the fight!");
            }
            else
            {
                Console.WriteLine($"\n{enemy.Name} wins the fight!");
            }

        }
        public void ComputerMove(Character player, Character computer, bool firstBattle)
        {
            string move = computer.CalculateMove(player, computer, firstBattle);
            EnemyMove = move;
            switch (move)
            {
                case "High Kick":
                    EnemyDamage = computer.HighKickPower;
                    break;
                case "Low Kick":
                    EnemyDamage = computer.LowKickPower;
                    break;
                case "High Punch":
                    EnemyDamage = computer.HighPunchPower;
                    break;
                case "Low Punch":
                    EnemyDamage = computer.LowPunchPower;
                    break;
                case "Block":
                    EnemyDamage = 0;
                    break;
                case "Dodge":
                    EnemyDamage = 0;
                    break;
                case "Recover":
                    EnemyDamage = 0;
                    break;
                case "Special Move":
                    EnemyDamage = computer.HighKickPower * 2;
                    break;
                default:
                    Console.WriteLine("Computer made an invalid move.");
                    break;
            }
            Console.WriteLine($"\n{computer.Name} chose to {move}!");
        }

    }
}
