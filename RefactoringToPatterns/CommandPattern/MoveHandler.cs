namespace RefactoringToPatterns.CommandPattern {
    public abstract class MoveHandler {
        protected Position position;

        public MoveHandler(Position position) {
            this.position = position;
        }

        public abstract bool Execute();
    }
}