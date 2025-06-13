using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Generates CSV reports for cosmic navigation results.
    // 
    // This class is responsible for:
    // - Creating a user-friendly CSV report of the map displaying the shortest path
    // - Formatting the path with step numbers and original symbols

    internal class CsvReportGenerator {

        public static void GenerateShortestPathReport(string filePath, int shortestLength, List<Position> shortestPath, CosmicMap map) {

            try {
                using (StreamWriter sw = new StreamWriter(filePath)) {
                    int[,] pathGrid = new int[map.GetRows(), map.GetCols()];

                    for (int i = 1; i < shortestLength; i++) {
                        Position pos = shortestPath[i];
                        pathGrid[pos.GetRow(), pos.GetCol()] = i;
                    }

                    for (int row = 0; row < map.GetRows(); row++) {
                        List<string> rowValues = new List<string>();
                        rowValues.Add($"row{row}");

                        for (int col = 0; col < map.GetCols(); col++) {
                            string cellValue;

                            if (pathGrid[row, col] > 0) {
                                cellValue = pathGrid[row, col].ToString();
                            } else {
                                CosmicSymbol symbol = map.GetSymbol(row, col);
                                cellValue = CosmicSymbolParser.ParseToStringSymbol(symbol);
                            }

                            rowValues.Add(cellValue);
                        }

                        sw.WriteLine(string.Join(",", rowValues));
                    }
                }

                Console.WriteLine($"CSV report successfully generated: {filePath}");
            } catch (Exception ex) {
                Console.WriteLine($"Error generating CSV report: {ex.Message}");
            }

        }

        public static string GenerateDefaultFileName() {
            string csvDir = GenerateCsvResultsFolder();
            return Path.Combine(csvDir, $"cosmic_navigation_report_{DateTime.Now:yyyyMMdd_HHmmss}.csv");
        }

        public static string GenerateCustomFileName(string fileName) {
            string csvDir = GenerateCsvResultsFolder();
            return Path.Combine(csvDir, fileName);
        }

        private static string GenerateCsvResultsFolder() {
            string projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string csvDir = Path.Combine(projectDir, "CsvResults");
            Directory.CreateDirectory(csvDir);

            return csvDir;
        }

    }
}
