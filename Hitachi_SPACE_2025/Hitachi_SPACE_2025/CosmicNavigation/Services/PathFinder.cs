using Hitachi_SPACE_2025.CosmicNavigation.Exceptions;
using Hitachi_SPACE_2025.CosmicNavigation.Models;

namespace Hitachi_SPACE_2025.CosmicNavigation.Services {

    // Provides pathfinding functionality on a cosmic map.
    // 
    // This class is responsible for:
    // - Counting all possible paths from the start position to the finish position using Depth-First Search (DFS).
    // - Finding the shortest path from start to finish using Breadth-First Search (BFS).
    // - Throwing a custom exception if no shortest path is found.
    // - Managing visited positions to avoid revisiting during traversal.

    internal class PathFinder {

        private readonly CosmicMap cosmicMap;

        public PathFinder(CosmicMap cosmicMap) {
            if (cosmicMap == null) {
                throw new ArgumentNullException(nameof(cosmicMap), "CosmicMap cannot be null.");
            }

            this.cosmicMap = cosmicMap;
        }

        public int CountAllPaths() {
            Position start = cosmicMap.GetStartPosition();
            Position end = cosmicMap.GetEndPosition();

            bool[,] visited = new bool[cosmicMap.GetRows(), cosmicMap.GetCols()];

            int totalPathsCount = DFS(start, end, visited);

            if (totalPathsCount == 0) {
                throw new NoPathsFoundException();
            }

            return totalPathsCount;
        }

        private int DFS(Position current, Position end, bool[,] visited) {
            if (current.IsEqualTo(end)) {
                return 1;
            }

            visited[current.GetRow(), current.GetCol()] = true;
            int pathCount = 0;

            foreach (Position neighbor in GetNeighbors(current)) {
                if (!visited[neighbor.GetRow(), neighbor.GetCol()] &&
                    cosmicMap.GetSymbol(neighbor.GetRow(), neighbor.GetCol()) != CosmicSymbol.Asteroid) {
                    pathCount += DFS(neighbor, end, visited);
                }
            }

            visited[current.GetRow(), current.GetCol()] = false;
            return pathCount;
        }

        public List<Position> FindShortestPath() {
            List<Position> shortestPath = BFS();

            if (shortestPath.Count == 0) {
                throw new ShortestPathNotFoundException();
            }

            return shortestPath;
        }

        private List<Position> BFS() {
            Position start = cosmicMap.GetStartPosition();
            Position end = cosmicMap.GetEndPosition();

            Queue<(Position pos, List<Position> path)> queue = new Queue<(Position pos, List<Position> path)>();
            bool[,] visited = new bool[cosmicMap.GetRows(), cosmicMap.GetCols()];

            queue.Enqueue((start, new List<Position> { start }));
            visited[start.GetRow(), start.GetCol()] = true;

            while (queue.Count > 0) {
                (Position pos, List<Position> path) current = queue.Dequeue();
                Position currentPos = current.pos;
                List<Position> currentPath = current.path;

                if (currentPos.IsEqualTo(end)) {
                    return currentPath;
                }

                foreach (Position neighbour in GetNeighbors(currentPos)) {
                    if (!visited[neighbour.GetRow(), neighbour.GetCol()] &&
                        cosmicMap.GetSymbol(neighbour.GetRow(), neighbour.GetCol()) != CosmicSymbol.Asteroid) {
                        visited[neighbour.GetRow(), neighbour.GetCol()] = true;
                        List<Position> newPath = new List<Position>(currentPath);
                        newPath.Add(neighbour);
                        queue.Enqueue((neighbour, newPath));
                    }
                }
            }

            return new List<Position>();
        }


        private List<Position> GetNeighbors(Position position) {
            int[] rowOffsets = { -1, 1, 0, 0 };
            int[] colOffsets = { 0, 0, -1, 1 };
            List<Position> neighbors = new List<Position>();

            for (int i = 0; i < 4; i++) {
                int newRow = position.GetRow() + rowOffsets[i];
                int newCol = position.GetCol() + colOffsets[i];

                if (newRow >= 0 && newRow < cosmicMap.GetRows() &&
                    newCol >= 0 && newCol < cosmicMap.GetCols()) {
                    neighbors.Add(new Position(newRow, newCol));
                }
            }

            return neighbors;
        }

    }
}

