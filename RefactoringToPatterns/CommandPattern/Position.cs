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

        public bool MoveEast() {
            var obstacle = obstacles.Contains($"{X + 1}:{Y}");
            if (!obstacle) if (X < 9) X += 1;
            return obstacle;
        }

        public bool MoveSouth() {
            var obstacle = obstacles.Contains($"{X}:{Y + 1}");
            if (!obstacle) if (Y < 9) Y += 1;
            return obstacle;
        }

        public bool MoveWest() {
            var obstacle = obstacles.Contains($"{X - 1}:{Y}");
            if (!obstacle) if (X > 0) X -= 1;
            return obstacle;
        }

        public bool MoveNorth() {
            var obstacle = obstacles.Contains($"{X}:{Y - 1}");
            if (!obstacle) if (Y > 0) Y -= 1;
            return obstacle;
        }

    }
}