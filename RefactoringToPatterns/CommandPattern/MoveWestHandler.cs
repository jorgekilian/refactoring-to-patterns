using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveWestHandler {
        private Position position;
        public MoveWestHandler(Position position) {
            this.position = position;
        }

        public bool MoveWest() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X - 1}:{position.Y}");
            if (!obstacle) if (position.X > 0)
                position.X -= 1;
            return obstacle;
        }
    }
}