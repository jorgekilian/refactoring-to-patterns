namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char _direction;
        private readonly string _availableDirections = "NESW";
        private readonly Movement movement;
        private Position position;

        public MarsRover(Position position, char direction, string[] obstacles) {
            this.position = position;
            _direction = direction;
            movement = new Movement(position, obstacles);
        }

        public string GetState() {
            return !movement.ObstacleFound ? $"{movement.X}:{movement.Y}:{_direction}" : $"O:{movement.X}:{movement.Y}:{_direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    switch (_direction) {
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
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 0) {
                        _direction = _availableDirections[currentDirectionPosition - 1];
                    }
                    else {
                        _direction = _availableDirections[3];
                    }
                }
                else if (command == 'R') {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 3) {
                        _direction = _availableDirections[currentDirectionPosition + 1];
                    }
                    else {
                        _direction = _availableDirections[0];
                    }
                }
            }
        }
    }
}