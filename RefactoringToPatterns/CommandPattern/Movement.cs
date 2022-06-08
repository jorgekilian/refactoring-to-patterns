using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Movement {
        private MarsRover marsRover;
        public Movement(MarsRover marsRover) {
            this.marsRover = marsRover;
        }

        public void ToEast(int x, int y, string[] obstacles) {
            marsRover.ObstacleFound = obstacles.Contains($"{x + 1}:{y}");
            marsRover.X = x < 9 && !marsRover.ObstacleFound ? marsRover.X += 1 : x;
        }

        public void ToSouth(int x, int y, string[] obstacles) {
            marsRover.Found = obstacles.Contains($"{x}:{y + 1}");
            marsRover.Y = y < 9 && !marsRover.Found ? marsRover.Y += 1 : y;
        }

        public void ToWest(int x, int y, string[] obstacles) {
            marsRover.ObstacleFound1 = obstacles.Contains($"{x - 1}:{y}");
            marsRover.X = x > 0 && !marsRover.ObstacleFound1 ? marsRover.X -= 1 : x;
        }

        public void ToNorth(int x, int y, string[] obstacles) {
            marsRover.Found1 = obstacles.Contains($"{x}:{y - 1}");
            marsRover.Y = y > 0 && !marsRover.Found1 ? marsRover.Y -= 1 : y;
        }
    }
}