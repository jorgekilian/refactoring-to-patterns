namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandRight : CommandHandler {
        private const string AvailableDirections = "NESW";

        public override bool Execute(ref char direction) {
            var availableDirection = AvailableDirections[0];
            if (AvailableDirections.IndexOf(direction) != 3) {
                availableDirection = AvailableDirections[AvailableDirections.IndexOf(direction) + 1];
            }
            direction = availableDirection;
            return false;
        }

    }
}