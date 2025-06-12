using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Handles output related to cosmic navigation results.
    // 
    // This class is responsible for:
    // - Displaying the total number of possible paths from start (S) to finish (F).
    // - Showing the length of the shortest path found.
    // - Printing a visual representation of the shortest path on the map,
    //   with step numbers overlayed on the original map symbols.

    internal class OutputHandler {

        public static void PrintResults(int totalPaths, int shortestLength, List<Position> shortestPath, CosmicMap map) {
            Console.WriteLine($"Number of possible paths from S to F: {totalPaths}");
            Console.WriteLine($"Shortest path length: {shortestLength - 1}");
            Console.WriteLine("Shortest path map:");

            int[,] pathGrid = new int[map.GetRows(), map.GetCols()];

            for (int i = 1; i < shortestLength; i++) {
                Position pos = shortestPath[i];
                pathGrid[pos.GetRow(), pos.GetCol()] = i;
            }

            for (int row = 0; row < map.GetRows(); row++) {
                for (int col = 0; col < map.GetCols(); col++) {
                    if (pathGrid[row, col] > 0) {
                        Console.Write(pathGrid[row, col] + " ");
                    } else {
                        Console.Write((char)map.GetSymbol(row, col) + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }

}
