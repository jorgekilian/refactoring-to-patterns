namespace RefactoringToPatterns.CommandPattern {
    public class CommandLeft {
        public CommandLeft() { }

        public char Execute(char value) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[3];
            if (availableDirections.IndexOf(value) != 0) {
                availableDirection = availableDirections[availableDirections.IndexOf(value) - 1];
            }

            return availableDirection;
        }
    }
}