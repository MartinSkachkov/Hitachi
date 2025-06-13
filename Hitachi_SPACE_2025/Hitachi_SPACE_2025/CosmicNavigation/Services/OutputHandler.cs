using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Handles output and reporting for cosmic navigation results.
    //
    // This class is responsible for:
    // - Printing the total number of paths and the shortest path length.
    // - Displaying a visual representation of the shortest path overlayed on the map.
    // - Generating a CSV report for the shortest path, with user interaction for file naming.
    // 
    // Provides methods for displaying results in the console and exporting them as a CSV file.

    internal class OutputHandler {

        public static void PrintResults(int totalPaths, int shortestLength, List<Position> shortestPath, CosmicMap map) {
            Console.WriteLine();
            Console.WriteLine("=== Mission Results ===");
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

        public static void GenerateCsvReport(int shortestLength, List<Position> shortestPath, CosmicMap map) {
            while (true) {
                Console.WriteLine();
                Console.Write("Generate CSV report? (y/n): ");
                string response = Console.ReadLine().Trim().ToLower();

                if (response == "y" || response == "yes") {

                    while (true) {
                        Console.Write("Enter CSV file path (or press Enter for default): ");
                        string filePath = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(filePath)) {
                            filePath = CsvReportGenerator.GenerateDefaultFileName();
                        }

                        if (!filePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase)) {
                            filePath += ".csv";
                            filePath = CsvReportGenerator.GenerateCustomFileName(filePath);
                        }

                        try {
                            CsvReportGenerator.GenerateShortestPathReport(
                                filePath,
                                shortestLength,
                                shortestPath,
                                map);

                            break;
                        } catch (Exception ex) {
                            Console.WriteLine($"Error generating CSV report: {ex.Message}");
                            Console.WriteLine("Please try again.");
                        }

                    }

                    break;
                } else if (response == "n" || response == "no") {
                    Console.WriteLine("CSV report generation skipped.");
                    break;
                } else {
                    Console.WriteLine("Invalid response. Please enter 'y' (yes) or 'n' (no).");
                }
            }
        }

    }

}
