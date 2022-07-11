using System.Collections.Generic;
using System.Data;
using System.Security.Policy;

namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly Position position;
        private bool existObstacle;
        private Dictionary<char, MoveHandler> handlers;
        private readonly CommandLeft commandLeft;
        private readonly CommandRight commandRight;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
            CreateMovementHandlers();
            commandLeft = new CommandLeft();
            commandRight = new CommandRight();
        }


        public string GetState() {
            return !existObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (char command in commands) {
                if (command == 'M') {
                    existObstacle = LookupMovementHandlerBy().Execute();
                }
                else if (command == 'L') {
                    direction = commandLeft.GetDirectionLeft(direction);
                }
                else if (command == 'R') {
                    direction = commandRight.GetDirectionRight(direction);
                }
            }
        }

        private void CreateMovementHandlers() {
            handlers = new Dictionary<char, MoveHandler> {
                { 'E', new MoveEastHandler(position) },
                { 'S', new MoveSouthHandler(position) },
                { 'W', new MoveWestHandler(position) },
                { 'N', new MoveNorthHandler(position) }
            };
        }

        private MoveHandler LookupMovementHandlerBy() {
            return handlers[direction];
        }
    }
}