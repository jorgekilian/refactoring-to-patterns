using System.Collections.Generic;
using RefactoringToPatterns.CommandPattern.Movement;

namespace RefactoringToPatterns.CommandPattern.Command {
    public class CommandMovement : CommandHandler {
        private readonly Dictionary<char, MoveHandler> handlers;

        public CommandMovement(Position position) {
            handlers = new Dictionary<char, MoveHandler> {
                { 'E', new MoveEastHandler(position) },
                { 'S', new MoveSouthHandler(position) },
                { 'W', new MoveWestHandler(position) },
                { 'N', new MoveNorthHandler(position) }
            };
        }

        public override bool Execute(ref char direction) {
            return handlers[direction].Execute();
        }
    }
}