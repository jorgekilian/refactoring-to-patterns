namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandRight : CommandHandler {
        public override char Execute(char value) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[0];
            if (availableDirections.IndexOf(value) != 3) {
                availableDirection = availableDirections[availableDirections.IndexOf(value) + 1];
            }

            return availableDirection;
        }

    }
}