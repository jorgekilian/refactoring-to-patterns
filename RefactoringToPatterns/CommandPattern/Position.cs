namespace RefactoringToPatterns.CommandPattern {
    public class Position {
        public Position(int x, int y) {
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

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