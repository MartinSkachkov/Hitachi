namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class ShortestPathNotFoundException : Exception {

        public ShortestPathNotFoundException()
            : base("No shortest path found from start to finish.") {
        }

        public ShortestPathNotFoundException(string message)
            : base(message) {
        }

        public ShortestPathNotFoundException(string message, Exception innerException)
            : base(message, innerException) {
        }

    }

}
