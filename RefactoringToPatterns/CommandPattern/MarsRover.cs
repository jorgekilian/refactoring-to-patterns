using System.Collections.Generic;
using System.Data;
using System.Security.Policy;
using RefactoringToPatterns.CommandPattern.Command;

namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private char direction;
        private readonly Position position;
        private bool existObstacle;
        private readonly Dictionary<char, CommandHandler> handlers;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
            new CommandLeft();
            new CommandRight();
            new CommandMovement(this.position);
            handlers = new Dictionary<char, CommandHandler> {
                { 'L', new CommandLeft() },
                { 'R', new CommandRight() },
                { 'M', new CommandMovement(this.position) }
            };
        }


        public string GetState() {
            return !existObstacle ? $"{position.X}:{position.Y}:{direction}" : $"O:{position.X}:{position.Y}:{direction}";
        }

        public void Execute(string commands) {
            foreach (var command in commands) {
                if (command == 'M') {
                    existObstacle = handlers[command].Execute(ref direction);
                }
                else {
                    handlers[command].Execute(ref direction);
                }
            }
        }
    }
}