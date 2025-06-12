namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class MissingFinishPositionException : Exception {
        public MissingFinishPositionException()
            : base("Map must contain exactly one finish position (F). None found.") {
        }

        public MissingFinishPositionException(string message)
            : base(message) {
        }

        public MissingFinishPositionException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
