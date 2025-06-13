using Hitachi_SPACE_2025.CosmicNavigation.Models;
using Hitachi_SPACE_2025.CosmicNavigation.Services;
namespace Hitachi_SPACE_2025 {

    class Program {

        // The main entry point for the Hitachi_SPACE_2025 cosmic navigation program.
        //
        // This class is responsible for:
        // - Orchestrating the workflow of the application.
        // - Accepting user input for the cosmic map through InputHandler.
        // - Parsing the input into a structured CosmicMap.
        // - Utilizing the PathFinder to calculate all paths and the shortest path.
        // - Displaying the results using OutputHandler, including optional CSV report generation.

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

                // Step 5: Generate CSV report if requested
                OutputHandler.GenerateCsvReport(shortestPath.Count, shortestPath, cosmicMap);

                Console.WriteLine();
                Console.WriteLine("Mission completed successfully!");
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

    }

}
