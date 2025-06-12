using Hitachi_SPACE_2025.CosmicNavigation.Exceptions;
using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Parses string input lines into a validated CosmicMap object.
    // 
    // Responsibilities include:
    // - Converting string symbols ("S", "F", "O", "X") into CosmicSymbol enum values.
    // - Validating each symbol and throwing exceptions on invalid symbols.
    // - Ensuring exactly one Start (S) and one Finish (F) symbol are present,
    //   throwing custom exceptions if missing or duplicated.
    // - Populating the CosmicMap with parsed symbols.

    internal class MapParser {

        public static CosmicMap ParseMap(string[] inputLines, int rows, int cols) {
            CosmicMap cosmicMap = new CosmicMap(rows, cols);
            int startSymbolCount = 0;
            int finishSymbolCount = 0;

            for (int row = 0; row < rows; row++) {
                string[] symbols = inputLines[row].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++) {
                    CosmicSymbol symbol = CosmicSymbolParser.Parse(symbols[col]);

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

        private static void ValidateStartSymbolCount(int startSymbolCount) {
            if (startSymbolCount == 0) {
                throw new MissingStartPositionException();
            }

            if (startSymbolCount > 1) {
                throw new MultipleStartPositionsException(startSymbolCount);
            }
        }

        private static void ValidateFinishSymbolCount(int finishSymbolCount) {
            if (finishSymbolCount == 0) {
                throw new MissingFinishPositionException();
            }

            if (finishSymbolCount > 1) {
                throw new MultipleFinishPositionsException(finishSymbolCount);
            }
        }

    }

}