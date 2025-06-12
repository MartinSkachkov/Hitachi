namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class MultipleStartPositionsException : Exception {
        public MultipleStartPositionsException(int count)
            : base($"Map must contain exactly one start position (S). Found: {count}") {
        }

        public MultipleStartPositionsException(string message)
            : base(message) {
        }

        public MultipleStartPositionsException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
