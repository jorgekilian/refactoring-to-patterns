using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Movement {
        private MarsRover marsRover;
        public int X { get; private set; }
        public bool ObstacleFound { get; set; }

        public Movement(MarsRover marsRover, int X) {
            this.marsRover = marsRover;
            this.X = X;
        }
        private bool ExistObstacle(int x, int y, string[] obstacles) {
            return obstacles.Contains($"{x}:{y}");
        }

        public void ToEast(int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(X + 1, y, obstacles);
            X = X < 9 && !ObstacleFound ? X += 1 : X;
        }


        public void ToSouth(int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(X, y + 1, obstacles);
            marsRover.Y = y < 9 && !ObstacleFound ? marsRover.Y += 1 : y;
        }

        public void ToWest(int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(X - 1, y, obstacles);
            X = X > 0 && !ObstacleFound ? X -= 1 : X;
        }

        public void ToNorth(int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(X, y - 1, obstacles);
            marsRover.Y = y > 0 && !ObstacleFound ? marsRover.Y -= 1 : y;
        }
    }
}