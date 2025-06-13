using Hitachi_SPACE_2025.CosmicNavigation.Exceptions;

namespace Hitachi_SPACE_2025.CosmicNavigation.Models {

    // Represents and manages a 2D cosmic navigation map.
    //
    // This class is responsible for:
    // - Storing a grid of symbols representing the cosmic map.
    // - Enforcing boundary constraints on the map dimensions (minimum and maximum size).
    // - Providing methods to set and retrieve symbols at specific positions.
    // - Validating symbol placements for start and finish markers.
    // - Ensuring all grid interactions are within bounds.
    // 
    // Offers properties for retrieving map dimensions, and start/finish positions.

    internal class CosmicMap {

        private const int MinDimension = 2;
        private const int MaxDimension = 100;

        private CosmicSymbol[,] grid;
        private int rows;
        private int cols;
        private Position startPosition;
        private Position endPosition;

        public CosmicMap(int rows, int cols) {
            ValidateMapBoundaries(rows, cols);

            this.rows = rows;
            this.cols = cols;
            this.grid = new CosmicSymbol[rows, cols];
        }

        public CosmicSymbol GetSymbol(int row, int col) {
            CheckIfWithinBounds(row, col);
            return grid[row, col];
        }

        public void SetSymbol(int row, int col, CosmicSymbol symbol) {
            CheckIfWithinBounds(row, col);
            grid[row, col] = symbol;

            if (symbol == CosmicSymbol.Start) {
                startPosition = new Position(row, col);
            } else if (symbol == CosmicSymbol.Finish) {
                endPosition = new Position(row, col);
            }
        }

        public Position GetStartPosition() {
            return startPosition;
        }

        public Position GetEndPosition() {
            return endPosition;
        }

        public int GetRows() {
            return rows;
        }

        public int GetCols() {
            return cols;
        }

        private void ValidateMapBoundaries(int rows, int cols) {
            ValidateDimension(rows, nameof(rows));
            ValidateDimension(cols, nameof(cols));
        }

        private void ValidateDimension(int value, string dimensionName) {
            if (value < MinDimension) {
                throw new ArgumentOutOfRangeException(dimensionName, value, $"{dimensionName} must be at least 2");
            }

            if (value > MaxDimension) {
                throw new ArgumentOutOfRangeException(dimensionName, value, $"{dimensionName} cannot exceed 100");
            }
        }

        private void CheckIfWithinBounds(int row, int col) {
            if (row < 0 || row >= rows || col < 0 || col >= cols) {
                throw new PositionOutOfBoundsException($"Position ({row}, {col}) is out of bounds for grid size ({rows}x{cols}).");
            }
        }

    }

}
