namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    internal class InputHandler {
        private const int MIN_DIMENSION = 2;
        private const int MAX_DIMENSION = 100;

        public static (int rows, int cols, string[] map) GetCosmicMapInput() {
            int rows = readMapDimensions("Enter number of rows (M): ");
            int cols = readMapDimensions("Enter number of columns (N): ");

            Console.WriteLine("Enter the cosmic map:");
            string[] map = new string[rows];

            for (int i = 0; i < rows; i++) {
                Console.Write($"Row {i + 1}: ");
                map[i] = Console.ReadLine();

                if (string.IsNullOrEmpty(map[i])) {
                    throw new ArgumentException($"Row {i + 1} cannot be empty");
                }
            }

            return (rows, cols, map);
        }

        private static int readMapDimensions(string prompt) {
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

    }
}
