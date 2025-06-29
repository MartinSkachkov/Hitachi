﻿namespace Hitachi_SPACE_2025.CosmicNavigation.Models {

    // Defines the set of possible symbols used on the cosmic navigation map.
    // 
    // Each symbol represents a specific type of cell on the map:
    // - Start ('S'): The starting point for navigation.
    // - Finish ('F'): The destination point.
    // - OpenSpace ('O'): Traversable empty space.
    // - Asteroid ('X'): An obstacle blocking movement.

    public enum CosmicSymbol {
        Start = 'S',
        Finish = 'F',
        OpenSpace = 'O',
        Asteroid = 'X'
    }

    // Helper class to parse string representations of cosmic symbols into their corresponding enum values and reverse.
    // Throws an exception if an invalid symbol is provided.

    internal class CosmicSymbolParser {
        public static CosmicSymbol ParseToCosmicSymbol(string symbol) {
            return symbol switch {
                "S" => CosmicSymbol.Start,
                "F" => CosmicSymbol.Finish,
                "O" => CosmicSymbol.OpenSpace,
                "X" => CosmicSymbol.Asteroid,
                _ => throw new ArgumentException($"Invalid cosmic symbol '{symbol}'. Allowed symbols are S, F, O, X.")
            };
        }

        public static string ParseToStringSymbol(CosmicSymbol symbol) {
            return symbol switch {
                CosmicSymbol.Start => "S",
                CosmicSymbol.Finish => "F",
                CosmicSymbol.OpenSpace => "O",
                CosmicSymbol.Asteroid => "X",
                _ => throw new ArgumentException($"Invalid cosmic symbol '{(char)symbol}'. Allowed symbols are S, F, O, X.")
            };
        }
    }

}