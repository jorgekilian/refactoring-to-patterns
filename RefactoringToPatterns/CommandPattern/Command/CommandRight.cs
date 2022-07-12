namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandRight : CommandHandler {
        public override bool Execute(ref char direction) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[0];
            if (availableDirections.IndexOf(direction) != 3) {
                availableDirection = availableDirections[availableDirections.IndexOf(direction) + 1];
            }
            direction = availableDirection;
            return true;
        }

    }
}