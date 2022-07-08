using System.Collections;

namespace RefactoringToPatterns.CommandPattern {
    public class MoveEastHandler : MoveHandler {
        private readonly Position position;
        public MoveEastHandler(Position position) {
            this.position = position;
        }

        public override bool Execute() {
            var obstacle = ((IList)position.Obstacles).Contains($"{position.X + 1}:{position.Y}");
            if (!obstacle) if (position.X < 9)
                position.X += 1;
            return obstacle;
        }
    }
}