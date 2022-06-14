namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly string _availableDirections = "NESW";
        private readonly Movement movement;
        private Position position;

        public MarsRover(Position position, char direction, string[] obstacles) {
            this.position = position;
            this.direction = direction;
            movement = new Movement(position, obstacles);
        }

        public string GetState() {
            return !movement.ObstacleFound ? $"{movement.X}:{movement.Y}:{direction}" : $"O:{movement.X}:{movement.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    switch (direction) {
                        case 'E':
                            movement.ToEast();
                            break;
                        case 'S':
                            movement.ToSouth();
                            break;
                        case 'W':
                            movement.ToWest();
                            break;
                        case 'N':
                            movement.ToNorth();
                            break;
                    }
                }
                else if (command == 'L') {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(direction);
                    if (currentDirectionPosition != 0) {
                        direction = _availableDirections[currentDirectionPosition - 1];
                    }
                    else {
                        direction = _availableDirections[3];
                    }
                }
                else if (command == 'R') {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(direction);
                    if (currentDirectionPosition != 3) {
                        direction = _availableDirections[currentDirectionPosition + 1];
                    }
                    else {
                        direction = _availableDirections[0];
                    }
                }
            }
        }
    }
}