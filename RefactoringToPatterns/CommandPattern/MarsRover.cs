using System.Collections.Generic;
using System.Data;
using System.Security.Policy;

namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly string _availableDirections = "NESW";
        private Position position;
        private bool existObstacle;
        private Dictionary<char, MoveHandler> handlers;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
            CreateMovementHandlers();
        }


        public string GetState() {
            return !existObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    existObstacle = LookupMovementHandlerBy(direction).Execute();
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
        private void CreateMovementHandlers() {
            handlers = new Dictionary<char, MoveHandler>();
            handlers.Add('E', new MoveEastHandler(position));
            handlers.Add('S', new MoveSouthHandler(position));
            handlers.Add('W', new MoveWestHandler(position));
            handlers.Add('N', new MoveNorthHandler(position));
        }

        private MoveHandler LookupMovementHandlerBy(char direction) {
            return handlers[direction];
        }
    }
}