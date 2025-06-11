using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Parses a string representation of a cosmic map from the user (inputLines) into a CosmicMap object,
    // validating input format, symbol correctness, and ensuring exactly one start and finish symbol.

    internal class MapParser {

        public static CosmicMap ParseMap(string[] inputLines, int rows, int cols) {
            ValidateInputLines(inputLines);
            ValidateRowsCount(inputLines, rows);

            CosmicMap cosmicMap = new CosmicMap(rows, cols);
            int startSymbolCount = 0;
            int finishSymbolCount = 0;

            for (int row = 0; row < rows; row++) {
                string[] symbols = inputLines[row].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                ValidateColumnsCount(symbols, cols, row);

                for (int col = 0; col < cols; col++) {
                    CosmicSymbol symbol = symbols[col] switch {
                        "S" => CosmicSymbol.Start,
                        "F" => CosmicSymbol.Finish,
                        "O" => CosmicSymbol.OpenSpace,
                        "X" => CosmicSymbol.Asteroid,
                        _ => throw new ArgumentException($"Invalid cosmic symbol '{symbols[col]}' at position ({row + 1}, {col + 1}). Allowed symbols are S, F, O, X.")
                    };

                    if (symbol == CosmicSymbol.Start) {
                        startSymbolCount++;
                    } else if (symbol == CosmicSymbol.Finish) {
                        finishSymbolCount++;
                    }

                    cosmicMap.SetSymbol(row, col, symbol);
                }

            }

            ValidateStartSymbolCount(startSymbolCount);
            ValidateFinishSymbolCount(finishSymbolCount);

            return cosmicMap;
        }

        private static void ValidateInputLines(string[] inputLines) {
            if (inputLines == null) {
                throw new ArgumentNullException(nameof(inputLines), "Input lines cannot be null.");
            }
        }

        private static void ValidateRowsCount(string[] inputLines, int expectedRows) {
            if (inputLines.Length != expectedRows) {
                throw new ArgumentException($"Number of input lines ({inputLines.Length}) does not match the expected number of rows ({expectedRows}).");
            }
        }

        private static void ValidateColumnsCount(string[] symbols, int expectedCols, int row) {
            if (symbols.Length != expectedCols) {
                throw new ArgumentException(
                    $"Row {row + 1} does not contain the expected number of columns ({expectedCols}). Found: {symbols.Length}.");
            }
        }

        private static void ValidateStartSymbolCount(int startSymbolCount) {
            if (startSymbolCount == 0) {
                throw new ArgumentException("Map must contain exactly one start position (S). None found.");
            }

            if (startSymbolCount > 1) {
                throw new ArgumentException($"Map must contain exactly one start position (S). Found: {startSymbolCount}");
            }
        }

        private static void ValidateFinishSymbolCount(int finishSymbolCount) {
            if (finishSymbolCount == 0) {
                throw new ArgumentException("Map must contain exactly one finish position (F). None found.");
            }

            if (finishSymbolCount > 1) {
                throw new ArgumentException($"Map must contain exactly one finish position (F). Found: {finishSymbolCount}");
            }
        }

    }

}