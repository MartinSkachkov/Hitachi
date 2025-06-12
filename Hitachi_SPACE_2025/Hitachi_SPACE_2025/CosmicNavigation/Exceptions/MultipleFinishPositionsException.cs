namespace Hitachi_SPACE_2025.CosmicNavigation.Exceptions {

    internal class MultipleFinishPositionsException : Exception {
        public MultipleFinishPositionsException(int count)
            : base($"Map must contain exactly one finish position (F). Found: {count}") {
        }

        public MultipleFinishPositionsException(string message)
            : base(message) {
        }

        public MultipleFinishPositionsException(string message, Exception innerException)
            : base(message, innerException) {
        }
    }

}
