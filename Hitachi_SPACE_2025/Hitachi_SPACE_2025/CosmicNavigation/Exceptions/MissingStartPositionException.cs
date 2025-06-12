namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class MissingStartPositionException : Exception {
        public MissingStartPositionException()
            : base("Map must contain exactly one start position (S). None found.") {
        }

        public MissingStartPositionException(string message)
            : base(message) {
        }

        public MissingStartPositionException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
