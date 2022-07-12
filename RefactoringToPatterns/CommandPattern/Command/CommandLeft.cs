namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandLeft : CommandHandler {
        public override char Execute(ref char direction) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[3];
            if (availableDirections.IndexOf(direction) != 0) {
                availableDirection = availableDirections[availableDirections.IndexOf(direction) - 1];
            }
            direction = availableDirection;
            return direction;
        }
    }
}