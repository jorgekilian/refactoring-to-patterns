using System.Linq;

namespace RefactoringToPatterns.CommandPattern {

    public class Movement {
        private string[] obstacles;
        private Position position;
        public int Y { get; private set; }
        public int X { get; private set; }
        public bool ObstacleFound { get; private set; }

        public Movement(Position position, string[] obstacles) {
            this.position = position;
            X = position.X;
            Y = position.Y;
            this.obstacles = obstacles;
        }
        private bool ExistObstacle(int x, int y) {
            return obstacles.Contains($"{x}:{y}");
        }

        public Position ToEast() {
            ObstacleFound = ExistObstacle(X + 1, Y);
            X = X < 9 && !ObstacleFound ? X += 1 : X;
            return this.position;
        }


        public Position ToSouth() {
            ObstacleFound = ExistObstacle(X, Y + 1);
            Y = Y < 9 && !ObstacleFound ? Y += 1 : Y;
            return this.position;
        }

        public Position ToWest() {
            ObstacleFound = ExistObstacle(X - 1, Y);
            X = X > 0 && !ObstacleFound ? X -= 1 : X;
            return this.position;
        }

        public Position ToNorth() {
            ObstacleFound = ExistObstacle(X, Y - 1);
            Y = Y > 0 && !ObstacleFound ? Y -= 1 : Y;
            return this.position;
        }
    }
}