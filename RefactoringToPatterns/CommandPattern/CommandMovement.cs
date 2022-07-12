using System.Collections.Generic;

namespace RefactoringToPatterns.CommandPattern {
    public class CommandMovement {
        public CommandMovement() { }

        public bool ComandMovement(Position position, char direction) {
            var handlers = new Dictionary<char, MoveHandler> {
                { 'E', new MoveEastHandler(position) },
                { 'S', new MoveSouthHandler(position) },
                { 'W', new MoveWestHandler(position) },
                { 'N', new MoveNorthHandler(position) }
            };
            return handlers[direction].Execute();
        }
    }
}