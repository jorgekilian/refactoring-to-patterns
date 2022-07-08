using System.Security.Policy;

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
                            existObstacle = new MoveEastHandler(position).MoveEast();
                            break;
                        case 'S':
                            existObstacle = new MoveSouthHandler(position).MoveSouth();
                            break;
                        case 'W':
                            existObstacle = new MoveWestHandler(position).MoveWest();
                            break;
                        case 'N':
                            existObstacle = new MoveNorthHandler(position).MoveNorth();
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