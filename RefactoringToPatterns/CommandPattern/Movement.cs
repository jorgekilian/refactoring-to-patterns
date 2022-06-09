using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Movement {
        public int Y { get; private set; }
        public int X { get; private set; }
        public bool ObstacleFound { get; set; }

        public Movement(int x, int y) {
            X = x;
            Y = y;
        }
        private bool ExistObstacle(int x, int y, string[] obstacles) {
            return obstacles.Contains($"{x}:{y}");
        }

        public void ToEast(string[] obstacles) {
            ObstacleFound = ExistObstacle(X + 1, Y, obstacles);
            X = X < 9 && !ObstacleFound ? X += 1 : X;
        }


        public void ToSouth(string[] obstacles) {
            ObstacleFound = ExistObstacle(X, Y + 1, obstacles);
            Y = Y < 9 && !ObstacleFound ? Y += 1 : Y;
        }

        public void ToWest(string[] obstacles) {
            ObstacleFound = ExistObstacle(X - 1, Y, obstacles);
            X = X > 0 && !ObstacleFound ? X -= 1 : X;
        }

        public void ToNorth(string[] obstacles) {
            ObstacleFound = ExistObstacle(X, Y - 1, obstacles);
            Y = Y > 0 && !ObstacleFound ? Y -= 1 : Y;
        }
    }
}