namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly string _availableDirections = "NESW";
        private Terrain terrain;
        private bool obstacleFound;
        private Position position;

        public MarsRover(Position position, char direction, string[] obstacles) {
            this.position = position;
            this.direction = direction;
            terrain = new Terrain(obstacles);
        }

        public string GetState() {
            return !obstacleFound ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    switch (direction) {
                        case 'E':
                            position = MoveEast(position);
                            break;
                        case 'S':
                            position = MoveSouth(position);
                            break;
                        case 'W':
                            position = MoveWest(position);
                            break;
                        case 'N':
                            position = MoveNorth(position);
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

        private Position MoveNorth(Position position) {
            obstacleFound = terrain.ExistObstacle(position.North());
            return new Position(position.X, position.Y > 0 && !obstacleFound ? position.Y -= 1 : position.Y);
        }

        private Position MoveWest(Position position) {
            obstacleFound = terrain.ExistObstacle(position.West());
            return new Position(position.X > 0 && !obstacleFound ? position.X -= 1 : position.X, position.Y);
        }

        private Position MoveSouth(Position position) {
            obstacleFound = terrain.ExistObstacle(position.South());
            return new Position(position.X, position.Y < 9 && !obstacleFound ? position.Y += 1 : position.Y);
        }

        private Position MoveEast(Position position) {
            obstacleFound = terrain.ExistObstacle(position.East());
            return new Position(position.X < 9 && !obstacleFound ? position.X += 1 : position.X, position.Y);
        }
    }
}