namespace RefactoringToPatterns.CommandPattern {
    public class Position {
        public Position(int x, int y) {
            X = x;
            Y = y;
            HasObstacle = false;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public bool HasObstacle { get; set; }

        public Position East() {
            return new Position(this.X + 1, this.Y);
        }

        public Position South() {
            return new Position(this.X, this.Y + 1);
        }

        public Position West() {
            return new Position(this.X - 1, this.Y);
        }

        public Position North() {
            return new Position(this.X, this.Y - 1);
        }
    }
}