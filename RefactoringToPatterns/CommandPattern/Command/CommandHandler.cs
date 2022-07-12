namespace RefactoringToPatterns.CommandPattern.Command {
    public abstract class CommandHandler {

        public abstract bool Execute(ref char direction);
    }
}
