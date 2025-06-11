using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Responsible for printing the CosmicMap to the console,
    // displaying each CosmicSymbol as its corresponding character.

    internal class MapPrinter {

        public static void PrintMap(CosmicMap map) {
            if (map == null)
                throw new ArgumentNullException(nameof(map), "CosmicMap instance cannot be null.");

            for (int row = 0; row < map.GetRows(); row++) {
                for (int col = 0; col < map.GetCols(); col++) {
                    CosmicSymbol symbol = map.GetSymbol(row, col);
                    Console.Write((char)symbol + " ");
                }
                Console.WriteLine();
            }
        }

    };

}