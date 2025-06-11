namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class PositionOutOfBoundsException : Exception {
        public PositionOutOfBoundsException()
            : base("The specified position is out of bounds.") {
        }

        public PositionOutOfBoundsException(string message)
            : base(message) {
        }

        public PositionOutOfBoundsException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
