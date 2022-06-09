using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Movement {
        private MarsRover marsRover;
        public bool ObstacleFound { get; set; }

        public Movement(MarsRover marsRover) {
            this.marsRover = marsRover;
        }
        private bool ExistObstacle(int x, int y, string[] obstacles) {
            return obstacles.Contains($"{x}:{y}");
        }

        public void ToEast(int x, int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(x + 1, y, obstacles);
            marsRover.X = x < 9 && !ObstacleFound ? marsRover.X += 1 : x;
        }


        public void ToSouth(int x, int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(x, y + 1, obstacles);
            marsRover.Y = y < 9 && !ObstacleFound ? marsRover.Y += 1 : y;
        }

        public void ToWest(int x, int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(x - 1, y, obstacles);
            marsRover.X = x > 0 && !ObstacleFound ? marsRover.X -= 1 : x;
        }

        public void ToNorth(int x, int y, string[] obstacles) {
            ObstacleFound = ExistObstacle(x, y - 1, obstacles);
            marsRover.Y = y > 0 && !ObstacleFound ? marsRover.Y -= 1 : y;
        }
    }
}