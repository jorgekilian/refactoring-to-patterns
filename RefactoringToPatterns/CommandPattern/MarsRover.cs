using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using RefactoringToPatterns.CommandPattern.Command;

namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly Position position;
        private bool existObstacle;
        private readonly CommandLeft commandLeft;
        private readonly CommandRight commandRight;
        private readonly CommandMovement commandMovement;
        private readonly Dictionary<char, CommandHandler> handlers;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
            commandLeft = new CommandLeft();
            commandRight = new CommandRight();
            commandMovement = new CommandMovement(this.position);
            handlers = new Dictionary<char, CommandHandler> {
                { 'L', new CommandLeft() },
                { 'R', new CommandRight() }
            };
        }


        public string GetState() {
            return !existObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (var command in commands) {
                if (command == 'M') {
                    existObstacle = commandMovement.Execute(direction);
                }
                else {
                    direction = handlers[command].Execute(direction);
                }
            }
        }
    }
}