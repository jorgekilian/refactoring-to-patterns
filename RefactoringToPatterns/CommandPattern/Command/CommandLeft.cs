namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandLeft : CommandHandler {
        public override char Execute(char value) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[3];
            if (availableDirections.IndexOf(value) != 0) {
                availableDirection = availableDirections[availableDirections.IndexOf(value) - 1];
            }

            return availableDirection;
        }
    }
}