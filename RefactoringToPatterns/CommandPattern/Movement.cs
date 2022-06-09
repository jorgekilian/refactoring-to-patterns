using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Movement {
        private MarsRover marsRover;
        public bool MarsRoverObstacleFound { get; set; }

        public Movement(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        public void ToEast(int x, int y, string[] obstacles) {
            MarsRoverObstacleFound = ObstacleFound(x + 1, y, obstacles);
            marsRover.ObstacleFound = MarsRoverObstacleFound;
            marsRover.X = x < 9 && !marsRover.ObstacleFound ? marsRover.X += 1 : x;
        }

        private static bool ObstacleFound(int x, int y, string[] obstacles) {
            return obstacles.Contains($"{x}:{y}");
        }

        public void ToSouth(int x, int y, string[] obstacles) {
            marsRover.Found = ObstacleFound(x, y + 1, obstacles);
            marsRover.Y = y < 9 && !marsRover.Found ? marsRover.Y += 1 : y;
        }

        public void ToWest(int x, int y, string[] obstacles) {
            marsRover.ObstacleFound = ObstacleFound(x - 1, y, obstacles);
            marsRover.X = x > 0 && !marsRover.ObstacleFound ? marsRover.X -= 1 : x;
        }

        public void ToNorth(int x, int y, string[] obstacles) {
            marsRover.Found = ObstacleFound(x, y - 1, obstacles);
            marsRover.Y = y > 0 && !marsRover.Found ? marsRover.Y -= 1 : y;
        }
    }
}