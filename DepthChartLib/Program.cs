using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        DepthChart depthChart = new DepthChart();
        List<Player> players = new List<Player>(); // Keep track of all added players
        string input;

        do
        {
            Console.WriteLine("Enter player ID:");
            int playerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter player name:");
            string playerName = Console.ReadLine();

            Console.WriteLine("Enter player position (QB, WR, RB, TE, K, P, KR, PR):");
            Position position = (Position)Enum.Parse(typeof(Position), Console.ReadLine(), true);

            Console.WriteLine("Enter player depth (leave blank for default):");
            input = Console.ReadLine();
            int? depth = string.IsNullOrEmpty(input) ? null : int.Parse(input);

            Player player = new Player(playerId, playerName);
            depthChart.AddPlayerToDepthChart(player, position, depth);
            players.Add(player); // Add to local list

            Console.WriteLine("Add another player? (yes/no)");
            input = Console.ReadLine();
        } while (input.Trim().ToLower() == "yes");

        Console.WriteLine("\nFull Depth Chart:");
        depthChart.GetFullDepthChart();

        // Removing players
        do
        {
            Console.WriteLine("Remove a player? (yes/no)");
            input = Console.ReadLine();
            if (input.Trim().ToLower() == "yes")
            {
                Console.WriteLine("Enter player ID to remove:");
                int idToRemove = int.Parse(Console.ReadLine());

                Player playerToRemove = players.Find(p => p.PlayerId == idToRemove);
                if (playerToRemove != null)
                {
                    Console.WriteLine($"Enter position from which to remove {playerToRemove.Name}:");
                    Position positionToRemove = (Position)Enum.Parse(typeof(Position), Console.ReadLine(), true);
                    depthChart.RemovePlayerFromDepthChart(playerToRemove, positionToRemove);
                    Console.WriteLine($"{playerToRemove.Name} removed from {positionToRemove}.");
                }
                else
                {
                    Console.WriteLine("Player not found.");
                }
            }

            Console.WriteLine("\nUpdated Depth Chart:");
            depthChart.GetFullDepthChart();
        } while (input.Trim().ToLower() == "yes");
    }
}