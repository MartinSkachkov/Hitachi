namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Handles user input for the cosmic navigation map.
    // 
    // This class is responsible for:
    // - Prompting the user to enter valid map dimensions (rows and columns) within defined limits.
    // - Reading the cosmic map rows from user input.
    // - Validating each input row to ensure it has the correct number of columns and valid symbols (S, F, O, X).
    // - Re-prompting the user until valid input is provided.
    // 
    // Returns the map dimensions and the map as a string array representing each row.

    internal class InputHandler {

        private const int MIN_DIMENSION = 2;
        private const int MAX_DIMENSION = 100;
        private const string START = "S";
        private const string FINISH = "F";
        private const string OPEN_SPACE = "O";
        private const string ASTEROID = "X";

        public static (int rows, int cols, string[] map) GetCosmicMapInput() {
            int rows = ReadMapDimensions("Enter number of rows (M): ");
            int cols = ReadMapDimensions("Enter number of columns (N): ");

            Console.WriteLine("Enter the cosmic map:");
            string[] map = ReadMapLines(rows, cols);

            return (rows, cols, map);
        }

        private static int ReadMapDimensions(string prompt) {
            while (true) {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input)) {
                    Console.WriteLine("Input cannot be empty. Please enter a valid number between 2 and 100.");
                    continue;
                }

                if (!int.TryParse(input, out int dimension)) {
                    Console.WriteLine("Invalid number format. Please enter a valid number between 2 and 100.");
                    continue;
                }

                if (dimension < MIN_DIMENSION || dimension > MAX_DIMENSION) {
                    Console.WriteLine($"Dimension must be between {MIN_DIMENSION} and {MAX_DIMENSION}. Please try again.");
                    continue;
                }

                return dimension;
            }
        }

        private static string[] ReadMapLines(int rows, int cols) {
            string[] map = new string[rows];

            for (int i = 0; i < rows; i++) {
                while (true) {
                    Console.Write($"Row {i + 1}: ");
                    string input = Console.ReadLine();

                    if (!ValidateEmptyInput(input, i)) continue;
                    if (!ValidateColumnCount(input, cols, i)) continue;
                    if (!ValidateSymbols(input, i)) continue;

                    map[i] = input;
                    break;
                }
            }

            return map;
        }

        private static bool ValidateEmptyInput(string input, int rowIndex) {
            if (string.IsNullOrWhiteSpace(input)) {
                Console.WriteLine($"Row {rowIndex + 1} cannot be empty. Please enter space-separated symbols.");
                return false;
            }

            return true;
        }

        private static bool ValidateColumnCount(string input, int expectedCols, int rowIndex) {
            string[] symbols = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (symbols.Length != expectedCols) {
                Console.WriteLine($"Row {rowIndex + 1} must contain exactly {expectedCols} symbols. Found: {symbols.Length}. Please try again.");
                return false;
            }

            return true;
        }

        private static bool ValidateSymbols(string input, int rowIndex) {
            string[] symbols = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string symbol in symbols) {
                if (symbol != START && symbol != FINISH && symbol != OPEN_SPACE && symbol != ASTEROID) {
                    Console.WriteLine($"Invalid symbol '{symbol}' found in row {rowIndex + 1}. Only S, F, O, X are allowed. Please try again.");
                    return false;
                }
            }

            return true;
        }

    }

}
