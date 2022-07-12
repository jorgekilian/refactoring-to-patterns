namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandLeft : CommandHandler {
        private const string AvailableDirections = "NESW";

        public override bool Execute(ref char direction) {
            var availableDirection = AvailableDirections[3];
            if (AvailableDirections.IndexOf(direction) != 0) {
                availableDirection = AvailableDirections[AvailableDirections.IndexOf(direction) - 1];
            }
            direction = availableDirection;
            return true;
        }
    }
}