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

        public void PositionToEast() {
            if (X < 9) X += 1;
        }

        public void PositionToSouth() {
            if (Y < 9) Y += 1;
        }

        public void PositionToWest() {
            if (X > 0) X -= 1;
        }

        public void PositionToNorth() {
            if (Y > 0) Y -= 1;
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