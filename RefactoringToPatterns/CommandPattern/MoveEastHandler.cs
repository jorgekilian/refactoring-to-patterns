using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveEastHandler {
        private Position position;
        public MoveEastHandler(Position position) {
            this.position = position;
        }

        public bool MoveEast() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X + 1}:{position.Y}");
            if (!obstacle) if (position.X < 9)
                position.X += 1;
            return obstacle;
        }
    }
}