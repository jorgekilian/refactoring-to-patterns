using System.Collections.Generic;
using RefactoringToPatterns.CommandPattern.Command;

namespace RefactoringToPatterns.CommandPattern {
    public class MarsRover {
        private readonly Position position;
        private char direction;
        private bool existObstacle;
        private readonly Dictionary<char, CommandHandler> commandHandler;

        public MarsRover(Position position, char direction) {
            this.position = position;
            this.direction = direction;
            commandHandler = new Dictionary<char, CommandHandler> {
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
                existObstacle = commandHandler[command].Execute(ref direction);
            }
        }
    }
}