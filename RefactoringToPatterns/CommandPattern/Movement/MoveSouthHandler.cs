using System.Collections;

namespace RefactoringToPatterns.CommandPattern.Movement {
    public class MoveSouthHandler : MoveHandler {
        private Position position;
        public MoveSouthHandler(Position position) {
            this.position = position;
        }

        public override bool Execute() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X}:{position.Y + 1}");
            if (!obstacle) if (position.Y < 9)
                position.Y += 1;
            return obstacle;
        }
    }
}