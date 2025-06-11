namespace Hitachi_SPACE_2025.CosmicNavigation.Models {

    // The Position class represents a coordinate in a two-dimensional grid, defined by row and column values. 
    // It includes methods for comparing equality with another Position instance, retrieving row and column values, 
    // and generating a string representation of the coordinate.

    internal class Position {

        private readonly int row;
        private readonly int col;

        public Position(int row, int col) {
            this.row = row;
            this.col = col;
        }

        public bool IsEqualTo(Position other) {
            if (other == null) {
                throw new ArgumentNullException(nameof(other), "Position cannot be null.");
            }

            return this.row == other.row && this.col == other.col;
        }

        public override string ToString() {
            return $"({row}, {col})";
        }

        public int GetRow() {
            return row;
        }

        public int GetCol() {
            return col;
        }

    }

}