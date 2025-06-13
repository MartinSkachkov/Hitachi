namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class NoPathsFoundException : Exception {
        public NoPathsFoundException()
            : base("No paths found from the start to the finish position.") {
        }

        public NoPathsFoundException(string message)
            : base(message) {
        }

        public NoPathsFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
