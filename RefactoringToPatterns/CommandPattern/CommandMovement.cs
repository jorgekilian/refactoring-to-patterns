using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern {
    public class CommandMovement {
        private readonly Dictionary<char, MoveHandler> handlers;

        public CommandMovement(Position position) {
            handlers = new Dictionary<char, MoveHandler> {
                { 'E', new MoveEastHandler(position) },
                { 'S', new MoveSouthHandler(position) },
                { 'W', new MoveWestHandler(position) },
                { 'N', new MoveNorthHandler(position) }
            };
        }

        public bool Execute(char direction) {
            return handlers[direction].Execute();
        }
    }
}