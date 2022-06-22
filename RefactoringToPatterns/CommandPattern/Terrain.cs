using System.Linq;

namespace RefactoringToPatterns.CommandPattern {
    public class Terrain {

        private readonly string[] obstacles;
        
        public Terrain(string[] obstacles) {
            this.obstacles = obstacles;
        }

        public bool ExistObstacle(Position position) {
            return obstacles.Contains($"{position.X}:{position.Y}");
        }
    }
}