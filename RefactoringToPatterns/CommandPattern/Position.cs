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

        public bool PositionToEast() {
            var obstacle = ExistObstacleAtEast();
            if (!obstacle) if (X < 9) X += 1;
            return obstacle;
        }

        public bool PositionToSouth() {
            var obstacle = ExistObstacleAtSouth();
            if (!obstacle) if (Y < 9) Y += 1;
            return obstacle;
        }

        public bool PositionToWest() {
            var obstacle = ExistObstacleAtWest();
            if (!obstacle) if (X > 0) X -= 1;
            return obstacle;
        }

        public bool PositionToNorth() {
            var obstacle = ExistObstacleAtNorth();
            if (!obstacle) if (Y > 0) Y -= 1;
            return obstacle;
        }

        private bool ExistObstacleAtEast() {
            return obstacles.Contains($"{X + 1}:{Y}");
        }

        private bool ExistObstacleAtSouth() {
            return obstacles.Contains($"{X}:{Y + 1}");
        }

        private bool ExistObstacleAtWest() {
            return obstacles.Contains($"{X - 1}:{Y}");
        }

        private bool ExistObstacleAtNorth() {
            return obstacles.Contains($"{X}:{Y - 1}");
        }
    }
}