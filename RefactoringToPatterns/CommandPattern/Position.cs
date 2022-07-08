using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Position {
        private string[] obstacles;

        public Position(int x, int y, string[] obstacles) {
            this.obstacles = obstacles;
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Position PositionToEast() {
            return new Position(X < 9 ? X += 1 : X, Y, obstacles);
        }

        public Position PositionToSouth() {
            return new Position(X, Y < 9 ? Y += 1 : Y, obstacles);
        }

        public Position PositionToWest() {
            return new Position(X > 0 ? X -= 1 : X, Y, obstacles);
        }

        public Position PositionToNorth() {
            return new Position(X, Y > 0 ? Y -= 1 : Y, obstacles);
        }

        public bool ExistObstacleAtEast() {
            return obstacles.Contains($"{X + 1}:{Y}");
        }

        public bool ExistObstacleAtSouth() {
            return obstacles.Contains($"{X}:{Y + 1}");
        }

        public bool ExistObstacleAtWest() {
            return obstacles.Contains($"{X - 1}:{Y}");
        }

        public bool ExistObstacleAtNorth() {
            return obstacles.Contains($"{X}:{Y - 1}");
        }
    }
}