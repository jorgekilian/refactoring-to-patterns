namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly string _availableDirections = "NESW";
        private Position position;
        private bool existObstacle;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
        }

        public string GetState() {
            return !existObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    switch (direction) {
                        case 'E':
                            existObstacle = MoveToEast();
                            break;
                        case 'S':
                            existObstacle = MoveToSouth();
                            break;
                        case 'W':
                            existObstacle = MoveToWest();
                            break;
                        case 'N':
                            existObstacle = MoveToNorth();
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

        private bool MoveToNorth() {
            return position.PositionToNorth(); ;
        }

        private bool MoveToWest() {
            return position.PositionToWest(); ;
        }

        private bool MoveToSouth() {
            return position.PositionToSouth(); ;
        }

        private bool MoveToEast() {
            return position.PositionToEast();
        }
    }
}