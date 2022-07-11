namespace RefactoringToPatterns.CommandPattern {
    public class CommandRight {
        public CommandRight() { }

        public char GetDirectionRight(char value) {
            const string availableDirections = "NESW";
            var availableDirection = availableDirections[0];
            if (availableDirections.IndexOf(value) != 3) {
                availableDirection = availableDirections[availableDirections.IndexOf(value) + 1];
            }

            return availableDirection;
        }
    }
}