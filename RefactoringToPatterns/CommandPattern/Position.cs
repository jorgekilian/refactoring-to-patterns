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

        public string[] Obstacles {
            set { obstacles = value; }
            get { return obstacles; }
        }

    }
}