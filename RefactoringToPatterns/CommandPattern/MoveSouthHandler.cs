using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveSouthHandler {
        private Position position;
        public MoveSouthHandler(Position position) {
            this.position = position;
        }

        public bool MoveSouth() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X}:{position.Y + 1}");
            if (!obstacle) if (position.Y < 9)
                position.Y += 1;
            return obstacle;
        }
    }
}