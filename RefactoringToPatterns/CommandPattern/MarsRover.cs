namespace RefactoringToPatterns.CommandPattern
{
    public class MarsRover
    {
        private int _x;
        private int _y;
        private char _direction;
        private readonly string _availableDirections = "NESW";
        private readonly string[] _obstacles;
        private bool _obstacleFound;
        private readonly Movement movement;

        public MarsRover(int x, int y, char direction, string[] obstacles)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _obstacles = obstacles;
            movement = new Movement(this);
        }

        public int X {
            set { _x = value; }
            get { return _x; }
        }

        public bool ObstacleFound {
            set { _obstacleFound = value; }
            get { return _obstacleFound; }
        }

        public bool Found {
            set { _obstacleFound = value; }
            get { return _obstacleFound; }
        }

        public int Y {
            set { _y = value; }
            get { return _y; }
        }

        public bool ObstacleFound1 {
            set { _obstacleFound = value; }
            get { return _obstacleFound; }
        }

        public bool Found1 {
            set { _obstacleFound = value; }
            get { return _obstacleFound; }
        }

        public string GetState()
        {
            return !_obstacleFound ? $"{_x}:{_y}:{_direction}" : $"O:{_x}:{_y}:{_direction}";
        }

        public void Execute(string commands)
        {
            foreach(char command in commands)
            {
                if (command == 'M')
                {
                    switch (_direction)
                    {
                        case 'E':
                            movement.ToEast(_x, _y, _obstacles);
                            break;
                        case 'S':
                            movement.ToSouth(_x, _y, _obstacles);
                            break;
                        case 'W':
                            movement.ToWest(_x, _y, _obstacles);
                            break;
                        case 'N':
                            movement.ToNorth(_x, _y, _obstacles);
                            break;
                    }
                }
                else if(command == 'L')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 0)
                    {
                        _direction = _availableDirections[currentDirectionPosition-1];
                    }
                    else
                    {
                        _direction = _availableDirections[3];
                    }
                } else if (command == 'R')
                {
                    // get new direction
                    var currentDirectionPosition = _availableDirections.IndexOf(_direction);
                    if (currentDirectionPosition != 3)
                    {
                        _direction = _availableDirections[currentDirectionPosition+1];
                    }
                    else
                    {
                        _direction = _availableDirections[0];
                    }
                }
            }
        }
    }
}