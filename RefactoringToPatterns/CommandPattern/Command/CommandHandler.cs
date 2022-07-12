namespace RefactoringToPatterns.CommandPattern.Command {
    public abstract class CommandHandler {

        public abstract char Execute(ref char direction);
    }
}
