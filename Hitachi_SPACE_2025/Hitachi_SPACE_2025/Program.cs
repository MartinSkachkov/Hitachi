using Hitachi_SPACE_2025.CosmicNavigation.Models;
using Hitachi_SPACE_2025.CosmicNavigation.Services;
namespace Hitachi_SPACE_2025 {

    class Program {
        static void Main(string[] args) {

            try {
                // Step 1: Get input
                var map = InputHandler.GetCosmicMapInput();

                // Step 2: Parse map
                CosmicMap cosmicMap = MapParser.ParseMap(map.map, map.rows, map.cols);

                // Step 3: Find paths
                PathFinder pathFinder = new PathFinder(cosmicMap);
                int totalPaths = pathFinder.CountAllPaths();
                int shortestPathLength = pathFinder.FindShortestPath().Count;
                List<Position> shortestPath = pathFinder.FindShortestPath();

                // Step 4: Print results
                OutputHandler.PrintResults(totalPaths, shortestPathLength, shortestPath, cosmicMap);

            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
