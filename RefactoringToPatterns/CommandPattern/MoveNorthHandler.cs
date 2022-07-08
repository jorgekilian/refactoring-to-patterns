using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveNorthHandler : MoveHandler {
        private Position position;
        public MoveNorthHandler(Position position) {
            this.position = position;
        }

        public override bool Execute() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X}:{position.Y - 1}");
            if (!obstacle) if (position.Y > 0)
                position.Y -= 1;
            return obstacle;
        }
    }
}