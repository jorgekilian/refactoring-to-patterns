namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly string _availableDirections = "NESW";
        private Terrain terrain;
        private Position position;

        public MarsRover(Position position, char direction, string[] obstacles) {
            this.position = position;
            this.direction = direction;
            terrain = new Terrain(obstacles);
        }

        public string GetState() {
            return !position.HasObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    switch (direction) {
                        case 'E':
                            position = position.PositionToEast(terrain.ExistObstacle(position.East()));
                            break;
                        case 'S':
                            position = position.PositionToSouth(terrain.ExistObstacle(position.South()));
                            break;
                        case 'W':
                            position = position.PositionToWest(terrain.ExistObstacle(position.West()));
                            break;
                        case 'N':
                            position = position.PositionToNorth(terrain.ExistObstacle(position.North()));
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