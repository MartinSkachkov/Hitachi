using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

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
