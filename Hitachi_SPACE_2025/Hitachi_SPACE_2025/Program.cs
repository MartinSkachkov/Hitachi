using Hitachi_SPACE_2025.CosmicNavigation.Models;
using Hitachi_SPACE_2025.CosmicNavigation.Services;
namespace Hitachi_SPACE_2025 {

    class Program {
        static void Main(string[] args) {

            try {
                string[] mapInput = new string[] {
            "S O X O O O O",
            "X O O O O X O",
            "X X O X O X O",
            "O X X O O X O",
            "O X X O O O F"
        };

                int rows = 5;
                int cols = 7;

                // Parse the map from string input
                CosmicMap map = MapParser.ParseMap(mapInput, rows, cols);

                Console.WriteLine("Parsed cosmic map:");
                MapPrinter.PrintMap(map);

                // Use PathFinder to count all paths using DFS
                PathFinder pathFinder = new PathFinder(map);
                int numberOfPaths = pathFinder.CountPathsUsingDFS();
                List<Position> shortestPath = pathFinder.FindShortestPathUsingBFS();

                OutputHandler.PrintResults(numberOfPaths, shortestPath.Count, shortestPath, map);



            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try {
                string[] mapInput = new string[] {
            "S O O",
            "O O O",
            "O O F"
        };

                int rows = 3;
                int cols = 3;

                CosmicMap map = MapParser.ParseMap(mapInput, rows, cols);

                Console.WriteLine("Parsed cosmic map:");
                MapPrinter.PrintMap(map);

                PathFinder pathFinder = new PathFinder(map);
                int numberOfPaths = pathFinder.CountPathsUsingDFS();

                Console.WriteLine($"Number of possible paths from S to F: {numberOfPaths}");

                List<Position> shortestPath = pathFinder.FindShortestPathUsingBFS();
                Console.WriteLine($"Shortest path is {shortestPath.Count}");

            } catch (Exception ex) {
                Console.WriteLine($"Error: {ex.Message}");
            }

        }
    }

}
