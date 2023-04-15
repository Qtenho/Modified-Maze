namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
            DrawWay();
        }

        public int N { get; }

        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            var indexV = -1;
            var indexH = -1;

            output += "  ";
            for (int j = 0; j < N; j++)
            {
                if (indexH < 9)
                {
                    indexH++;
                    output += $"{indexH}";
                }
                else
                {
                    indexH = 0;
                    output += $"{indexH}";
                }
            }
            output += "\n";

            for (int i = 0; i < N; i++)
            {
                if (indexV < 9)
                {
                    indexV++;
                    output += $"{indexV,2}";
                }
                else
                {
                    indexV = 0;
                    output += $"{indexV,2}";
                }

                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
            FillObstacles();
            //DrawWay();
        }

        private void DrawWay()
        {
            int i = 1;
            int j = 0;
            int k = -1;

            if ((_maze[1, 2] == '█' && _maze[2, 1] == '█') || (_maze[N - 2, N - 2] == '█'))
            {
                throw new ArgumentException("Game Over, maze with no exit");
            }
            else
            {
                for (j = 0; j < N; j++)
                {
                    if (_maze[i, j] == ' ')
                    {
                        _maze[i, j] = '→';
                        k++;
                    }
                    else
                    {
                        _maze[i, j = k] = '↓';
                        i++;
                        if (_maze[i, j = k] == ' ')
                        {
                            _maze[i, j = k] = '→';
                        }
                    }
                }
            }
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!(i == 1 && j == 1 || i == N - 2 && j == N - 2))
                {
                    if (_maze[i , j] == ' ')
                    {
                        _maze[i, j] = '█';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                _maze[0, i] = '█';
            }
            for (int i = 0; i < N - 1; i++)
            {
                _maze[1, i] = ' ';
            }

            _maze[1, N - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                _maze[i, 0] = '█';
                for (int j = 1; j < N - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N - 1] = '█';
            }
            _maze[N - 2, 0] = '█';
            for (int i = 1; i < N; i++)
            {
                _maze[N - 2, i] = ' ';
            }

            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '█';
            }
        }
    }
}