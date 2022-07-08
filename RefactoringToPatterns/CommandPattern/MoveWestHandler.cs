using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveWestHandler : MoveHandler {
        private Position position;
        public MoveWestHandler(Position position) : base(position) {
            this.position = position;
        }

        public override bool Execute() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X - 1}:{position.Y}");
            if (!obstacle) if (position.X > 0)
                position.X -= 1;
            return obstacle;
        }
    }
}